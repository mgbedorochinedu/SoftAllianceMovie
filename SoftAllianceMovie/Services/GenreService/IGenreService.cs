using SoftAllianceMovie.Dtos.GenreDto;
using SoftAllianceMovie.ServiceResponse;

namespace SoftAllianceMovie.Services.GenreService
{
    public interface IGenreService
    {
        Task<BaseResponse> AddGenre(AddGenreDto addGenreDto);
    }
}
