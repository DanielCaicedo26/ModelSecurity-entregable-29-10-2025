using Business.Interfaces.IBusinessImplements;
using Entity.Domain.Enums;
using Entity.DTOs.Default;
using Entity.DTOs.Select;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.ControllersBase.Web.Controllers.BaseController;

namespace Web.Controllers.Implements
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class PlaylistSongController : BaseController<PlaylistSongSelectDto, PlaylistSongDto, IPlaylistSongService>
    {
        public PlaylistSongController(IPlaylistSongService service, ILogger<PlaylistSongController> logger) : base(service, logger)
        {
        }

        protected override async Task<IEnumerable<PlaylistSongSelectDto>> GetAllAsync(GetAllType g)
        {
            var playlistSongs = await _service.GetAllAsync(g);
            if (playlistSongs is null) return null;

            return playlistSongs;
        }

        protected override Task<PlaylistSongSelectDto?> GetByIdAsync(int id) => _service.GetByIdAsync(id);

        protected override Task AddAsync(PlaylistSongDto dto) => _service.CreateAsync(dto);

        protected override Task<bool> UpdateAsync(int id, PlaylistSongDto dto) => _service.UpdateAsync(dto);

        protected override async Task<bool> DeleteAsync(int id, DeleteType deleteType)
        {
            var playlistSong = await _service.GetByIdAsync(id);
            if (playlistSong is null) return false;

            await _service.DeleteAsync(id, deleteType);
            return true;
        }

        protected override Task<bool> RestaureAsync(int id) => _service.RestoreLogical(id);
    }
}
