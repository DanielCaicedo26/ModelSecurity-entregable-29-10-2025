using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using ModelSecurity.Entity.Domain.Models.Implements;

namespace Data.Services
{
    public class ArtistRepository : DataGeneric<Artist>, IArtistRepository
    {
        public ArtistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _context.Set<Artist>()
                        .Include(artist => artist.Albums)
                        .Include(artist => artist.ArtistSongs)
                            .ThenInclude(artistSong => artistSong.Song)
                        .Where(artist => artist.IsDeleted == false)
                        .ToListAsync();
        }

        public override async Task<IEnumerable<Artist>> GetDeletes()
        {
            return await _context.Set<Artist>()
                        .Include(artist => artist.Albums)
                        .Include(artist => artist.ArtistSongs)
                            .ThenInclude(artistSong => artistSong.Song)
                        .Where(artist => artist.IsDeleted == true)
                        .ToListAsync();
        }

        public override async Task<Artist?> GetByIdAsync(int id)
        {
            return await _context.Set<Artist>()
                      .Include(artist => artist.Albums)
                      .Include(artist => artist.ArtistSongs)
                          .ThenInclude(artistSong => artistSong.Song)
                      .Where(artist => artist.Id == id)
                      .FirstOrDefaultAsync(artist => artist.IsDeleted == false);
        }
    }
}
