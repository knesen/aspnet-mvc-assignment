using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Models.Views;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, DataContext context) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    private readonly DataContext _context = context;

    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            if(!await _context.Users.AnyAsync(x => x.Email == viewModel.Form.Email))
            {
                var userEntity = new UserEntity{
                    Email = viewModel.Form.Email,
                    UserName = viewModel.Form.Email,
                    FirstName = viewModel.Form.FirstName,
                    LastName = viewModel.Form.LastName,

                };

                if ((await _userManager.CreateAsync(userEntity, viewModel.Form.Password)).Succeeded)
                {
                    if ((await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, false, false)).Succeeded)
                        return LocalRedirect("/");
                    else
                    {
                        return LocalRedirect("signin");
                    }
                }
                else
                {
                    ViewData["StatusMessage"] = "Something went wrong. Try again later or contact customer service";
                }
            }
            else
            {
            ViewData["StatusMessage"] = "User with this email already exists.";

            }
        }

        return View(viewModel);

    }

    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {

        ViewData["ReturnUrl"] = returnUrl ?? "/";
        var viewModel = new SignInViewModel();

        return View(viewModel);
        
    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel, string returnUrl)
    {

        if (ModelState.IsValid)
        {
            if ((await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, viewModel.Form.RememberMe, false)).Succeeded)
                return LocalRedirect(returnUrl);

        }

        ViewData["ReturnUrl"] = returnUrl;
        ViewData["StatusMessage"] = "Incorrect email or password";
        
        return View(viewModel);
        



    }

    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
