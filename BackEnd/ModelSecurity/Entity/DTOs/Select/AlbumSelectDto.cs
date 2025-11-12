namespace Entity.DTOs.Select
{
    public class AlbumSelectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string CoverImageUrl { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }

        // Objeto completo del artista
        public ArtistSelectDto Artist { get; set; }
    }
}
