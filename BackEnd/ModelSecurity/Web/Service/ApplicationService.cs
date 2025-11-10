using Business.Custom;
using Business.Interfaces.IBusinessImplements;
using Business.Interfaces.IBusinessImplements.Auth;
using Business.Services;
using Business.Services.Auth;
using Data.Interfaces.DataBasic;
using Data.Interfaces.IDataImplement;
using Data.Interfaces.IDataImplement.Auth;
using Data.Repository;
using Data.Services;
using Data.Services.Auth;
using Helpers.AutoMapper;
using ModelSecurity.Infrastructure.Cookies.Implements;

namespace Web.Service
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IRolUserService, RolUserService>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IFormModuleService, FormModuleService>();
            services.AddScoped<IRolFormPermissionService, RolFormPermissionService>();

            // Music services
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<ISongService, SongService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IPlaylistService, PlaylistService>();
            services.AddScoped<IArtistSongService, ArtistSongService>();
            services.AddScoped<IPlaylistSongService, PlaylistSongService>();

            //Jwt
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IToken, TokenBusiness>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IAuthCookieFactory, AuthCookieFactory>();


            services.AddHttpContextAccessor(); 

            // Data genérica y repositorios
            services.AddScoped(typeof(IData<>), typeof(DataGeneric<>));
            services.AddScoped<IRolUserRepository, RolUserRepository>();
            services.AddScoped<IFormModuleRepository, FormModuleRepository>();
            services.AddScoped<IRolFormPermissionRepository, RolFormPermissionRepository>();

            // Music repositories
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IPlaylistRepository, PlaylistRepository>();
            services.AddScoped<IArtistSongRepository, ArtistSongRepository>();
            services.AddScoped<IPlaylistSongRepository, PlaylistSongRepository>();

            services.AddScoped<IUserRepository, UserRepository>();


            return services;
        }
    }
}
