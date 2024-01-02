using Api.Entities.Places;
using ConfigHelper;
using Microsoft.EntityFrameworkCore;

namespace Api.DB
{
    public partial class PlacesContext : DbContext
    {
        public string ConnectionString { get; set; }

        public PlacesContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public PlacesContext(DbContextOptions<PlacesContext> options)
            : base(options)
        {
        }
       
        public virtual DbSet<Places> Places { get; set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Places>(entity =>
            {
                entity.ToTable("Places", "UKP");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bua11cd)
                    .HasColumnName("bua11cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ctry15nm)
                    .HasColumnName("ctry15nm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cty15cd)
                    .HasColumnName("cty15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cty15nm)
                    .HasColumnName("cty15nm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ctyhistnm)
                    .HasColumnName("ctyhistnm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ctyltnm)
                    .HasColumnName("ctyltnm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descnm)
                    .HasColumnName("descnm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eer15cd)
                    .HasColumnName("eer15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Eer15nm)
                    .HasColumnName("eer15nm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fid)
                    .HasColumnName("FID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Grid1km)
                    .HasColumnName("grid1km")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gridgb1e)
                    .HasColumnName("gridgb1e")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gridgb1m)
                    .HasColumnName("gridgb1m")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gridgb1n)
                    .HasColumnName("gridgb1n")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hlth12cd)
                    .HasColumnName("hlth12cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hlth12nm)
                    .HasColumnName("hlth12nm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lad15cd)
                    .HasColumnName("lad15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lad15nm)
                    .HasColumnName("lad15nm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Laddescnm)
                    .HasColumnName("laddescnm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Long)
                    .HasColumnName("long")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Npark15cd)
                    .HasColumnName("npark15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Npark15nm)
                    .HasColumnName("npark15nm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Par15cd)
                    .HasColumnName("par15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pcon15cd)
                    .HasColumnName("pcon15cd")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pcon15nm)
                    .HasColumnName("pcon15nm")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Pfa15cd)
                    .HasColumnName("pfa15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pfa15nm)
                    .HasColumnName("pfa15nm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Place15cd)
                    .HasColumnName("place15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Place15nm)
                    .HasColumnName("place15nm")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Placeid).HasColumnName("placeid");

                entity.Property(e => e.Placesort)
                    .HasColumnName("placesort")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Popcnt)
                    .HasColumnName("popcnt")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Regd15cd)
                    .HasColumnName("regd15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Regd15nm)
                    .HasColumnName("regd15nm")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Rgn15cd)
                    .HasColumnName("rgn15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rgn15nm)
                    .HasColumnName("rgn15nm")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Splitind)
                    .HasColumnName("splitind")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Wd15cd)
                    .HasColumnName("wd15cd")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

}
