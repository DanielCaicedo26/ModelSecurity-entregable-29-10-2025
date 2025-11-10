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
    public class GenreService : BusinessBasic<GenreSelectDto, GenreDto, Genre>, IGenreService
    {
        private readonly ILogger<GenreService> _logger;
        protected readonly IData<Genre> Data;

        public GenreService(IData<Genre> data, IMapper mapper, ILogger<GenreService> logger) : base(data, mapper)
        {
            Data = data;
            _logger = logger;
        }
    }
}
