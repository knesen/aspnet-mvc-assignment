using System.Numerics;
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

    public ManageViewModel Manage { get; set; } = new ManageViewModel
    {
        Id = "manage",
        Title = "Manage Your Work",
        Image = new() { ImageUrl = "images/manage.svg", AltText = "An example of our task master feature" },      
        Link = new() { ControllerName = "Downloads", ActionName = "Index", Text = "Learn more" },
        List = 
            [
                new () { Icon = "images/icons/checkmark.svg", Text = "Powerful project management"},
                new () { Icon = "images/icons/checkmark.svg", Text = "Transparent work management"},
                new () { Icon = "images/icons/checkmark.svg", Text = "Manage work & focus on the most important tasks"},
                new () { Icon = "images/icons/checkmark.svg", Text = "Track your progress with interactive charts"},
                new () { Icon = "images/icons/checkmark.svg", Text = "Easiest way to track time spent on tasks"}
            ]
    };

    public TestimonialsViewModel Testimonials { get; set; } = new TestimonialsViewModel
    {
        Id = "testimonials",
        Title = "Download Our App for Any Devices:",
        Image = new() { ImageUrl = "images/screens.svg", AltText = "Phones showing our app in use" },
        Items =
        [
                new () { Vendor = "App Store", RatingIcon = "images/icons/rating.svg", Flair = "Editor's Choice", RatingText = "rating 4.7, 187K+ reviews", VendorButtonImage = new() { ImageUrl = "images/brands/appstore.svg", AltText = "App store button" } },
                new () { Vendor = "Google Play", RatingIcon = "images/icons/rating.svg", Flair = "App of the Day", RatingText = "rating 4.8, 30K+ reviews", VendorButtonImage = new() { ImageUrl = "images/brands/googleplay.svg", AltText = "Google play button" } }
            ]
    };

    public ToolsViewModel Tools { get; set; } = new ToolsViewModel
    {
        Id = "tools",
        Title = "Integrate Top Work Tools",
        Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin volutpat mollis egestas. Nam luctus facilisis ultrices. Pellentesque volutpat ligula est. Mattis fermentum, at nec lacus.",
        List =
            [
                new () { Icon = "images/tools/google.svg", Text = "Lorem magnis pretium sed curabitur nunc facilisi nunc cursus sagittis.", Link = {ControllerName = "", ActionName = "", Text = ""}},
                new () { Icon = "images/tools/zoom.svg", Text = "In eget a mauris quis. Tortor dui tempus quis integer est sit natoque placerat dolor.", Link = {ControllerName = "", ActionName = "", Text = ""}},
                new () { Icon = "images/tools/slack.svg", Text = "Id mollis consectetur congue egestas egestas suspendisse blandit justo.", Link = {ControllerName = "", ActionName = "", Text = ""}},
                new () { Icon = "images/tools/gmail.svg", Text = "Rutrum interdum tortor, sed at nulla. A cursus bibendum elit purus cras praesent.", Link = {ControllerName = "", ActionName = "", Text = ""}},
                new () { Icon = "images/tools/trello.svg", Text = "Congue pellentesque amet, viverra curabitur quam diam scelerisque fermentum urna.", Link = {ControllerName = "", ActionName = "", Text = ""}},
                new () { Icon = "images/tools/mailchimp.svg", Text = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris.", Link = {ControllerName = "", ActionName = "", Text = ""}},
                new () { Icon = "images/tools/dropbox.svg", Text = "Ut in turpis consequat odio diam lectus elementum. Est faucibus blandit platea.", Link = {ControllerName = "", ActionName = "", Text = ""}},
                new () { Icon = "images/tools/evernote.svg", Text = "Faucibus cursus maecenas lorem cursus nibh. Sociis sit risus id. Sit facilisis dolor arcu.", Link = {ControllerName = "", ActionName = "", Text = ""}}
            ]
    };

    public SubscribeViewModel Subscribe { get; set; } = new SubscribeViewModel
    {
        Id = "subscribe",
        Title = "Don't Want to Miss Anything?",
        SubTitle = "Sign up for Newsletters",
        Email = "",
        Image = new (){ ImageUrl = "images/arrows.svg", AltText = "Swirly arrow"},
        Subscribe = 
            [
                new () { Icon = "images/", Text = "Daily Newsletter" },
                new () { Icon = "images/", Text = "Advertising Updates" },
                new () { Icon = "images/", Text = "Week in Review" },
                new () { Icon = "images/", Text = "Event Updates" },
                new () { Icon = "images/", Text = "Startups Weekly" },
                new () { Icon = "images/", Text = "Podcasts" }
            ],
        TermsText = "* Yes, I agree to the  and .",
        Terms = 
            [
                new () { ActionName = "", ControllerName = "", Text = "terms"},
                new () { ActionName = "", ControllerName = "", Text = "privacy policy"}
            ]

    };

}
