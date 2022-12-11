using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RegionController
{
    private RegionService _RegionService;
    public RegionController(RegionService RegionService)
    {
        _RegionService = RegionService;
    }
    

    [HttpGet("GetRegion")]
    public async Task<Response<List<AddRegion>>> GetCountries()
    {
        return  await _RegionService.GetCountries();
    }
       [HttpPost("InsertRegion")]
    public async Task<Response<AddRegion>> InsertRegion( AddRegion Region)
    {
        return await _RegionService.InsertRegion(Region);
    }

    [HttpPut("UpdateRegion")]
    public async Task<Response<AddRegion>> UpdateRegion(AddRegion Region)
    {
        return await _RegionService.UpdateRegion(Region);
    }
    [HttpDelete("DeleteRegion")]
    public async Task<Response<string>> DeleteRegion(int id)
    {
        return await _RegionService.DeleteRegion(id);
    }
}