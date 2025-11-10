using Business.Interfaces.BusinessBasic;
using Entity.DTOs.Default;
using Entity.DTOs.Select;

namespace Business.Interfaces.IBusinessImplements
{
    public interface IArtistSongService : IBusiness<ArtistSongSelectDto, ArtistSongDto>
    {
    }
}
