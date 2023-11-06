using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftAllianceMovie.Dtos.GenreDto;
using SoftAllianceMovie.Services.GenreService;

namespace SoftAllianceMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        /// <summary>
        /// Adds a Genre to the database.
        /// </summary>
        /// <param name="addGenreDto">The data required to add a movie.</param>
        /// <returns>Returns message 'Successfully saved Genre.' if successful, or an error message "An error occur trying to save Genre." if the operation fails.</returns>
        [HttpPost("add-genre")]
        public async Task<IActionResult> AddGenre([FromBody] AddGenreDto addGenreDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = await _genreService.AddGenre(addGenreDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
