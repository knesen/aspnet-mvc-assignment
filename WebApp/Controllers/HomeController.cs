using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models.Components;
using WebApp.Models.Sections;
using WebApp.Models.Views;
using WebApp.Services;

namespace WebApp.Controllers;

public class HomeController : Controller
{   

    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
        ViewData["Title"] = viewModel.Title;        

        
        return View(viewModel);
    }


}
