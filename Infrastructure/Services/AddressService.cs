using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class AddressService(AddressRepository repository)
{
    private readonly AddressRepository _repository = repository;

    public async Task<ResponseResult> GetOrCreateAddressAsync(string addressLine_1, string postalCode, string city)
    {
        try
        {
            var result = await GetAddressAsync(addressLine_1, postalCode, city);
            if (result.StatusCode == StatusCode.NOT_FOUND)
            {
                result = await CreateAddressAsync(addressLine_1, postalCode, city);
            }
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }

    public async Task<ResponseResult> CreateAddressAsync(string addressLine_1, string postalCode, string city)
    {
        try
        {
            var exists = await _repository.AlreadyExistsAsync(x => x.AddressLine_1 == addressLine_1 && x.PostalCode == postalCode && x.City == city);
            if (exists == null)
            {
                var result = await _repository.CreateOneAsync(AddressFactory.Create(addressLine_1, postalCode, city));
                if (result.StatusCode == StatusCode.OK)
                {
                    return ResponseFactory.Ok(AddressFactory.Create((AddressEntity)result.ContentResult!));
                }
                else
                {
                    return result;
                }
            }
                return exists;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
    public async Task<ResponseResult> GetAddressAsync(string addressLine_1, string postalCode, string city)
    {
        try
        {
            var result = await _repository.GetOneAsync(x => x.AddressLine_1 == addressLine_1 && x.PostalCode == postalCode && x.City == city);
            return result;
        }
        catch (Exception ex) { return ResponseFactory.Error(ex.Message); }
    }
}
