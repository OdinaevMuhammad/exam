using Microsoft.AspNetCore.Http;

namespace Domain.Dtos;

public class AddLocation
{
    public int LocationId { get; set; }
    public string StreetAddress { get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public int CountryId { get; set; }
}


public class GetLocations
{
    public int LocationId { get; set; }
    public string StreetAddress { get; set; }
    public int PostalCode { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string CountryName { get; set; }

}
