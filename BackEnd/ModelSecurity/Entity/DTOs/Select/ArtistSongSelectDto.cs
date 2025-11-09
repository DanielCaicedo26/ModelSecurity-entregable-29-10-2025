namespace Entity.DTOs.Select
{
    public class ArtistSongSelectDto
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public int SongId { get; set; }
        public string SongName { get; set; }
    }
}
