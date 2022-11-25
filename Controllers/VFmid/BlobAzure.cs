using Microsoft.AspNetCore.Mvc;
using ms.Models.Dto;
using ms.Services;

namespace ms.Controllers.VFmid
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobAzureController : ControllerBase
    {
        private readonly IAzureStorage _storage;

        public BlobAzureController(IAzureStorage storage)
        {
            _storage = storage;
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Get()
        {
            List<BlobDto>? files = await _storage.ListAsync();
            return StatusCode(StatusCodes.Status200OK, files);
        }

        [HttpPost("Subir")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            BlobResponseDto? response = await _storage.UploadAsync(file);
            if (response.Error == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response.Status);
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
        }

        [HttpGet("Descarga/{Archivo}")]
        public async Task<IActionResult> Download(string Archivo)
        {
            BlobDto? file = await _storage.DownloadAsync(Archivo);
            if (file == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Archivo no encontrado: {Archivo}");
            }
            else
            {
                return File(file.Content, file.ContentType, file.Name);
            }
        }

        [HttpDelete("Eliminar/{Archivo}")]
        public async Task<IActionResult> Delete(string Archivo)
        {
            BlobResponseDto response = await _storage.DeleteAsync(Archivo);
            if (response.Error == true)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, response.Status);
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, response.Status);
            }
        }
    }
}