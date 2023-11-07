using Microsoft.EntityFrameworkCore;
using SoftAllianceMovie.Data;
using SoftAllianceMovie.Dtos.GenreDto;
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
                    return new BaseResponse(false, null, "An error occur trying to save Movie.");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }
        }


        public async Task<BaseResponse> GetMovie(int movieId)
        {
            try
            {
                var dbMovie = _context.Movies.Where(x => x.MovieId == movieId).Select(movie => new GetMovieDto()
                {
                    Name = movie.Name,
                    Description = movie.Description,
                    ReleaseDate = movie.ReleaseDate,
                    Rating = movie.Rating,
                    TicketPrice = movie.TicketPrice,
                    Country = movie.Country,
                    PhotoUrl = movie.PhotoUrl,
                }).FirstOrDefault();
                if (dbMovie == null)
                    return new BaseResponse(false, null, $"No Movie with MovieId: {movieId} found.");

                var genres = _context.Genres.Where(x => x.MovieId == movieId).Select(genre => new GetGenreDto
                {
                    GenreName = genre.GenreName,
                }).ToList();

                if (!genres.Any())
                    return new BaseResponse(false, null, $"No Genre linked with MovieId: {movieId} found.");

                var data = new { dbMovie, genres };

                return new BaseResponse(true, data, "Succesfully fetch data");

            }
            catch (Exception ex)
            {
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }
        }
            public async Task<BaseResponse> UpdateMovie(int movieId, UpdateMovieDto updateMovieDto)
            {
                try
                {
                    var dbMovie = _context.Movies.FirstOrDefault(x => x.MovieId == movieId);
                    if (dbMovie == null)
                        return new BaseResponse(false, null, $"No Movie with MovieId: {movieId} found.");

                    dbMovie.Name = updateMovieDto.Name ?? dbMovie.Name;
                    dbMovie.Description = updateMovieDto.Description ?? dbMovie.Description;
                    dbMovie.ReleaseDate = updateMovieDto.ReleaseDate;
                    dbMovie.Rating = updateMovieDto.Rating ;
                    dbMovie.TicketPrice = updateMovieDto.TicketPrice;
                    dbMovie.Country = updateMovieDto.Country ?? dbMovie.Country;
                    dbMovie.PhotoUrl = updateMovieDto.PhotoUrl ?? dbMovie.PhotoUrl;
                    dbMovie.UpdatedAt = DateTime.UtcNow;

                    _context.Update(dbMovie);
                    var isSaved = await _context.SaveChangesAsync();
                    if (isSaved > 0)
                        return new BaseResponse(true, null, "Movies updated successfully");
                    return new BaseResponse(false, null, "An error trying to update Movie");
                }
                catch (Exception ex)
                {
                    return new BaseResponse(false, ex, "An unexpected error occurred.");
                }
            }


        public async Task<BaseResponse> DeleteMovie(int movieId)
        {
            try
            {
                Movie movie =  _context.Movies.FirstOrDefault(m => m.MovieId == movieId);

                if (movie == null)
                {
                    return new BaseResponse(true, null, $"No Movie with Movie Id: {movieId} found.");
                }
                _context.Movies.Remove(movie);
                var isSaved = await _context.SaveChangesAsync();
                if (isSaved > 0)
                {
                    return new BaseResponse(true, null, "Movie Deleted successfully.");
                }
                else
                {
                    return new BaseResponse(false, null, "An error occur trying to Delete Movie.");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }
        }


        public async Task<BaseResponse> GetAllMovies()
        {
            List<Movie> dbMovies = await _context.Movies.ToListAsync();
            return new BaseResponse(true, dbMovies, "Successully get all Movies.");
        }






    }
}

