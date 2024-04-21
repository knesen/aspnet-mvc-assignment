using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Models.Sections;
using WebApp.Models.Views;
using WebApp.Services;

namespace WebApp.Controllers;

[Authorize]
public class AccountController(UserManager<UserEntity> userManager, DataContext dataContext) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly DataContext _dataContext = dataContext;
   

   
    
    public async Task<IActionResult> Details()
    {
        var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        var user = await _dataContext.Users.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifier);

        var viewModel = new AccountDetailsViewModel
        {
            BasicInfo = new AccountDetailsBasicInfoModel
            {
                FirstName = user!.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                Phone = user.PhoneNumber,
                Biography = user.Biography,
                ProfileImage = user.ProfileImage,
            },
            AddressInfo = new AccountDetailsAddressInfoModel
            {
                Addressline_1 = user.Address?.AddressLine_1!,
                Addressline_2 = user.Address?.AddressLine_2!,
                PostalCode = user.Address?.PostalCode!,
                City = user.Address?.City!,
            }

             
        };
       

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> BasicInfo(AccountDetailsViewModel viewModel)
    {
        
        if (viewModel != null)
        {
            var user = await _userManager.GetUserAsync(User);
                        
            if (user != null)
            {
                user.FirstName = viewModel.BasicInfo!.FirstName;
                user.LastName = viewModel.BasicInfo!.LastName;
                user.Email = viewModel.BasicInfo!.Email;
                user.PhoneNumber = viewModel.BasicInfo!.Phone;
                user.UserName = viewModel.BasicInfo!.Email;
                user.Biography = viewModel.BasicInfo!.Biography;
                user.ProfileImage = viewModel.BasicInfo.ProfileImage;

                var result = await _userManager.UpdateAsync(user);
                if(result.Succeeded) 
                { 
                    TempData["StatusMessage"] = "Updated basic information successfully.";
                }
                else 
                {
                    TempData["StatusMessage"] = "Unable to save basic information.";
                }
            }
        }
        else
        {
            TempData["StatusMessage"] = "Unable to save basic information.";
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    
                    var errorMessage = error.ErrorMessage;
                    var propertyName = entry.Key;
                    Console.WriteLine($"Validation error for property '{propertyName}': {errorMessage}");
                }
            }
        }

        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> AddressInfo(AccountDetailsViewModel viewModel)
    {
        if (viewModel != null)
        {
            var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var user = await _dataContext.Users.Include(i => i.Address).FirstOrDefaultAsync(x => x.Id == nameIdentifier);
            if (user != null)
            {
                try
                {
                    if (user.Address != null)
                    {
                        user.Address.AddressLine_1 = viewModel.AddressInfo!.Addressline_1;
                        user.Address.AddressLine_2 = viewModel.AddressInfo!.Addressline_2;
                        user.Address.PostalCode = viewModel.AddressInfo!.PostalCode;
                        user.Address.City = viewModel.AddressInfo!.City;
                    }
                    else
                    {
                        user.Address = new AddressEntity
                        {
                            AddressLine_1 = viewModel.AddressInfo!.Addressline_1,
                            AddressLine_2 = viewModel.AddressInfo!.Addressline_2,
                            PostalCode = viewModel.AddressInfo!.PostalCode,
                            City = viewModel.AddressInfo!.City
                        };
                    }

                    _dataContext.Update(user);
                    await _dataContext.SaveChangesAsync();
                    TempData["StatusMessage"] = "Updated address information successfully.";
                }
                catch
                {
                    TempData["StatusMessage"] = "Unable to save address information.";

                }
               
            }
        }
        else
        {
            TempData["StatusMessage"] = "Unable to save address information.";
        }

        return RedirectToAction("Details", "Account");
    }

    [HttpPost]
    public async Task<IActionResult> UploadProfileImage(IFormFile file)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user != null && file != null && file.Length != 0)
        {
            var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/uploads/profiles", fileName);

            using var fs = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fs);

            user.ProfileImage = fileName;
            await _userManager.UpdateAsync(user);
        }
        else
        {
            TempData["StatusMessage"] = "Unable to upload profile image.";
        }

        return RedirectToAction("Details", "Account");
    }
}
