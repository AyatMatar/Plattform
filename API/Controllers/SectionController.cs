using API.Models.DTOs;
using API.Repsitories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly ISectionRepository _sectionRepository;
        public SectionController(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _sectionRepository.GetById(id);
            if(result == null)
            {
                var status = new Status
                {
                    StatusCode = 0,
                    StatusMessage = "Section Not Found......!"
                };
                return Ok(status);
            }
            return Ok(result);
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _sectionRepository.GetAll();
            return Ok(result);
        }

        [HttpDelete("deleteById/{id}")]
        public async Task<IActionResult> DleteById (int id)
        {
            var result = await _sectionRepository.Delete(id);
            var status = new Status
            {
                StatusCode = result?1:0,
                StatusMessage =result? "Delete Successfully": "Error throw Deleting......!"
            };
            return Ok(status);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SectionAddUpdateDto section)
        {
            var result = await _sectionRepository.AddUpdate(section);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Add Successfully" : "Error throw Adding......!"
            };
            return Ok(status);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(SectionAddUpdateDto section)
        {
            var result = await _sectionRepository.AddUpdate(section);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Update Successfully" : "Error throw Updating......!"
            };
            return Ok(status);
        }

        [HttpGet("getSectionByCourseId/{courseId}")]
        public async Task <IActionResult> GetSectionByCourseId(int courseId)
        {
            var result =await _sectionRepository.GetSectionByCourseId(courseId);
            return Ok(result);
        }
    }
}
