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
    public class ArtistSongService : BusinessBasic<ArtistSongSelectDto, ArtistSongDto, ArtistSong>, IArtistSongService
    {
        private readonly ILogger<ArtistSongService> _logger;
        protected readonly IData<ArtistSong> Data;

        public ArtistSongService(IData<ArtistSong> data, IMapper mapper, ILogger<ArtistSongService> logger) : base(data, mapper)
        {
            Data = data;
            _logger = logger;
        }
    }
}
