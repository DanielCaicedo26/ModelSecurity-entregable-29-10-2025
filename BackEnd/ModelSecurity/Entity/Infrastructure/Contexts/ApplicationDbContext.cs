using Entity.Domain.Interfaces;
using Entity.Domain.Models.Auth;
using Entity.Domain.Models.Implements;
using ModelSecurity.Entity.Domain.Models.Implements;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Entity.Infrastructure.Contexts
{
    public class    ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        private readonly IAuditService _auditService;
        private readonly IHttpContextAccessor _http;

        public ApplicationDbContext(
             DbContextOptions<ApplicationDbContext> options,
             IConfiguration configuration,
             IHttpContextAccessor httpContextAccessor
         ) : base(options)
        {
            _configuration = configuration;
            _http = httpContextAccessor;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        ///<summary>
        ///Implementación DBSet
        ///</summary>

        public DbSet<User> Users {  get; set; }
        public DbSet<Person> Persons {  get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<RolUser> RolUsers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public DbSet<Form> Forms { get; set; }
        public DbSet<Domain.Models.Implements.Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolFormPermission> RolFormPermissions { get; set; }
        public DbSet<FormModule> FormModules { get; set; }

        // Music entities
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<ArtistSong> ArtistSongs { get; set; }
        public DbSet<PlaylistSong> PlaylistSongs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Person)
                .WithOne(p => p.User)
                .HasForeignKey<User>(u => u.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurar relaciones de música para evitar cascadas múltiples en SQL Server
            modelBuilder.Entity<ArtistSong>()
                .HasOne(a_s => a_s.Song)
                .WithMany(s => s.ArtistSongs)
                .HasForeignKey(a_s => a_s.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PlaylistSong>()
                .HasOne(ps => ps.Song)
                .WithMany(s => s.PlaylistSongs)
                .HasForeignKey(ps => ps.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
