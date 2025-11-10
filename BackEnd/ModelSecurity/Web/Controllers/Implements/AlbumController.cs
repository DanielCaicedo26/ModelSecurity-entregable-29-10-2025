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
    public class AlbumController : BaseController<AlbumSelectDto, AlbumDto, IAlbumService>
    {
        public AlbumController(IAlbumService service, ILogger<AlbumController> logger) : base(service, logger)
        {
        }

        protected override async Task<IEnumerable<AlbumSelectDto>> GetAllAsync(GetAllType g)
        {
            var albums = await _service.GetAllAsync(g);
            if (albums is null) return null;

            return albums;
        }

        protected override Task<AlbumSelectDto?> GetByIdAsync(int id) => _service.GetByIdAsync(id);

        protected override Task AddAsync(AlbumDto dto) => _service.CreateAsync(dto);

        protected override Task<bool> UpdateAsync(int id, AlbumDto dto) => _service.UpdateAsync(dto);

        protected override async Task<bool> DeleteAsync(int id, DeleteType deleteType)
        {
            var album = await _service.GetByIdAsync(id);
            if (album is null) return false;

            await _service.DeleteAsync(id, deleteType);
            return true;
        }

        protected override Task<bool> RestaureAsync(int id) => _service.RestoreLogical(id);
    }
}
