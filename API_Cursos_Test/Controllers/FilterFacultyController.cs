using Amazon.Lambda.Core;
using API_Cursos_Test.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Cursos_Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilterFacultyController(IFilterCursos _repos) : ControllerBase
    {
         [HttpGet()]
            public async Task<IActionResult> GetFaculties()
            {
                var result = await _repos.GetFacultyList();
                return Ok(result);
            }
}
}
