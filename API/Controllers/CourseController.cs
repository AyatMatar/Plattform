using API.Models.Domain;
using API.Models.DTOs;
using API.Repsitories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _repository;
        public CourseController(ICourseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("getCourseById/{id}")]
        public async Task<IActionResult> GetCourseById( int id)
        {
            var result =await _repository.GetById(id);

            if(result == null)
            {
                var status = new Status
                {
                    StatusCode = 0,
                    StatusMessage = "Course Not Found ....!"
                };

                return Ok(status);
            }
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllCourses() 
        {
            var result =await _repository.GetAll();
            return Ok(result);
        }

        [HttpPost("addCourse")]
        public async Task <IActionResult> AddCourse(CourseDto course)
        {
            var result =await _repository.AddUpdate(course);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Add Successefully" : "Error throw Adding....!"
            };

            return Ok(status);
        }

        [HttpPut("updateCourse")]
        public async Task < IActionResult > UpdateCourse(CourseDto course)
        {
            var result = await _repository.AddUpdate(course);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Update Successefully" : "Error throw Updating....!"
            };

            return Ok(status);

        }

        [HttpDelete("deleteCourse/{id}")]
        public async Task< IActionResult >DeleteCourse(int id)
        {
            var result = await _repository.Delete(id);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Delete Successefully" : "Error throw Deleteing....!"
            };

            return Ok(status);

        }

        [HttpGet("getCoursesByDepartmentId/{departmentId}")]
        public async Task<IActionResult> GetCoursesByDepartmentId(int departmentId)
        {
            var result = await _repository.GetCoursesByDepartmentId(departmentId);
            return Ok(result);
        }
    }
}
