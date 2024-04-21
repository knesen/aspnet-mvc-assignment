using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;    
    public string? ProfileImage { get; set; } = "default-profile-image.png";
    public string? Biography { get; set; }
    public DateTime? Created { get; set; }
    public DateTime? Modified {  get; set; }
    
    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }

}

