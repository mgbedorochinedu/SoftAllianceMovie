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
        /// <summary>
        /// Get single Movie record on the database.
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns>Return a single record of movie with list of Genres </returns>
        [HttpGet("get-movie")]
        public async Task<IActionResult> GetMovie([FromQuery] int movieId)
        {
            var response = await _movieService.GetMovie(movieId);
            return Ok(response);
        }


        /// <summary>
        /// Update a movie record.
        /// </summary>
        /// <param name="movieId"></param>
        //// <returns>Returns message 'Movies updated successfully.' if successful, or an error message "An error trying to update Movie" if the operation fails.</returns>
        [HttpPut("update-movie")]
        public async Task<IActionResult> UpdateMovie([FromQuery] int movieId, [FromBody] UpdateMovieDto updateMovieDto)
        {
            var response = await _movieService.UpdateMovie(movieId, updateMovieDto);
            return Ok(response);
        }


        /// <summary>
        /// Delete a movie record.
        /// </summary>
        /// <param name="movieId"></param>
        //// <returns>Returns message 'Movie Deleted successfully.' if successful, or an error message "An error occur trying to Delete Movie." if the operation fails.</returns>
        [HttpDelete("delete-movie/{movieId}")]
        public async Task<IActionResult> DeleteMovie(int movieId)
        {
            var response = await _movieService.DeleteMovie(movieId);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        /// <summary>
        /// Get list of movie records.
        /// </summary>
        /// <param name="movieId"></param>
        //// <returns>Returns message 'Successully get all Movies.' and list of data. </returns>
        [HttpGet("get-all-movies")]
        public async Task<IActionResult> GetAllMovie()
        {
            var response = await _movieService.GetAllMovies();
            return Ok(response);
        }







    }
}
