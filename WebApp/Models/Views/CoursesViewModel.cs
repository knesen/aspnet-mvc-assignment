using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using WebApp.Models.Components;
using WebApp.Models.Sections;
using WebApp.Services;

namespace WebApp.Models.Views;

public class CoursesViewModel
{   
    
    
    public string Title { get; set; } = "Courses";
    public string Id { get; set; } = "courses";

    public IEnumerable<CourseModel>? Courses { get; set; }
        
        //[
        //    new () {Id = "", Title = "", ImageName = "", Author = "", IsBestseller = false, Hours = 0, OriginalPrice = 0, DiscountPrice = 0, LikesInPercent = 0, LikesInNumbers = 0,

        //    Link = new() {  ControllerName = "", ActionName = "", Text = ""} }     
        //];
    

    

}
