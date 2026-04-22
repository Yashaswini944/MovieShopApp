using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            return await _dbContext.Movies
            .OrderByDescending(m => m.Reviews.Count())
                .Take(30)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetHighestGrossingMovies()
        {
            return await _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(30)
                .ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            return await _dbContext.MovieGenres
                .Where(g => g.GenreId == genreId)
                .Select(g => g.Movie)
                .ToListAsync();
        }

        public async Task<Movie> GetMovieDetails(int id)
        {
            return await _dbContext.Movies
                .Include(m => m.Genres).ThenInclude(g => g.Genre)
                .Include(m => m.Trailers)
                .Include(m => m.Casts).ThenInclude(mc => mc.Cast)
                .Include(m => m.Crews).ThenInclude(mc => mc.Crew)
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
