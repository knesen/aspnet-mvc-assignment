using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models.Components;
using WebApp.Models.Views;

namespace WebApp.Controllers;

public class CoursesController : Controller
{
    [Route("/courses")]
    public async Task<IActionResult> Index()
    {
        using var http = new HttpClient();
        var response = await http.GetAsync("https://localhost:7275/api/courses");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(json);

        var viewModel = new CoursesViewModel
        {
            Title = "Courses",
            Id = "courses",
            Courses = data
        };

        ViewData["Title"] = viewModel.Title;

        return View(viewModel);
    }
    public async Task<IActionResult> Details(string id)
    {
        using var http = new HttpClient();
        var response = await http.GetAsync($"https://localhost:7275/api/courses/{id}");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<CourseModel>(json);

        return View(data);
    }
}
