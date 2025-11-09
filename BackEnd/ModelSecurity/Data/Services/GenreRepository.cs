using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using ModelSecurity.Entity.Domain.Models.Implements;

namespace Data.Services
{
    public class GenreRepository : DataGeneric<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Set<Genre>()
                        .Include(genre => genre.Songs)
                        .Where(genre => genre.IsDeleted == false)
                        .ToListAsync();
        }

        public override async Task<IEnumerable<Genre>> GetDeletes()
        {
            return await _context.Set<Genre>()
                        .Include(genre => genre.Songs)
                        .Where(genre => genre.IsDeleted == true)
                        .ToListAsync();
        }

        public override async Task<Genre?> GetByIdAsync(int id)
        {
            return await _context.Set<Genre>()
                      .Include(genre => genre.Songs)
                      .Where(genre => genre.Id == id)
                      .FirstOrDefaultAsync(genre => genre.IsDeleted == false);
        }
    }
}
