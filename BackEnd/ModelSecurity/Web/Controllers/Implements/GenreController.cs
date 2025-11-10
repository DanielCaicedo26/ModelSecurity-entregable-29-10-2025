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
    public class GenreController : BaseController<GenreSelectDto, GenreDto, IGenreService>
    {
        public GenreController(IGenreService service, ILogger<GenreController> logger) : base(service, logger)
        {
        }

        protected override async Task<IEnumerable<GenreSelectDto>> GetAllAsync(GetAllType g)
        {
            var genres = await _service.GetAllAsync(g);
            if (genres is null) return null;

            return genres;
        }

        protected override Task<GenreSelectDto?> GetByIdAsync(int id) => _service.GetByIdAsync(id);

        protected override Task AddAsync(GenreDto dto) => _service.CreateAsync(dto);

        protected override Task<bool> UpdateAsync(int id, GenreDto dto) => _service.UpdateAsync(dto);

        protected override async Task<bool> DeleteAsync(int id, DeleteType deleteType)
        {
            var genre = await _service.GetByIdAsync(id);
            if (genre is null) return false;

            await _service.DeleteAsync(id, deleteType);
            return true;
        }

        protected override Task<bool> RestaureAsync(int id) => _service.RestoreLogical(id);
    }
}
