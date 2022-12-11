namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
public class JobService
{
    private DataContext _context;

    public JobService(DataContext context)
    {
        _context = context;
    }
    

    public async Task<Response<List<AddJob>>> GetJobs()
    {
        var list = await _context.Jobs.Select(c => new AddJob()
        {
            JobId = c.jobId,
            JobTitle = c.JobTitle,
            MinSalary= c.MinSalary,
            MaxSalary = c.MaxSalary
        }).ToListAsync();

        return new Response<List<AddJob>>(list);
            
    }
    
        
       

    public async Task<Response<AddJob>> InsertJob(AddJob job)
    {
        var newJob = new Job()
        {
      
            JobTitle = job.JobTitle,
            MinSalary= job.MinSalary,
            MaxSalary = job.MaxSalary
        };
         _context.Jobs.Add(newJob);

         await _context.SaveChangesAsync();

         return new Response<AddJob>(job);
    }
        public async Task<Response<AddJob>> UpdateJob(AddJob job)
        {
            var find = await _context.Jobs.FindAsync(job.JobId);
            find.JobTitle = job.JobTitle;
            find.MinSalary = job.MinSalary;
            find.MaxSalary = job.MaxSalary;

            await _context.SaveChangesAsync();

            return new Response<AddJob>(job);
        }
      public async Task<Response<string>> DeleteJob(int id)
        {      
        var find = await _context.Jobs.FindAsync(id);
        _context.Jobs.Remove(find);
        await _context.SaveChangesAsync();
           if(find.jobId > 0 )  return new Response<string>("Job deleted successfully");

        
               return new Response<string>(HttpStatusCode.BadRequest, "Job not found");
        }
}
    
