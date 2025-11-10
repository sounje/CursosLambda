using API_Cursos_Test.Interfaces;
using API_Cursos_Test.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Cursos_Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CursosSearchController(ICursosSearch _repos) : ControllerBase
    {

        [HttpPost("GetCursosBySearch")]
        public async Task<IActionResult> GetCursosBySearch([FromBody] FilterModel model)
        {
            var result = await _repos.GetCursosBySearch(model);
            return Ok(result);
        }

    }
}
