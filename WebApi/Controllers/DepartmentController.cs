using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController
{
    private DepartmentService _DepartmentService;
    public DepartmentController(DepartmentService DepartmentService)
    {
        _DepartmentService = DepartmentService;
    }
    

    [HttpGet("GetDepartment")]
    public async Task<Response<List<GetDepartments>>> GetDepartments()
    {
        return  await _DepartmentService.GetDepartments();
    }
       [HttpPost("InsertDepartment")]
    public async Task<Response<AddDepartment>> InsertDepartment(AddDepartment department)
    {
        return await _DepartmentService.InsertDepartment(department);
    }

    [HttpPut("UpdateDepartment")]
    public async Task<Response<AddDepartment>> Update(AddDepartment department)
    {
        return await _DepartmentService.UpdateDepartment(department);
    }
    [HttpDelete("DeleteDepartment")]
    public async Task<Response<string>> DeleteDepartment(int id)
    {
        return await _DepartmentService.DeleteDepartment(id);
    }
}