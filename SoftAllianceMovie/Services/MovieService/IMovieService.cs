using SoftAllianceMovie.Dtos.MovieDto;
using SoftAllianceMovie.ServiceResponse;

namespace SoftAllianceMovie.Services.MovieService
{
    public interface IMovieService
    {
        Task<BaseResponse> AddMovie(AddMovieDto addMovieDto);
    }
}
