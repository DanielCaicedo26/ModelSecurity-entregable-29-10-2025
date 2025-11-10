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
    public class SongController : BaseController<SongSelectDto, SongDto, ISongService>
    {
        public SongController(ISongService service, ILogger<SongController> logger) : base(service, logger)
        {
        }

        protected override async Task<IEnumerable<SongSelectDto>> GetAllAsync(GetAllType g)
        {
            var songs = await _service.GetAllAsync(g);
            if (songs is null) return null;

            return songs;
        }

        protected override Task<SongSelectDto?> GetByIdAsync(int id) => _service.GetByIdAsync(id);

        protected override Task AddAsync(SongDto dto) => _service.CreateAsync(dto);

        protected override Task<bool> UpdateAsync(int id, SongDto dto) => _service.UpdateAsync(dto);

        protected override async Task<bool> DeleteAsync(int id, DeleteType deleteType)
        {
            var song = await _service.GetByIdAsync(id);
            if (song is null) return false;

            await _service.DeleteAsync(id, deleteType);
            return true;
        }

        protected override Task<bool> RestaureAsync(int id) => _service.RestoreLogical(id);
    }
}
