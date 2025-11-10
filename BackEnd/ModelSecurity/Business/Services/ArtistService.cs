using AutoMapper;
using Business.Interfaces.IBusinessImplements;
using Business.Repository;
using Data.Interfaces.DataBasic;
using Entity.Domain.Models.Implements;
using Entity.DTOs.Default;
using Entity.DTOs.Select;
using Microsoft.Extensions.Logging;
using ModelSecurity.Entity.Domain.Models.Implements;

namespace Business.Services
{
    public class ArtistService : BusinessBasic<ArtistSelectDto, ArtistDto, Artist>, IArtistService
    {
        private readonly ILogger<ArtistService> _logger;
        protected readonly IData<Artist> Data;

        public ArtistService(IData<Artist> data, IMapper mapper, ILogger<ArtistService> logger) : base(data, mapper)
        {
            Data = data;
            _logger = logger;
        }
    }
}
