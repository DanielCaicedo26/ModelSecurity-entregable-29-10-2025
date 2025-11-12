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
    public class ArtistSongService : BusinessBasic<ArtistSongSelectDto, ArtistSongDto, ArtistSong>, IArtistSongService
    {
        private readonly ILogger<ArtistSongService> _logger;
        protected new readonly IArtistSongRepository Data;

        public ArtistSongService(IArtistSongRepository data, IMapper mapper, ILogger<ArtistSongService> logger) : base(data, mapper)
        {
            Data = data;
            _logger = logger;
        }
    }
}
