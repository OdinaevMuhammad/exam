using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController
{
    private EmployeeService _EmployeeService;
    public EmployeeController(EmployeeService EmployeeService)
    {
        _EmployeeService = EmployeeService;
    }
    

    [HttpGet("GetEmployee")]
    public async Task<Response<List<GetEmployees>>> GetEmployees()
    {
        return  await _EmployeeService.GetEmployees();
    }
       [HttpPost("InsertEmployee")]
    public async Task<Response<AddEmployee>> InsertEmployee([FromForm] AddEmployee employee)
    {
        return await _EmployeeService.InsertEmployee(employee);
    }

    [HttpPut("UpdateEmployee")]
    public async Task<Response<AddEmployee>> Update([FromForm] AddEmployee employee)
    {
        return await _EmployeeService.UpdateEmployee(employee);
    }
    [HttpDelete("DeleteEmployee")]
    public async Task<Response<string>> DeleteEmployee(int id)
    {
        return await _EmployeeService.DeleteEmployee(id);
    }
}