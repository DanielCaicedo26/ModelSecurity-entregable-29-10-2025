using AutoMapper;
using Entity.Domain.Models;
using Entity.Domain.Models.Implements;
using Entity.DTOs.Auth;
using Entity.DTOs.Default;
using Entity.DTOs.Select;

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
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
                .ReverseMap();

            CreateMap<Song, SongDto>().ReverseMap();
            CreateMap<Song, SongSelectDto>()
                .ForMember(dest => dest.AlbumName, opt => opt.MapFrom(src => src.Album.Name))
                .ForMember(dest => dest.GenreName, opt => opt.MapFrom(src => src.Genre.Name))
                .ReverseMap();

            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<Genre, GenreSelectDto>().ReverseMap();

            CreateMap<Playlist, PlaylistDto>().ReverseMap();
            CreateMap<Playlist, PlaylistSelectDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username))
                .ReverseMap();

            CreateMap<ArtistSong, ArtistSongDto>().ReverseMap();
            CreateMap<ArtistSong, ArtistSongSelectDto>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name))
                .ForMember(dest => dest.SongName, opt => opt.MapFrom(src => src.Song.Name))
                .ReverseMap();

            CreateMap<PlaylistSong, PlaylistSongDto>().ReverseMap();
            CreateMap<PlaylistSong, PlaylistSongSelectDto>()
                .ForMember(dest => dest.PlaylistName, opt => opt.MapFrom(src => src.Playlist.Name))
                .ForMember(dest => dest.SongName, opt => opt.MapFrom(src => src.Song.Name))
                .ReverseMap();

            //CreateMap<TouristicAttraction, TouristicAttractionApiDto>().ReverseMap();
        }

    }
}
