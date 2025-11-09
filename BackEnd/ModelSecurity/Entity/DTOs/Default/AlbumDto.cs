using Entity.DTOs.Base;

namespace Entity.DTOs.Default
{
    public class AlbumDto : BaseGenericDto
    {
        public DateTime? ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
        public int ArtistId { get; set; }
    }
}
