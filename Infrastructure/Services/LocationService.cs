namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
public class Locationservice
{
    private DataContext _context;

    public Locationservice(DataContext context)
    {
        _context = context;
    }
    

    public async Task<Response<List<GetLocations>>> GetLocations()
    {
        var list = await _context.Locations.Select(c => new GetLocations()
        {
            LocationId = c.LocationId,
            PostalCode = c.PostalCode,
            StateProvince = c.StateProvince,
            StreetAddress = c.StreetAddress,
            City = c.City,
            CountryName = c.Country.CountryName
        }).ToListAsync();

        return new Response<List<GetLocations>>(list);
            
    }
    
        
       

    public async Task<Response<AddLocation>> InsertLocation(AddLocation location)
    {
        var newLocation = new Location()
        {
            PostalCode = location.PostalCode,
            StateProvince = location.StateProvince,
            StreetAddress = location.StreetAddress,
            City = location.City,
            CountryId = location.CountryId
        };
         _context.Locations.Add(newLocation);

         await _context.SaveChangesAsync();

         return new Response<AddLocation>(location);
    }
        public async Task<Response<AddLocation>> UpdateLocation(AddLocation location)
        {
            var find = await _context.Locations.FindAsync(location.LocationId);
           find.PostalCode = location.PostalCode;
            find.StateProvince = location.StateProvince;
           find. StreetAddress = location.StreetAddress;
            find.City = location.City;
            find.CountryId = location.CountryId;

            await _context.SaveChangesAsync();

            return new Response<AddLocation>(location);
        }
      public async Task<Response<string>> DeleteLocation(int id)
        {      
        var find = await _context.Locations.FindAsync(id);
        _context.Locations.Remove(find);
        await _context.SaveChangesAsync();
           if(find.LocationId > 0 )  return new Response<string>("Location deleted successfully");

        
               return new Response<string>(HttpStatusCode.BadRequest, "Location not found");
        }
}
    
