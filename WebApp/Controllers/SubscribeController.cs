using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Sections;

namespace WebApp.Controllers;

public class SubscribeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {

        return View(new SubscribeViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(SubscribeViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            using var http = new HttpClient();

            var url = $"https://localhost:7275/api/subscribers?email={viewModel.Subscriber.Email}";
            var request = new HttpRequestMessage(HttpMethod.Post, url) ;

            var response = await http.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                viewModel.Subscriber.IsSubscribed = true;
            }
        }

        return View(viewModel);
    }
}
