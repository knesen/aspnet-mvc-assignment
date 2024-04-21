using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Components;

public class SubscriberModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Your Email")]
    public string Email { get; set; } = null!;
    public bool IsSubscribed { get; set; } = false;
    //public bool DailyNewsletter { get; set; }
    //public bool AdvertisingUpdates { get; set; }
    //public bool WeekinReview { get; set; }
    //public bool EventUpdates { get; set; }
    //public bool StartupsWeekly { get; set; }
    //public bool Podcasts { get; set; }
}
