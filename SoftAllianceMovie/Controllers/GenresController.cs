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
        /// <param name="addGenreDto">The data required to add a Genre.</param>
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


        /// <summary>
        /// Get list of genres records.
        /// </summary>
        //// <returns>Returns message 'Successully get all Genres.' and list of data. </returns>
        [HttpGet("get-all-genres")]
        public async Task<IActionResult> GetAllGenres()
        {
            var response = await _genreService.GetAllGenres();
            return Ok(response);
        }


        /// <summary>
        /// Delete a genre record.
        /// </summary>
        /// <param name="genreId"></param>
        //// <returns>Returns message 'Genre Deleted successfully.' if successful, or an error message "An error occur trying to Delete Genre." if the operation fails.</returns>
        [HttpDelete("delete-genre/{genreId}")]
        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            var response = await _genreService.DeleteGenre(genreId);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        /// <summary>
        /// Get single Genre record on the database.
        /// </summary>
        /// <param name="genreId"></param>
        /// <returns>Return a single record of genre </returns>
        [HttpGet("get-genre")]
        public async Task<IActionResult> GetGenre([FromQuery] int genreId)
        {
            var response = await _genreService.GetGenre(genreId);
            return Ok(response);
        }

    }
}
