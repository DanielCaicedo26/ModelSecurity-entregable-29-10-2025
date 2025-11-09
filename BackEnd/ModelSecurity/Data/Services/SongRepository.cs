using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Domain.Models.Implements;
using Entity.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using ModelSecurity.Entity.Domain.Models.Implements;

namespace Data.Services
{
    public class SongRepository : DataGeneric<Song>, ISongRepository
    {
        public SongRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await _context.Set<Song>()
                        .Include(song => song.Album)
                            .ThenInclude(album => album.Artist)
                        .Include(song => song.Genre)
                        .Include(song => song.ArtistSongs)
                            .ThenInclude(artistSong => artistSong.Artist)
                        .Include(song => song.PlaylistSongs)
                            .ThenInclude(playlistSong => playlistSong.Playlist)
                        .Where(song => song.IsDeleted == false)
                        .ToListAsync();
        }

        public override async Task<IEnumerable<Song>> GetDeletes()
        {
            return await _context.Set<Song>()
                        .Include(song => song.Album)
                            .ThenInclude(album => album.Artist)
                        .Include(song => song.Genre)
                        .Include(song => song.ArtistSongs)
                            .ThenInclude(artistSong => artistSong.Artist)
                        .Include(song => song.PlaylistSongs)
                            .ThenInclude(playlistSong => playlistSong.Playlist)
                        .Where(song => song.IsDeleted == true)
                        .ToListAsync();
        }

        public override async Task<Song?> GetByIdAsync(int id)
        {
            return await _context.Set<Song>()
                      .Include(song => song.Album)
                          .ThenInclude(album => album.Artist)
                      .Include(song => song.Genre)
                      .Include(song => song.ArtistSongs)
                          .ThenInclude(artistSong => artistSong.Artist)
                      .Include(song => song.PlaylistSongs)
                          .ThenInclude(playlistSong => playlistSong.Playlist)
                      .Where(song => song.Id == id)
                      .FirstOrDefaultAsync(song => song.IsDeleted == false);
        }
    }
}
