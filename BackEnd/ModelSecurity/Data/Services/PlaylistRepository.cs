using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using ModelSecurity.Entity.Domain.Models.Implements;

namespace Data.Services
{
    public class PlaylistRepository : DataGeneric<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Playlist>> GetAllAsync()
        {
            return await _context.Set<Playlist>()
                        .Include(playlist => playlist.User)
                        .Include(playlist => playlist.PlaylistSongs)
                            .ThenInclude(playlistSong => playlistSong.Song)
                        .Where(playlist => playlist.IsDeleted == false)
                        .ToListAsync();
        }

        public override async Task<IEnumerable<Playlist>> GetDeletes()
        {
            return await _context.Set<Playlist>()
                        .Include(playlist => playlist.User)
                        .Include(playlist => playlist.PlaylistSongs)
                            .ThenInclude(playlistSong => playlistSong.Song)
                        .Where(playlist => playlist.IsDeleted == true)
                        .ToListAsync();
        }

        public override async Task<Playlist?> GetByIdAsync(int id)
        {
            return await _context.Set<Playlist>()
                      .Include(playlist => playlist.User)
                      .Include(playlist => playlist.PlaylistSongs)
                          .ThenInclude(playlistSong => playlistSong.Song)
                      .Where(playlist => playlist.Id == id)
                      .FirstOrDefaultAsync(playlist => playlist.IsDeleted == false);
        }
    }
}
