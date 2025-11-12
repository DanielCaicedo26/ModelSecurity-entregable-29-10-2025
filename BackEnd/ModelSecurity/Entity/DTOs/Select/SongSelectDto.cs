namespace Entity.DTOs.Select
{
    public class SongSelectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationSeconds { get; set; }
        public string AudioUrl { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }

        // Objetos completos anidados para incluir toda la información
        public AlbumSelectDto Album { get; set; }
        public GenreSelectDto Genre { get; set; }
    }
}
