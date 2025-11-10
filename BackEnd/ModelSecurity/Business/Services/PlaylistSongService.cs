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
    public class PlaylistSongService : BusinessBasic<PlaylistSongSelectDto, PlaylistSongDto, PlaylistSong>, IPlaylistSongService
    {
        private readonly ILogger<PlaylistSongService> _logger;
        protected readonly IData<PlaylistSong> Data;

        public PlaylistSongService(IData<PlaylistSong> data, IMapper mapper, ILogger<PlaylistSongService> logger) : base(data, mapper)
        {
            Data = data;
            _logger = logger;
        }
    }
}
