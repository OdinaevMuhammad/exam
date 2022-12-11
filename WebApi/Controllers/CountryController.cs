using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CountryController
{
    private CountryService _CountryService;
    public CountryController(CountryService CountryService)
    {
        _CountryService = CountryService;
    }
    

    [HttpGet("GetCountry")]
    public async Task<Response<List<GetCountries>>> GetCountries()
    {
        return  await _CountryService.GetCountries();
    }
       [HttpPost("InsertCountry")]
    public async Task<Response<AddCountry>> InsertCountry(AddCountry country)
    {
        return await _CountryService.InsertCountry(country);
    }

    [HttpPut("UpdateCountry")]
    public async Task<Response<AddCountry>> UpdateCountry(AddCountry country)
    {
        return await _CountryService.UpdateCountry(country);
    }
    [HttpDelete("DeleteCountry")]
    public async Task<Response<string>> DeleteCountry(int id)
    {
        return await _CountryService.DeleteCountry(id);
    }
}