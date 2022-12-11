namespace Domain.Dtos;

public class AddCountry
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public int Regionid { get; set; }
}


public class GetCountries
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public string RegionName { get; set; }

}