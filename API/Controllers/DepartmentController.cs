using API.Models.Domain;
using API.Models.DTOs;
using API.Repsitories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentController(IDepartmentRepository repository) 
        {
         _repository = repository;
        }

        [HttpGet("getAll")]
        public async Task < IActionResult> GetAll()
        {
            var result =await _repository.GetAllDepartment();
            return Ok(result);
        }
        [HttpGet("getAllDepartmentLookup")]
        public async Task<IActionResult> GetAllDepartmentLookup()
        {
            var result = await _repository.GetAllDepartmentLookup();
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =await _repository.GetDepartmentById(id);
            return Ok(result);
        }

        [HttpPost("AddUpdate")]
        public async Task<IActionResult> AddUpdate(Department department)
        {
            var result = await _repository.AddUpdateDepartment(department);
            var status = new Status()
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Save Successefully" : "Error throw Saveing....!"
            };
            return Ok(status);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repository.DeleteDepartment(id);
            var status = new Status()
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Delete Successefully" : "Error throw Deleteing....!"
            };
            return Ok(status);
        }
    }
}
