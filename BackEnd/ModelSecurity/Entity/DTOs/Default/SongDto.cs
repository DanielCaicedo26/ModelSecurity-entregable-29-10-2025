using Entity.DTOs.Base;

namespace Entity.DTOs.Default
{
    public class SongDto : BaseGenericDto
    {
        public int DurationSeconds { get; set; }
        public string AudioUrl { get; set; }
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
    }
}
