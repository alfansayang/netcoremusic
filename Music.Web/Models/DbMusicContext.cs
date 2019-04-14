using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Music.Web.Models
{
    public partial class DbMusicContext : DbContext
    {
        public DbMusicContext()
        {
        }

        public DbMusicContext(DbContextOptions<DbMusicContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artists> Artists { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=localhost;Database=dbmusic;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Artists>(entity =>
            {
                entity.HasKey(e => e.ArtistId);

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.AlbumName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ArtistName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("ImageURL")
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("numeric(10, 2)");

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.SampleUrl)
                    .HasColumnName("SampleURL")
                    .HasMaxLength(200);
            });
        }
    }
}
