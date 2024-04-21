using System.ComponentModel.DataAnnotations;
using WebApp.Models.Components;

namespace WebApp.Models.Sections;

public class SubscribeViewModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? SubTitle { get; set; }

    public SubscriberModel Subscriber { get; set; } = null!;

    public ImageViewModel? Image { get; set; }
    public List<ItemListViewModel>? Subscribe { get; set; }
    public string? TermsText { get; set; }
    public List<LinkViewModel>? Terms { get; set; }

}
