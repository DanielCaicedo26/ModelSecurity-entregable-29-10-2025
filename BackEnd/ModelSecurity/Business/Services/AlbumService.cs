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
    public class AlbumService : BusinessBasic<AlbumSelectDto, AlbumDto, Album>, IAlbumService
    {
        private readonly ILogger<AlbumService> _logger;
        protected readonly IData<Album> Data;

        public AlbumService(IData<Album> data, IMapper mapper, ILogger<AlbumService> logger) : base(data, mapper)
        {
            Data = data;
            _logger = logger;
        }
    }
}
