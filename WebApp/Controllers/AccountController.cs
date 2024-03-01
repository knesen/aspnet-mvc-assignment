using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Sections;

namespace WebApp.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    
}

