using SoftAllianceMovie.Data;
using SoftAllianceMovie.Dtos.MovieDto;
using SoftAllianceMovie.Models;
using SoftAllianceMovie.ServiceResponse;

namespace SoftAllianceMovie.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _context;

        public MovieService(DataContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse> AddMovie(AddMovieDto addMovieDto)
        {
            try
            {

                Movie movie = new Movie()
                {
                    Name = addMovieDto.Name,
                    Description = addMovieDto.Description,
                    ReleaseDate = addMovieDto.ReleaseDate,
                    Rating = addMovieDto.Rating,
                    TicketPrice = addMovieDto.TicketPrice,
                    Country = addMovieDto.Country,
                    PhotoUrl = addMovieDto.PhotoUrl,
                    CreatedAt = DateTime.UtcNow
                };
                await _context.AddAsync(movie);
                var isSaved = await _context.SaveChangesAsync();
                if (isSaved > 0)
                {
                    return new BaseResponse(true, null, "Successfully saved Movie.");
                }
                else
                {
                    return new BaseResponse(false, null, "An error occur trying to save Movie");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }
        }




    }
}
