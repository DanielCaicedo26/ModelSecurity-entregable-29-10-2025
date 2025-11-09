using Entity.DTOs.Base;

namespace Entity.DTOs.Default
{
    public class PlaylistSongDto : BaseDto
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public int OrderIndex { get; set; }
    }
}
