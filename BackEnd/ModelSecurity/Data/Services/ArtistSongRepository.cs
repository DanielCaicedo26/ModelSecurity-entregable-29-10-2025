using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using ModelSecurity.Entity.Domain.Models.Implements;

namespace Data.Services
{
    public class ArtistSongRepository : DataGeneric<ArtistSong>, IArtistSongRepository
    {
        public ArtistSongRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<ArtistSong>> GetAllAsync()
        {
            return await _context.Set<ArtistSong>()
                        .Include(artistSong => artistSong.Artist)
                        .Include(artistSong => artistSong.Song)
                        .Where(artistSong => artistSong.IsDeleted == false)
                        .ToListAsync();
        }

        public override async Task<IEnumerable<ArtistSong>> GetDeletes()
        {
            return await _context.Set<ArtistSong>()
                        .Include(artistSong => artistSong.Artist)
                        .Include(artistSong => artistSong.Song)
                        .Where(artistSong => artistSong.IsDeleted == true)
                        .ToListAsync();
        }

        public override async Task<ArtistSong?> GetByIdAsync(int id)
        {
            return await _context.Set<ArtistSong>()
                      .Include(artistSong => artistSong.Artist)
                      .Include(artistSong => artistSong.Song)
                      .Where(artistSong => artistSong.Id == id)
                      .FirstOrDefaultAsync(artistSong => artistSong.IsDeleted == false);
        }
    }
}
