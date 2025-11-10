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
    public class ArtistSongController : BaseController<ArtistSongSelectDto, ArtistSongDto, IArtistSongService>
    {
        public ArtistSongController(IArtistSongService service, ILogger<ArtistSongController> logger) : base(service, logger)
        {
        }

        protected override async Task<IEnumerable<ArtistSongSelectDto>> GetAllAsync(GetAllType g)
        {
            var artistSongs = await _service.GetAllAsync(g);
            if (artistSongs is null) return null;

            return artistSongs;
        }

        protected override Task<ArtistSongSelectDto?> GetByIdAsync(int id) => _service.GetByIdAsync(id);

        protected override Task AddAsync(ArtistSongDto dto) => _service.CreateAsync(dto);

        protected override Task<bool> UpdateAsync(int id, ArtistSongDto dto) => _service.UpdateAsync(dto);

        protected override async Task<bool> DeleteAsync(int id, DeleteType deleteType)
        {
            var artistSong = await _service.GetByIdAsync(id);
            if (artistSong is null) return false;

            await _service.DeleteAsync(id, deleteType);
            return true;
        }

        protected override Task<bool> RestaureAsync(int id) => _service.RestoreLogical(id);
    }
}
