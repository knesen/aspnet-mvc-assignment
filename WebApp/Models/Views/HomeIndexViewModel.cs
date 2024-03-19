using WebApp.Models.Sections;

namespace WebApp.Models.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Ultimate Task Management Assistant";
    public ShowcaseViewModel Showcase { get; set; } = new ShowcaseViewModel
    {
        Id = "overview",
        ShowcaseImage = new() { ImageUrl = "/images/showcase-taskmaster.svg", AltText = "Task Managment Assistant", },
        Title = "Task Management Assistant You Gonna Love",
        Text = "We offer you a new generation of task management system. Plan, manage & track all your tasks in one flexible tool.\r\n",
        Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Get started for free" },
        BrandsText = "Largest companies use our tool to work efficiently",
        Brands =
                [
                    new() { ImageUrl = "/images/brands/brand_1.svg", AltText = "Brand Name 1"},
                    new() { ImageUrl = "/images/brands/brand_2.svg", AltText = "Brand Name 2"},
                    new() { ImageUrl = "/images/brands/brand_3.svg", AltText = "Brand Name 3"},
                    new() { ImageUrl = "/images/brands/brand_4.svg", AltText = "Brand Name 4"},
                ]
    };

    public SwitchViewModel Switch { get; set; } = new SwitchViewModel
    {
        Id = "switch",
        Title = "Switch Between Light & Dark Mode",
        Icon = "/images/laptop-switch-icon.svg",
        DarkSwitchImage = new() { ImageUrl = "images/MacBook-Pro-dark.svg", AltText = "Laptop with dark background" },
        LightSwitchImage = new() { ImageUrl = "images/MacBook-Pro-light.svg", AltText = "Laptop with light background" }
    };

    public FeaturesViewModel Features { get; set; } = new FeaturesViewModel
    {
        Id = "features",
        Title = "What Do You Get with Our Tool?",
        Text = "Make sure all your tasks are organized so you can set the priorities and focus on important.",
        
        Features = 
            [
                new () { Icon = "images/icons/chat.svg", Title = "Comments on Tasks", Text = "Id mollis consectetur conque egestas suspendisse blandit justo.", Link = { ActionName = "", ControllerName = "", Text = "" } },
                new () { Icon = "images/icons/presentation.svg", Title = "Tasks Analytics", Text = "Non imperdiet facilisis nulla tellus scelerisque eget adipiscing vulputate", Link = { ActionName = "", ControllerName = "", Text = "" } },
                new () { Icon = "images/icons/add-group.svg", Title = "Multiple Assignees", Text = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris.", Link = { ActionName = "", ControllerName = "", Text = "" } },
                new () { Icon = "images/icons/bell.svg", Title = "Notifications", Text = "Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra..", Link = { ActionName = "", ControllerName = "", Text = "" } },
                new () { Icon = "images/icons/test.svg", Title = "Sections & Subtasks", Text = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus.", Link = { ActionName = "", ControllerName = "", Text = "" } },
                new () { Icon = "images/icons/shield.svg", Title = "Data Security", Text = "Aliquam malesuada neque eget elit nulla vestibulum nunc cras.", Link = { ActionName = "", ControllerName = "", Text = "" } }
            ]
    };

}
