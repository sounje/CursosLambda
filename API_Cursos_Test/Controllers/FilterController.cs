using API_Cursos_Test.Interfaces;
using API_Cursos_Test.Model;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Cursos_Test.Controllers
{
    [Route("[controller]")]
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
        public async Task<IActionResult> GetCareerList([FromBody] IdFacultyModel id)
        {
            Guid idGuid = Guid.Parse(id.Id);
            var result = await _repos.GetCareerList(idGuid);
            return Ok(result);
        }

       
    }
}
