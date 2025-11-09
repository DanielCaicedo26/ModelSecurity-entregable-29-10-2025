using Entity.Domain.Models.Base;


namespace ModelSecurity.Entity.Domain.Models.Implements
{
    public class Artist : BaseModelGeneric
    {
        public string Country { get; set; } = string.Empty;
        public DateTime? DebutDate { get; set; }

        // Navigation properties
        public ICollection<Album> Albums { get; set; } = new List<Album>();
        public ICollection<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
    }
}
