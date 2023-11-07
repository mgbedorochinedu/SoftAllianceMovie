using SoftAllianceMovie.Dtos.GenreDto;
using SoftAllianceMovie.ServiceResponse;

namespace SoftAllianceMovie.Services.GenreService
{
    public interface IGenreService
    {
        Task<BaseResponse> AddGenre(AddGenreDto addGenreDto);
        Task<BaseResponse> GetAllGenres();
        Task<BaseResponse> DeleteGenre(int genreId);
        Task<BaseResponse> GetGenre(int genreId);
    }
}
