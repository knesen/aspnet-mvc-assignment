using Infrastructure.Factories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Text;
using WebApp.Models.Components;

namespace WebApp.Services;

public class SubscribeService
{
    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscriberModel model)
    {
        if (model != null)
        {
            using var http = new HttpClient();

            var json = JsonConvert.SerializeObject(model);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await http.PostAsync($"https://localhost:7275/api/subscribers?email={model.Email}", content);
            

            if (response.IsSuccessStatusCode == true)
            {
                return (IActionResult)response;
            }
            
        }
        return null;
    }
}
