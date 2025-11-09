using Entity.Domain.Models.Base;


namespace ModelSecurity.Entity.Domain.Models.Implements
{
    public class ArtistSong : BaseModel
    {
        public int ArtistId { get; set; }
        public int SongId { get; set; }

        // Navigation properties
        public Artist Artist { get; set; }
        public Song Song { get; set; }
    }
}
