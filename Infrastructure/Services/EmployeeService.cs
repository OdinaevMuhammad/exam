namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Hosting;

public class EmployeeService
{
    private DataContext _context;

   private readonly IWebHostEnvironment _hostEnvironment;

    public EmployeeService(DataContext context,IWebHostEnvironment env)
    {
        _context = context;
        _hostEnvironment = env;
    }

    public async Task<Response<List<GetEmployees>>> GetEmployees()
    {
        
    
        var list = await _context.Employees.Select(c => new GetEmployees()
        {
            EmployeeId = c.EmployeeId,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            PhoneNumber = c.PhoneNumber,
            ManagerId = c.ManagerId,
            Commision = c.Commision  ,
            Salary = c.Salary,
            JobId = c.JobId,
            HireDate = c.HireDate,
            DepartmentName = c.Department.DepartmentName,
            profileImage =  c.ProfileImage.FileName


        }).ToListAsync();

        return new Response<List<GetEmployees>>(list);
            
    }
    
        
       

    public async Task<Response<AddEmployee>> InsertEmployee(AddEmployee employee)
    {
                 var path = Path.Combine(_hostEnvironment.WebRootPath, "images",employee.profileImage.FileName);
            
            using (var stream = File.Create(path))
            {
                await employee.profileImage.CopyToAsync(stream);
            }
        var newEmployee = new Employee()
        {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            ManagerId = employee.ManagerId,
            Commision = employee.Commision  ,
            Salary = employee.Salary,
            JobId = employee.JobId,
            HireDate = employee.HireDate

        };
         _context.Employees.Add(newEmployee);

         await _context.SaveChangesAsync();

         return new Response<AddEmployee>(employee);
    }
        public async Task<Response<AddEmployee>> UpdateEmployee(AddEmployee employee)
        {
  
            var find = await _context.Employees.FindAsync(employee.EmployeeId);
            find.EmployeeId = employee.EmployeeId;
            find.FirstName = employee.FirstName;
            find.LastName = employee.LastName;
            find.Email = employee.Email;
            find.PhoneNumber = employee.PhoneNumber;
            find.ManagerId = employee.ManagerId;
            find.Commision = employee.Commision ;
            find.Salary = employee.Salary;
            find.JobId = employee.JobId;
            find.HireDate = employee.HireDate;
            find.ProfileImage = employee.profileImage;

            await _context.SaveChangesAsync();

            return new Response<AddEmployee>(employee);
        }
      public async Task<Response<string>> DeleteEmployee(int id)
        {      
        var find = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(find);
        await _context.SaveChangesAsync();
           if(find.EmployeeId > 0 )  return new Response<string>("Employee deleted successfully");

        
               return new Response<string>(HttpStatusCode.BadRequest, "Employee not found");
        }
}

    
