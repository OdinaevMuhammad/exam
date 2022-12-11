using System.ComponentModel.DataAnnotations;
namespace Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
public  class JobHistory
{
    [Key]
    public int EmployeeId { get; set; }
   public DateTime StartDate { get; set; }
   public DateTime EndDate  { get; set; }
   public int JobId { get; set; }
   public int DepartmentId { get; set; }
   public Department Department;
   public Employee Employee;
   public Job Job;

}
