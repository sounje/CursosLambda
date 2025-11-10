using API_Cursos_Test.Interfaces;
using API_Cursos_Test.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Cursos_Test.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoadDataController(ILoadDataExcel _repos) : ControllerBase
    {
        [HttpPost("SendDataJson")]
        public async Task<IActionResult> SendDataJson([FromBody] DataToSend model)
        {
            var result = await _repos.SendDataJson(model );
            return Ok(result);
        }

        [HttpPost("SendDataExcel")]
        public async Task<IActionResult> SendDataExcel([FromForm] UploadRequest model)
        {
            if(model.ImportFile is null)
                return BadRequest("No file uploaded.");

            var result = await _repos.SendDataExcel(model);
            return Ok(result);
        }
    }   
}
