using API_Cursos_Test.Interfaces;
using API_Cursos_Test.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Cursos_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController(IFilterCursos _repos) : ControllerBase
    {
        [HttpGet("GetFaculties")]
        public async Task<IActionResult> GetFaculties()
        {
            var result = await _repos.GetFacultyList();
            return Ok(result);
        }

        [HttpPost("GetCareers")]
        public async Task<IActionResult> GetCareerList([FromBody] Guid id)
        {
            var result = await _repos.GetCareerList(id);
            return Ok(result);
        }

       
    }
}
