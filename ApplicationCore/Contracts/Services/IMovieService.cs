using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        Task<MovieDetailsModel> GetMovieDetails(int id);

        Task<IEnumerable<MovieCardModel>> GetTopRatedMovies();
        Task<IEnumerable<MovieCardModel>> GetHighestGrossingMovies();
        Task<IEnumerable<MovieCardModel>> GetMoviesByGenre(int genreId);

        Task<IEnumerable<MovieCardModel>> GetAllMovies();
    }
}
