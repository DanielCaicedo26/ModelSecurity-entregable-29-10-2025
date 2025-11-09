using Entity.DTOs.Base;

namespace Entity.DTOs.Default
{
    public class ArtistDto : BaseGenericDto
    {
        public string Country { get; set; }
        public DateTime? DebutDate { get; set; }
    }
}
