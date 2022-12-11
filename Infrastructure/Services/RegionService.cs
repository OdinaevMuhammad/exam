namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
public class RegionService
{
    private DataContext _context;

    public RegionService(DataContext context)
    {
        _context = context;
    }
    

    public async Task<Response<List<AddRegion>>> GetCountries()
    {
        var list = await _context.Regions.Select(c => new AddRegion()
        {
            Regionid = c.Regionid,
            RegionName = c.RegionName
        }).ToListAsync();

        return new Response<List<AddRegion>>(list);
            
    }
    
    
    public async Task<Response<AddRegion>> InsertRegion(AddRegion region)
    {
        var newRegion = new Region()
        {
            RegionName = region.RegionName
        };
         _context.Regions.Add(newRegion);

         await _context.SaveChangesAsync();

         return new Response<AddRegion>(region);
    }
        public async Task<Response<AddRegion>> UpdateRegion(AddRegion region)
        {
            var find = await _context.Regions.FindAsync(region.Regionid);
            find.RegionName = region.RegionName;
            await _context.SaveChangesAsync();

            return new Response<AddRegion>(region);
        }
      public async Task<Response<string>> DeleteRegion(int id)
        {      
        var find = await _context.Regions.FindAsync(id);
        _context.Regions.Remove(find);
        await _context.SaveChangesAsync();
           if(find.Regionid > 0 )  return new Response<string>("Region deleted successfully");

        
               return new Response<string>(HttpStatusCode.BadRequest, "Region not found");
        }
}
    
