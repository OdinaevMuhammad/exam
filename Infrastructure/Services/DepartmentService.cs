namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
public class DepartmentService
{
    private DataContext _context;

    public DepartmentService(DataContext context)
    {
        _context = context;
    }
    

    public async Task<Response<List<GetDepartments>>> GetDepartments()
    {
        var list = await _context.Departments.Select(c => new GetDepartments()
        {
            DepartmentId = c.DepartmentId,
            DepartmentName = c.DepartmentName,
            City= c.Location.City,
            StreetAddress = c.Location.StreetAddress
        }).ToListAsync();

        return new Response<List<GetDepartments>>(list);
            
    }
    
        
       

    public async Task<Response<AddDepartment>> InsertDepartment(AddDepartment department)
    {
        var newDepartment = new Department()
        {
            DepartmentName = department.DepartmentName,
            Locationid = department.Locationid
        };
         _context.Departments.Add(newDepartment);

         await _context.SaveChangesAsync();

         return new Response<AddDepartment>(department);
    }
        public async Task<Response<AddDepartment>> UpdateDepartment(AddDepartment department)
        {
            var find = await _context.Departments.FindAsync(department.DepartmentId);
            find.DepartmentName = department.DepartmentName;
            find.Locationid = department.Locationid;

            await _context.SaveChangesAsync();

            return new Response<AddDepartment>(department);
        }
      public async Task<Response<string>> DeleteDepartment(int id)
        {      
        var find = await _context.Departments.FindAsync(id);
        _context.Departments.Remove(find);
        await _context.SaveChangesAsync();
           if(find.DepartmentId > 0 )  return new Response<string>("Department deleted successfully");

        
               return new Response<string>(HttpStatusCode.BadRequest, "Department not found");
        }
}
    
