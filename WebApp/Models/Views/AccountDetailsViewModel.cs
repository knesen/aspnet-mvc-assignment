using WebApp.Models.Sections;

namespace WebApp.Models.Views;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";

    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel()
    {
        ProfileImage = "images/profile-image.svg",
        FirstName = "Hans",
        LastName = "Mattin-Lassei",
        Email = "hans@domain.com",
        Phone = "1234567890",
        
    };
    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();
}
