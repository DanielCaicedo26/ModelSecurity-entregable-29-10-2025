using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using ModelSecurity.Entity.Domain.Models.Implements;

namespace Data.Services
{
    public class AlbumRepository : DataGeneric<Album>, IAlbumRepository
    {
        public AlbumRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Set<Album>()
                        .Include(album => album.Artist)
                        .Include(album => album.Songs)
                        .Where(album => album.IsDeleted == false)
                        .ToListAsync();
        }

        public override async Task<IEnumerable<Album>> GetDeletes()
        {
            return await _context.Set<Album>()
                        .Include(album => album.Artist)
                        .Include(album => album.Songs)
                        .Where(album => album.IsDeleted == true)
                        .ToListAsync();
        }

        public override async Task<Album?> GetByIdAsync(int id)
        {
            return await _context.Set<Album>()
                      .Include(album => album.Artist)
                      .Include(album => album.Songs)
                      .Where(album => album.Id == id)
                      .FirstOrDefaultAsync(album => album.IsDeleted == false);
        }
    }
}
