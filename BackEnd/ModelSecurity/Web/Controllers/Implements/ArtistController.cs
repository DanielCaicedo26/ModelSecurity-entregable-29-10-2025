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
    public class ArtistController : BaseController<ArtistSelectDto, ArtistDto, IArtistService>
    {
        public ArtistController(IArtistService service, ILogger<ArtistController> logger) : base(service, logger)
        {
        }

        protected override async Task<IEnumerable<ArtistSelectDto>> GetAllAsync(GetAllType g)
        {
            var artists = await _service.GetAllAsync(g);
            if (artists is null) return null;

            return artists;
        }

        protected override Task<ArtistSelectDto?> GetByIdAsync(int id) => _service.GetByIdAsync(id);

        protected override Task AddAsync(ArtistDto dto) => _service.CreateAsync(dto);

        protected override Task<bool> UpdateAsync(int id, ArtistDto dto) => _service.UpdateAsync(dto);

        protected override async Task<bool> DeleteAsync(int id, DeleteType deleteType)
        {
            var artist = await _service.GetByIdAsync(id);
            if (artist is null) return false;

            await _service.DeleteAsync(id, deleteType);
            return true;
        }

        protected override Task<bool> RestaureAsync(int id) => _service.RestoreLogical(id);
    }
}
