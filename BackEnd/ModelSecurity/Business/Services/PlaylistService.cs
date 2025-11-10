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
    public class PlaylistService : BusinessBasic<PlaylistSelectDto, PlaylistDto, Playlist>, IPlaylistService
    {
        private readonly ILogger<PlaylistService> _logger;
        protected readonly IData<Playlist> Data;

        public PlaylistService(IData<Playlist> data, IMapper mapper, ILogger<PlaylistService> logger) : base(data, mapper)
        {
            Data = data;
            _logger = logger;
        }
    }
}
