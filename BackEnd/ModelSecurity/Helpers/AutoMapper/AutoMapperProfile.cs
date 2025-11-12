using AutoMapper;
using Entity.Domain.Models;
using Entity.Domain.Models.Implements;
using Entity.DTOs.Auth;
using Entity.DTOs.Default;
using Entity.DTOs.Select;
using ModelSecurity.Entity.Domain.Models.Implements;


namespace Helpers.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Rol, RolSelectDto>().ReverseMap();
            CreateMap<Rol, RolDto>().ReverseMap();

            CreateMap<User, UserSelectDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();


            CreateMap<RolUser, RolUserDto>().ReverseMap();
            CreateMap<RolUser, RolUserSelectDto>().ReverseMap();

            CreateMap<Form, FormSelectDto>().ReverseMap();
            CreateMap<Form, FormDto>().ReverseMap();


            CreateMap<Module, ModuleSelectDto>().ReverseMap();
            CreateMap<Module, ModuleDto>().ReverseMap();


            CreateMap<Permission, PermissionSelectDto>().ReverseMap();
            CreateMap<Permission, PermissionDto>().ReverseMap();


            CreateMap<Person, PersonSelectDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<FormModule, FormModuleSelectDto>().ReverseMap();
            CreateMap<FormModule, FormModuleDto>().ReverseMap();

            CreateMap<RolFormPermission, RolFormPermissionDto>().ReverseMap();
            CreateMap<RolFormPermission, RolFormPermissionSelectDto>().ReverseMap();

            CreateMap<FormModule, FormModuleDto>().ReverseMap();
            CreateMap<FormModule, FormModuleSelectDto>().ReverseMap();

            CreateMap<RegisterUserDto, User>();
            CreateMap<RegisterUserDto, Person>();

            // Music entities mappings
            CreateMap<Artist, ArtistDto>().ReverseMap();
            CreateMap<Artist, ArtistSelectDto>().ReverseMap();

            CreateMap<Album, AlbumDto>().ReverseMap();
            CreateMap<Album, AlbumSelectDto>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist != null ? src.Artist.Name : null))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Artist))
                .ReverseMap();

            CreateMap<Song, SongDto>().ReverseMap();
            CreateMap<Song, SongSelectDto>()
                .ForMember(dest => dest.AlbumName, opt => opt.MapFrom(src => src.Album != null ? src.Album.Name : null))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre != null ? src.Genre.Name : null))
                .ForMember(dest => dest.Album, opt => opt.MapFrom(src => src.Album))
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
                .ReverseMap();

            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Genre, GenreSelectDto>().ReverseMap();

            CreateMap<Playlist, PlaylistDto>().ReverseMap();
            CreateMap<Playlist, PlaylistSelectDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null ? src.User.Username : string.Empty))

                .ReverseMap();

            CreateMap<ArtistSong, ArtistSongDto>().ReverseMap();
            CreateMap<ArtistSong, ArtistSongSelectDto>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist != null ? src.Artist.Name : null))
                .ForMember(dest => dest.SongName, opt => opt.MapFrom(src => src.Song != null ? src.Song.Name : null))
                .ReverseMap();

            CreateMap<PlaylistSong, PlaylistSongDto>().ReverseMap();
            CreateMap<PlaylistSong, PlaylistSongSelectDto>()
                .ForMember(dest => dest.PlaylistName, opt => opt.MapFrom(src => src.Playlist != null ? src.Playlist.Name : null))
                .ForMember(dest => dest.SongName, opt => opt.MapFrom(src => src.Song != null ? src.Song.Name : null))
                .ForMember(dest => dest.Song, opt => opt.MapFrom(src => src.Song))
                .ReverseMap();

            
        }

    }
}
