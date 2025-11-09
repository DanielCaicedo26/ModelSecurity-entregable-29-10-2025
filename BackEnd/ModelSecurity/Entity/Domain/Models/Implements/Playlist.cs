using Entity.Domain.Models.Base;
using Entity.Domain.Models.Implements;


namespace ModelSecurity.Entity.Domain.Models.Implements
{
    public class Playlist : BaseModelGeneric
    {
        public int UserId { get; set; }
        public bool IsPublic { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
    }
}
