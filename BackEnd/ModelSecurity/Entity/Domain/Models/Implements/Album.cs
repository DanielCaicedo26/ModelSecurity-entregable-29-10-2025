using Entity.Domain.Models.Base;


namespace ModelSecurity.Entity.Domain.Models.Implements
{
    public class Album : BaseModelGeneric
    {
        public DateTime? ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; } = string.Empty;

        public int ArtistId { get; set; }

        // Navigation properties
        public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
