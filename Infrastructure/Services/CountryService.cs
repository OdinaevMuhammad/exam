namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
public class CountryService
{
    private DataContext _context;

    public CountryService(DataContext context)
    {
        _context = context;
    }
    

    public async Task<Response<List<GetCountries>>> GetCountries()
    {
        var list = await _context.Countries.Select(c => new GetCountries()
        {
            CountryId = c.CountryId,
            CountryName = c.CountryName,
            RegionName= c.Region.RegionName
        }).ToListAsync();

        return new Response<List<GetCountries>>(list);
            
    }
    
        
       

    public async Task<Response<AddCountry>> InsertCountry(AddCountry country)
    {
        var newCountry = new Country()
        {
            CountryName = country.CountryName,
            Regionid = country.Regionid
        };
         _context.Countries.Add(newCountry);

         await _context.SaveChangesAsync();

         return new Response<AddCountry>(country);
    }
        public async Task<Response<AddCountry>> UpdateCountry(AddCountry country)
        {
            var find = await _context.Countries.FindAsync(country.CountryId);
            find.CountryName = country.CountryName;
            find.Regionid = country.Regionid;

            await _context.SaveChangesAsync();

            return new Response<AddCountry>(country);
        }
      public async Task<Response<string>> DeleteCountry(int id)
        {      
        var find = await _context.Countries.FindAsync(id);
        _context.Countries.Remove(find);
        await _context.SaveChangesAsync();
           if(find.CountryId > 0 )  return new Response<string>("Country deleted successfully");

        
               return new Response<string>(HttpStatusCode.BadRequest, "Country not found");
        }
}
    
