using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Components;

public class SubscriberModel
{
    [Required]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "Email address", Prompt = "Your Email")]
    public string Email { get; set; } = null!;
    public bool IsSubscribed { get; set; } = false;
}
