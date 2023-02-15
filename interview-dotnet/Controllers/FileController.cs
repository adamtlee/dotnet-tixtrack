using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace interview_dotnet.Controllers
{
    [ApiController]
    [Route("api/v1/file")]
    public class FileController : ControllerBase
    {

        /// <summary>
        /// Accepts a file as an IFormFile and reads the contents of the file using a StreamReader.
        /// </summary>
        /// <param name="file">The file to be read.</param>
        /// <returns>
        /// An Ok response with the contents of the file as a string, or an appropriate error message
        /// if an error occurs while reading the file.
        /// </returns>
    
        [HttpPost]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            StringBuilder sb = new StringBuilder();

            using(var reader = new StreamReader(file.OpenReadStream()))
            {
                 while(reader.Peek() >= 0)
                {
                    string line = await reader.ReadLineAsync();
                    sb.Append(line);
                    System.Diagnostics.Debug.WriteLine(line);
                }
            }

            return Ok(sb.ToString());
        }
    }
}

