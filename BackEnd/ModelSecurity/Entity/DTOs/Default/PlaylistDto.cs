using Entity.DTOs.Base;

namespace Entity.DTOs.Default
{
    public class PlaylistDto : BaseGenericDto
    {
        public int UserId { get; set; }
        public bool IsPublic { get; set; }
    }
}
