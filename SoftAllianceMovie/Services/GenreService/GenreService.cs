using Microsoft.EntityFrameworkCore;
using SoftAllianceMovie.Data;
using SoftAllianceMovie.Dtos.GenreDto;
using SoftAllianceMovie.Models;
using SoftAllianceMovie.ServiceResponse;

namespace SoftAllianceMovie.Services.GenreService
{
    public class GenreService : IGenreService
    {
        private readonly DataContext _context;
        public GenreService(DataContext context)
        {
            _context = context;
        }


        public async Task<BaseResponse> AddGenre(AddGenreDto addGenreDto)
        {
            try
            {
                Genre genre = new Genre()
                {
                    GenreName = addGenreDto.GenreName,
                    MovieId = addGenreDto.MovieId,
                    CreatedAt = DateTime.UtcNow
                };
                await _context.AddAsync(genre);
                var isSaved = await _context.SaveChangesAsync();
                if (isSaved > 0)
                {
                    return new BaseResponse(true, null, "Successfully saved Genre");
                }
                else
                {
                    return new BaseResponse(false, null, "An error occur trying to save Genre");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }
        }


        public async Task<BaseResponse> GetAllGenres()
        {
            List<Genre> dbGenres = await _context.Genres.ToListAsync();
            return new BaseResponse(true, dbGenres, "Successully get all Genres.");
        }


        public async Task<BaseResponse> DeleteGenre(int genreId)
        {
            try
            {
                Genre genre = _context.Genres.FirstOrDefault(g => genreId == genreId);

                if (genre == null)
                {
                    return new BaseResponse(true, null, $"No Genre with GenreId: {genreId} found.");
                }
                _context.Genres.Remove(genre);
                var isSaved = await _context.SaveChangesAsync();
                if (isSaved > 0)
                {
                    return new BaseResponse(true, null, "Genre Deleted successfully.");
                }
                else
                {
                    return new BaseResponse(false, null, "An error occur trying to Delete Genre.");
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }
        }


        public async Task<BaseResponse> GetGenre(int genreId)
        {
            try
            {
                var dbGenre = _context.Genres.Where(x => x.GenreId == genreId).Select(genre => new GetGenreDto()
                {
                    GenreName = genre.GenreName,
                }).FirstOrDefault();

                if (dbGenre == null)
                    return new BaseResponse(false, null, $"No Genre with GenreId: {genreId} found.");
                return new BaseResponse(true, dbGenre, "Succesfully fetch data");
            }
            catch (Exception ex)
            {
                return new BaseResponse(false, ex, "An unexpected error occurred.");
            }


        }
    }
}
