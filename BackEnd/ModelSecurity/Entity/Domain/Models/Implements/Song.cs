using Entity.Domain.Models.Base;


namespace ModelSecurity.Entity.Domain.Models.Implements
{
    public class Song : BaseModelGeneric
    {
        public int DurationSeconds { get; set; }
        public string AudioUrl { get; set; } = string.Empty;

        public int AlbumId { get; set; }
        public int GenreId { get; set; }

        // Navigation properties
        public Album Album { get; set; }
        public Genre Genre { get; set; }
        public ICollection<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
    }
}
