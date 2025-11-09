using Entity.Domain.Models.Base;


namespace ModelSecurity.Entity.Domain.Models.Implements
{
    public class PlaylistSong : BaseModel
    {
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public int OrderIndex { get; set; }

        // Navigation properties
        public Playlist Playlist { get; set; }
        public Song Song { get; set; }
    }
}
