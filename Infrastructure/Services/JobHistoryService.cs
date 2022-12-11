namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
public class JobHistoryService
{
    private DataContext _context;

    public JobHistoryService(DataContext context)
    {
        _context = context;
    }
    

    public async Task<Response<List<GetJobHistories>>> GetJobHistory()
    {
        var list = await _context.JobHistories.Select(c => new GetJobHistories()
        {
            EmployeeId = c.EmployeeId,
            FirstName = c.Employee.FirstName,
            LastName = c.Employee.LastName,
            JobTitle= c.Job.JobTitle,
            DepartmentName = c.Department.DepartmentName,
            StartDate = c.StartDate,
            EndDate = c.EndDate
        }).ToListAsync();

        return new Response<List<GetJobHistories>>(list);
            
    }
    
        
       

    public async Task<Response<AddJobHistory>> InsertJobHistory(AddJobHistory jobhistory)
    {
        var newJobHistory = new JobHistory()
        {
             EmployeeId = jobhistory.EmployeeId,
            StartDate = jobhistory.StartDate,
            EndDate = jobhistory.EndDate,
            JobId = jobhistory.JobId,
            DepartmentId = jobhistory.DepartmentId
        };
         _context.JobHistories.Add(newJobHistory);

         await _context.SaveChangesAsync();

         return new Response<AddJobHistory>(jobhistory);
    }
        public async Task<Response<AddJobHistory>> UpdateJobHistory(AddJobHistory jobhistory)
        {
            var find = await _context.JobHistories.FindAsync(jobhistory.EmployeeId);
             find.EmployeeId = jobhistory.EmployeeId;
            find.StartDate = jobhistory.StartDate;
            find.EndDate = jobhistory.EndDate;
            find.JobId = jobhistory.JobId;
            find.DepartmentId = jobhistory.DepartmentId;

            await _context.SaveChangesAsync();

            return new Response<AddJobHistory>(jobhistory);
        }
      public async Task<Response<string>> DeleteJobHistory(int id)
        {      
        var find = await _context.JobHistories.FindAsync(id);
        _context.JobHistories.Remove(find);
        await _context.SaveChangesAsync();
           if(find.EmployeeId > 0 )  return new Response<string>("JobHistory deleted successfully");

        
               return new Response<string>(HttpStatusCode.BadRequest, "JobHistory not found");
        }
}
    
