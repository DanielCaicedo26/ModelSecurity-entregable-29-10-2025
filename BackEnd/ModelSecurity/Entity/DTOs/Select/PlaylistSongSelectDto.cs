namespace Entity.DTOs.Select
{
    public class PlaylistSongSelectDto
    {
        public int Id { get; set; }
        public int PlaylistId { get; set; }
        public string PlaylistName { get; set; }
        public int SongId { get; set; }
        public string SongName { get; set; }
        public int OrderIndex { get; set; }
    }
}
