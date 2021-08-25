using Microsoft.AspNetCore.Mvc;
using MongoDBExemplo.Domain.Interfaces.Services;
using MongoDBExemplo.WebApi.Request;
using System.Threading.Tasks;

namespace MongoDBExemplo.WebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _service;

        public AssetController(IAssetService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AssetRequest request)
        {
            var model = request.ToDomain();
            var result = await _service.InsertAsset(model);

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAsset(null);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string ticker)
        {
            var result = await _service.GetAsset(ticker);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]string ticker)
        {
            if (string.IsNullOrEmpty(ticker)) return NoContent();

            var result = await _service.DeleteAsset(ticker);
            return Ok(result);
        }
    }
}