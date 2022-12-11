namespace Domain.Entities;

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public int Locationid { get; set; }
    public List<Employee> Employees;
    public Location Location;
    public List<JobHistory> JobHistories;
}

