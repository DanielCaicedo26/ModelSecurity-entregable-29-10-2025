using Entity.Domain.Models.Base;


namespace ModelSecurity.Entity.Domain.Models.Implements
{
    public class Genre : BaseModelGeneric
    {
        // Navigation properties
        public ICollection<Song> Songs { get; set; } = new List<Song>();
    }
}
