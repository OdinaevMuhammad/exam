namespace Domain.Entities;

public class JobGrade
{
    public int Id { get; set; }
    public string GradeLevel { get; set; }
    public int LowestSalary { get; set; }
    public int HighestSalary { get; set; }
    
}