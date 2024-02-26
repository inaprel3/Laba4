using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace Laba4.Controllers
{
    [ApiController]
    [Route("")]
    public class LibraryController : ControllerBase
    {
        [HttpGet("Library")]
        public IActionResult GetLibrary()
        {
            return Ok("Welcome to the Library!");
        }

        [HttpGet("Library/Books")]
        public IActionResult GetBooks()
        {
            var booksJson = System.IO.File.ReadAllText("BooksConfig.json");
            var books = JsonSerializer.Deserialize<Books>(booksJson);
            return Ok(books);
        }

        [HttpGet("Library/Profile")]
        public IActionResult GetUserProfile(int? id)
        {
            if (id.HasValue && id >= 0 && id <= 5)
            {
                var profileJson = System.IO.File.ReadAllText($"ProfileConfig{id}.json");
                var userProfile = JsonSerializer.Deserialize<Profile>(profileJson);
                return Ok(userProfile);
            }
            else
            {
                var defaultProfileJson = System.IO.File.ReadAllText("ProfileConfig.json");
                var defaultUserProfile = JsonSerializer.Deserialize<Profile>(defaultProfileJson);
                return Ok(defaultUserProfile);
            }
        }
    }
}