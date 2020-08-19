using Microsoft.EntityFrameworkCore;

namespace MusicalogApi.Models
{
    public partial class AlbumStoreContext : DbContext
    {
        public AlbumStoreContext()
        {
        }

        public AlbumStoreContext(DbContextOptions<AlbumStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<AlbumInfo> AlbumInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=AlbumStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.Artist)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AlbumInfo>(entity =>
            {
                entity.HasKey(e => e.AlbumId)
                    .HasName("PK__AlbumInf__97B4BE37F37E63F4");

                entity.Property(e => e.AlbumId).ValueGeneratedNever();

                entity.Property(e => e.Label).HasMaxLength(100);

                entity.HasOne(d => d.Album)
                    .WithOne(p => p.AlbumInfo)
                    .HasForeignKey<AlbumInfo>(d => d.AlbumId)
                    //.OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AlbumInfo__Album__276EDEB3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
