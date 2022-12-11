namespace Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

public class Employee
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber  { get; set; }
    public int DepartmentId { get; set; }
    public int ManagerId { get; set; }
    public string Commision { get; set; }
    public int Salary { get; set; }
    public int JobId { get; set; }
    public DateTime HireDate { get; set; }
        public Department Department;
    public Job Job;
    public List<JobHistory> JobHistories;
    [NotMapped]    
    public IFormFile ProfileImage { get; set; }

}
