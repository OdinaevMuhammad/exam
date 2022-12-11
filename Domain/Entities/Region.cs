namespace Domain.Entities;

public class Region
{
    public int Regionid { get; set; }
    public string RegionName { get; set; }
    public List<Country> Countries;
}