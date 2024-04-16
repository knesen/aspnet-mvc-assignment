using WebApp.Models.Components;

namespace WebApp.Models.Sections;

public class ManageViewModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public ImageViewModel? Image {  get; set; }
    public List<ItemListViewModel>? List { get; set; }
    public LinkViewModel? Link { get; set; }

}
