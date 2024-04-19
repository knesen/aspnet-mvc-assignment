using Infrastructure.Factories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models.Components;

namespace WebApp.Services;

public class CourseService
{
    public async Task<IActionResult> GetCourses()
    {
        using var http = new HttpClient();
        var response = await http.GetAsync("https://localhost:7275/api/courses");
        var json = await response.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(json);

        if(data != null)
        {
            return (IActionResult)data;
        }
        return (IActionResult)response;
    }
}
