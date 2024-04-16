namespace WebApp.Models.Components;

public class FeatureModel
{
    public string? Icon { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public LinkViewModel Link { get; set; } = new LinkViewModel();

}
