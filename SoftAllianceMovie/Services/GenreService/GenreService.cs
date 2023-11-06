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
    }
}
