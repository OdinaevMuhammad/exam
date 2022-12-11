namespace Domain.Dtos;

public class AddDepartment
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int Locationid { get; set; }
}

public class GetDepartments
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }


}