﻿using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Models.Views;

namespace WebApp.Controllers;

public class AuthController(UserService userService) : Controller
{
    private readonly UserService _userService = userService;

    [Route("/signup")]
    [HttpGet] 
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [Route("/signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _userService.CreateUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
                return RedirectToAction("SignIn", "Auth");
            
        }
       
        return View(viewModel);             
                                    
    }

    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn()
    {
        var viewModel = new SignInViewModel();
        return View(viewModel);
    }

    [Route("/signin")]
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {

        if (ModelState.IsValid)
        {
            var result = await _userService.SignInUserAsync(viewModel.Form);
            if (result.StatusCode == Infrastructure.Models.StatusCode.OK)
            {
                var claims = new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, viewModel.Form.Email),
                    new(ClaimTypes.Name, viewModel.Form.Email),
                    new(ClaimTypes.Email, viewModel.Form.Email)
                };
                await HttpContext.SignInAsync("AuthCookie", new ClaimsPrincipal(new ClaimsIdentity(claims, "AuthCookie")));
            }
                return RedirectToAction("Details", "Account"); ;

        }
        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);
        


    }

    [HttpGet]
    public new async Task<IActionResult> SignOut()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Account");
    }
}
