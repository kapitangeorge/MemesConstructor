using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MemesConstructorWebApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IHostEnvironment _environment;
        public ImageController(IHostEnvironment environment)
        {
            _environment = environment;   
        }

        [HttpPost("{folder}")]
        
        public async Task<IActionResult> Post(string folder, [FromForm]IFormFile image)
        {
            var folderPath = Path.Combine(_environment.ContentRootPath, "wwwroot","Images", folder);

            if (!Directory.Exists(folderPath))
                return BadRequest("Incorrect folder name");

            if (image == null || image.Length == 0)
                return BadRequest("Upload a file");

            string extension = Path.GetExtension(image.FileName);

            string[] allowedExtension = { ".jpg", ".png", ".bmp" };

            if (!allowedExtension.Contains(extension))
                return BadRequest("File is not valid image");

            string newFileName = $"{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(folderPath, newFileName);

            using(var filestream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {

                await image.CopyToAsync(filestream);
            }

            return Ok($"{folder}/{newFileName}");
        }
    }
}
