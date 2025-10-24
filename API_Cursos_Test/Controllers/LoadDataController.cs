using API_Cursos_Test.Interfaces;
using API_Cursos_Test.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Cursos_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadDataController(ILoadDataExcel _repos) : ControllerBase
    {
        [HttpPost("SendDataExcel")]
        public async Task<IActionResult> SendDataExcel([FromBody] DataToSend model)
        {
            var result = await _repos.SendDataExcel(model );
            return Ok(result);
        }
    }
}
