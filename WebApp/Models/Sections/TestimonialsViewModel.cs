using WebApp.Models.Components;

namespace WebApp.Models.Sections;

public class TestimonialsViewModel
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public ImageViewModel? Image { get; set; }
    public List<TestimonialModel>? Items { get; set; }

}
