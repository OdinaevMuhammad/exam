namespace Domain.Dtos;

public  class AddJobHistory
{
    public int EmployeeId { get; set; }
   public DateTime StartDate { get; set; }
   public DateTime EndDate  { get; set; }
   public int JobId { get; set; }
   public int DepartmentId { get; set; }
   
}
public  class GetJobHistories
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
   public DateTime StartDate { get; set; }
   public DateTime EndDate  { get; set; }
   public string JobTitle { get; set; }
    public string DepartmentName { get; set; }

  
   
   
}