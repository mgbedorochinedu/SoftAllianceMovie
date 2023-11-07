using SoftAllianceMovie.Dtos.MovieDto;
using SoftAllianceMovie.ServiceResponse;

namespace SoftAllianceMovie.Services.MovieService
{
    public interface IMovieService
    {
        Task<BaseResponse> AddMovie(AddMovieDto addMovieDto);
        Task<BaseResponse> GetMovie(int movieId);
        Task<BaseResponse> UpdateMovie(int movieId, UpdateMovieDto updateMovieDto);
    }
}
