using WebApp.Models.Components;

namespace WebApp.Models.Sections;

public class ToolsViewModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public List<FeatureModel>? List { get; set; }

}
