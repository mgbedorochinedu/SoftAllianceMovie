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











    }
}
