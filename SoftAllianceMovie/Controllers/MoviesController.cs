using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftAllianceMovie.Dtos.MovieDto;
using SoftAllianceMovie.Services.MovieService;

namespace SoftAllianceMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Adds a movie to the database.
        /// </summary>
        /// <param name="addMovieDto">The data required to add a Movie.</param>
        /// <returns>Returns message 'Successfully saved Movie.' if successful, or an error message "An error occur trying to save Movie." if the operation fails.</returns>
        [HttpPost("add-movie")]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieDto addMovieDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var response = await _movieService.AddMovie(addMovieDto);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }           
        }

        [HttpGet("get-movie")]
        public async Task<IActionResult> PreviewDetails([FromQuery] int movieId)
        {
            var response = await _movieService.GetMovie(movieId);
            return Ok(response);
        }

        [HttpPut("update-movie")]
        public async Task<IActionResult> UpdateMovie([FromQuery] int movieId, [FromBody] UpdateMovieDto updateMovieDto)
        {
            var response = await _movieService.UpdateMovie(movieId, updateMovieDto);
            return Ok(response);
        }












    }
}
