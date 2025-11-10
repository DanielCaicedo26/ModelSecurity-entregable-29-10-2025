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
    public class PlaylistController : BaseController<PlaylistSelectDto, PlaylistDto, IPlaylistService>
    {
        public PlaylistController(IPlaylistService service, ILogger<PlaylistController> logger) : base(service, logger)
        {
        }

        protected override async Task<IEnumerable<PlaylistSelectDto>> GetAllAsync(GetAllType g)
        {
            var playlists = await _service.GetAllAsync(g);
            if (playlists is null) return null;

            return playlists;
        }

        protected override Task<PlaylistSelectDto?> GetByIdAsync(int id) => _service.GetByIdAsync(id);

        protected override Task AddAsync(PlaylistDto dto) => _service.CreateAsync(dto);

        protected override Task<bool> UpdateAsync(int id, PlaylistDto dto) => _service.UpdateAsync(dto);

        protected override async Task<bool> DeleteAsync(int id, DeleteType deleteType)
        {
            var playlist = await _service.GetByIdAsync(id);
            if (playlist is null) return false;

            await _service.DeleteAsync(id, deleteType);
            return true;
        }

        protected override Task<bool> RestaureAsync(int id) => _service.RestoreLogical(id);
    }
}
