using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Sections;

namespace WebApp.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Profile";
        return View();
    }

    public IActionResult SignIn()
    {
        ViewData["Title"] = "Sign In";
        return View();
    }
    public IActionResult SignUp()
    {
        var viewModel = new SignupViewModel()
        {
            FirstName = "",
            LastName = "",
            Email = "",
            Password = "",

        };

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
    public new IActionResult SignOut()
    {
        return RedirectToAction("Index", "Home");
    }
}

