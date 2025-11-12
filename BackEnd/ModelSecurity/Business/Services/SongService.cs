using AutoMapper;
using Business.Interfaces.IBusinessImplements;
using Business.Repository;
using Data.Interfaces.IDataImplement;
using Entity.Domain.Models.Implements;
using Entity.DTOs.Default;
using Entity.DTOs.Select;
using Microsoft.Extensions.Logging;
using ModelSecurity.Entity.Domain.Models.Implements;

namespace Business.Services
{
    public class SongService : BusinessBasic<SongSelectDto, SongDto, Song>, ISongService
    {
        private readonly ILogger<SongService> _logger;
        protected new readonly ISongRepository Data;

        public SongService(ISongRepository data, IMapper mapper, ILogger<SongService> logger) : base(data, mapper)
        {
            Data = data;
            _logger = logger;
        }
    }
}
