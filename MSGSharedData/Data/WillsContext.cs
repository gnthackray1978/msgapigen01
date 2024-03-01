using Microsoft.EntityFrameworkCore;
using MSGSharedData.Domain.Entities.Persistent.Wills;

namespace MSGSharedData.Data
{
    public partial class WillsContext : DbContext
    {
        public string ConnectionString { get; set; }

        public WillsContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public WillsContext(DbContextOptions<WillsContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<LincsWills> LincsWills { get; set; }

        public virtual DbSet<NorfolkWills> NorfolkWills { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString, sqlServerOptions => sqlServerOptions.CommandTimeout(60));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NorfolkWillsRaw>(entity =>
            {
                entity.ToTable("NorfolkWillsRaw", "Wills");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<NorfolkWills>(entity =>
            {
                entity.ToTable("NorfolkWills", "Wills");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Aliases).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Collection).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.DateString).HasMaxLength(500).IsRequired(false);

                entity.Property(e => e.Description).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.FirstName).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Occupation).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Place).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Reference).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Surname).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Url).IsUnicode(false).IsRequired(false);
            });

            modelBuilder.Entity<LincsWills>(entity =>
            {
                entity.ToTable("LincsWills", "Wills");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Aliases).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Collection).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.DateString).HasMaxLength(500).IsRequired(false);

                entity.Property(e => e.Description).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.FirstName).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Occupation).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Place).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Reference).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Surname).IsUnicode(false).IsRequired(false);

                entity.Property(e => e.Url).IsUnicode(false).IsRequired(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

}
