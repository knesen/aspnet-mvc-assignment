using WebApp.Models.Components;

namespace WebApp.Models.Sections;

public class SwitchViewModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? Icon { get; set; }
    public ImageViewModel DarkSwitchImage { get; set; } = null!;
    public ImageViewModel LightSwitchImage { get; set; } = null!;


}
