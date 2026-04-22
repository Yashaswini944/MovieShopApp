using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetHighestGrossingMovies();
        Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId);
        Task<Movie> GetMovieDetails(int id);
    }
}
