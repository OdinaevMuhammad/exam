namespace Domain.Entities;

public class Job
{
    public int jobId { get; set; }
    public string JobTitle { get; set; }
    public int MinSalary { get; set; }
    public int MaxSalary { get; set; }
    public List<Employee> Employees;
    public List<JobHistory> JobHistories;


}