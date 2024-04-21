using Infrastructure.Entities;
using WebApp.Models.Sections;

namespace WebApp.Models.Views;

public class AccountDetailsViewModel
{
    public string Title { get; set; } = "Account Details";

    public AccountDetailsBasicInfoModel BasicInfo { get; set; } = new AccountDetailsBasicInfoModel();
   
    public AccountDetailsAddressInfoModel AddressInfo { get; set; } = new AccountDetailsAddressInfoModel();
}
