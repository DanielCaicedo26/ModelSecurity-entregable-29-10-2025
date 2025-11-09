namespace Entity.DTOs.Select
{
    public class PlaylistSelectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsPublic { get; set; }
    }
}
