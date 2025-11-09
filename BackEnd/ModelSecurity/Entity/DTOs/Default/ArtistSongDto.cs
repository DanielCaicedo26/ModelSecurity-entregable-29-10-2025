using Entity.DTOs.Base;

namespace Entity.DTOs.Default
{
    public class ArtistSongDto : BaseDto
    {
        public int ArtistId { get; set; }
        public int SongId { get; set; }
    }
}
