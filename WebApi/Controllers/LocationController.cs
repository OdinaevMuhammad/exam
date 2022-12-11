using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController
{
    private Locationservice _LocationService;
    public LocationController(Locationservice LocationService)
    {
        _LocationService = LocationService;
    }
    

    [HttpGet("GetLocation")]
    public async Task<Response<List<GetLocations>>> GetLocations()
    {
        return  await _LocationService.GetLocations();
    }
       [HttpPost("InsertLocation")]
    public async Task<Response<AddLocation>> InsertLocation( AddLocation location)
    {
        return await _LocationService.InsertLocation(location);
    }

    [HttpPut("UpdateLocation")]
    public async Task<Response<AddLocation>> Update(AddLocation Location)
    {
        return await _LocationService.UpdateLocation(Location);
    }
    [HttpDelete("DeleteLocation")]
    public async Task<Response<string>> DeleteLocation(int id)
    {
        return await _LocationService.DeleteLocation(id);
    }
}