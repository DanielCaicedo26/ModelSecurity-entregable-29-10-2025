using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using ModelSecurity.Entity.Domain.Models.Implements;

namespace Data.Services
{
    public class PlaylistSongRepository : DataGeneric<PlaylistSong>, IPlaylistSongRepository
    {
        public PlaylistSongRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<PlaylistSong>> GetAllAsync()
        {
            return await _context.Set<PlaylistSong>()
                        .Include(playlistSong => playlistSong.Playlist)
                        .Include(playlistSong => playlistSong.Song)
                        .Where(playlistSong => playlistSong.IsDeleted == false)
                        .OrderBy(playlistSong => playlistSong.OrderIndex)
                        .ToListAsync();
        }

        public override async Task<IEnumerable<PlaylistSong>> GetDeletes()
        {
            return await _context.Set<PlaylistSong>()
                        .Include(playlistSong => playlistSong.Playlist)
                        .Include(playlistSong => playlistSong.Song)
                        .Where(playlistSong => playlistSong.IsDeleted == true)
                        .OrderBy(playlistSong => playlistSong.OrderIndex)
                        .ToListAsync();
        }

        public override async Task<PlaylistSong?> GetByIdAsync(int id)
        {
            return await _context.Set<PlaylistSong>()
                      .Include(playlistSong => playlistSong.Playlist)
                      .Include(playlistSong => playlistSong.Song)
                      .Where(playlistSong => playlistSong.Id == id)
                      .FirstOrDefaultAsync(playlistSong => playlistSong.IsDeleted == false);
        }
    }
}
