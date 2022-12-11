namespace Domain.Entities;

public class Country
{
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public int Regionid { get; set; }
    public Region Region;
    public List<Location> Locations;
}

