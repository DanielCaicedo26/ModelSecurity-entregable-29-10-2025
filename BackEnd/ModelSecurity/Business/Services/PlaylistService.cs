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
    public class PlaylistService : BusinessBasic<PlaylistSelectDto, PlaylistDto, Playlist>, IPlaylistService
    {
        private readonly ILogger<PlaylistService> _logger;
        protected new readonly IPlaylistRepository Data;

        public PlaylistService(IPlaylistRepository data, IMapper mapper, ILogger<PlaylistService> logger) : base(data, mapper)
        {
            Data = data;
            _logger = logger;
        }
    }
}
