using AzureContext.Models;
using ConfigHelper;
using Microsoft.EntityFrameworkCore;

namespace Api.DB
{
    public partial class TDBContext : DbContext
    {
        public string ConnectionString { get; set; }

        public TDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public TDBContext(DbContextOptions<TDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Marriages> Marriages { get; set; }
        public virtual DbSet<ParishRecordSource> ParishRecordSource { get; set; }
        public virtual DbSet<ParishRecords> ParishRecords { get; set; }
        public virtual DbSet<ParishTranscriptionDetails> ParishTranscriptionDetails { get; set; }
        public virtual DbSet<Parishs> Parishs { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<RelationTypes> RelationTypes { get; set; }
        public virtual DbSet<Relations> Relations { get; set; }
        public virtual DbSet<SourceMappingParishs> SourceMappingParishs { get; set; }
        public virtual DbSet<SourceMappings> SourceMappings { get; set; }
        public virtual DbSet<SourceTypes> SourceTypes { get; set; }
        public virtual DbSet<Sources> Sources { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<ImageParents> ImageParents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region thackraydb

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Images", "TDB");

                entity.Property(e => e.Path).HasMaxLength(400);

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.Property(e => e.Info).HasMaxLength(500);


            });

            modelBuilder.Entity<ImageParents>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ImageParents", "TDB");


                entity.Property(e => e.Title).HasMaxLength(150);

                entity.Property(e => e.Info).HasMaxLength(500);

                entity.Property(e => e.Page).HasMaxLength(150);


            });

            modelBuilder.Entity<Marriages>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Marriages", "TDB");

                entity.Property(e => e.Location)
                   .HasColumnName("MarriageLocation");

                entity.Property(e => e.Year)
                   .HasColumnName("YearIntVal");

                entity.Property(e => e.Date)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.DateLastEdit).HasColumnType("date");

                entity.Property(e => e.FemaleCname)
                    .HasColumnName("FemaleCName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FemaleInfo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FemaleLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FemaleOccupation).HasMaxLength(500);

                entity.Property(e => e.FemaleSname)
                    .HasColumnName("FemaleSName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaleCname)
                    .HasColumnName("MaleCName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaleInfo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaleLocation)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaleOccupation).HasMaxLength(500);

                entity.Property(e => e.MaleSname)
                    .HasColumnName("MaleSName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MarriageCounty).HasMaxLength(500);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrigFemaleSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrigMaleSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Source).HasMaxLength(50);

                entity.Property(e => e.UniqueRef).HasMaxLength(50);

                entity.Property(e => e.Witness1).HasMaxLength(500);

                entity.Property(e => e.Witness2).HasMaxLength(500);

                entity.Property(e => e.Witness3).HasMaxLength(500);

                entity.Property(e => e.Witness4).HasMaxLength(500);
            });


            modelBuilder.Entity<ParishRecordSource>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ParishRecordSource", "TDB");

                entity.Property(e => e.RecordTypeDescription).HasMaxLength(500);

                entity.Property(e => e.RecordTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<ParishRecords>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ParishRecords", "TDB");

                entity.Property(e => e.RecordType)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ParishTranscriptionDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ParishTranscriptionDetails", "TDB");

                entity.Property(e => e.ParishDataString).HasMaxLength(500);
            });

            modelBuilder.Entity<Parishs>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Parishs", "TDB");


                entity.Property(e => e.ParentParish).HasMaxLength(500);

                entity.Property(e => e.County).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.ParishNotes).HasMaxLength(1000);

                entity.Property(e => e.ParishRegistersDeposited).HasMaxLength(500);

                entity.Property(e => e.ParishX).HasColumnType("decimal(12, 6)");

                entity.Property(e => e.ParishY).HasColumnType("decimal(12, 6)");
            });
            

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Persons", "TDB");

                entity.Property(e => e.BaptismDateStr).HasMaxLength(50);

                entity.Property(e => e.BirthCounty).HasMaxLength(500);

                entity.Property(e => e.BirthDateStr).HasMaxLength(50);

                entity.Property(e => e.BirthLocation).HasMaxLength(500);

                entity.Property(e => e.ChristianName).HasMaxLength(150);

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.DateLastEdit).HasColumnType("date");

                entity.Property(e => e.DeathCounty).HasMaxLength(500);

                entity.Property(e => e.DeathDateStr).HasMaxLength(50);

                entity.Property(e => e.DeathLocation).HasMaxLength(500);

                entity.Property(e => e.FatherChristianName).HasMaxLength(150);

                entity.Property(e => e.FatherOccupation).HasMaxLength(150);

                entity.Property(e => e.FatherSurname).HasMaxLength(500);

                entity.Property(e => e.MotherChristianName).HasMaxLength(500);

                entity.Property(e => e.MotherSurname).HasMaxLength(500);

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.Occupation).HasMaxLength(150);

                entity.Property(e => e.OrigFatherSurname).HasMaxLength(150);

                entity.Property(e => e.OrigMotherSurname).HasMaxLength(150);

                entity.Property(e => e.OrigSurname).HasMaxLength(150);

                entity.Property(e => e.ReferenceDateStr).HasMaxLength(50);

                entity.Property(e => e.ReferenceLocation).HasMaxLength(150);

                entity.Property(e => e.Source).HasMaxLength(50);

                entity.Property(e => e.SpouseName).HasMaxLength(150);

                entity.Property(e => e.SpouseSurname).HasMaxLength(150);

                entity.Property(e => e.Surname).HasMaxLength(100);

                entity.Property(e => e.UniqueRef).HasMaxLength(50);
            });

            modelBuilder.Entity<RelationTypes>(entity =>
            {
                entity.HasKey(e => e.RelationTypeId);

                entity.ToTable("RelationTypes", "TDB");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.RelationName).HasMaxLength(50);
            });

            modelBuilder.Entity<Relations>(entity =>
            {
                entity.HasKey(e => e.RelationId);

                entity.ToTable("Relations", "TDB");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");
            });

            modelBuilder.Entity<SourceMappingParishs>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("SourceMappingParishs", "TDB");

                entity.Property(e => e.SourceMappingDateAdded).HasColumnType("datetime");
            });

            modelBuilder.Entity<SourceMappings>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_RecordMapSource");

                entity.ToTable("SourceMappings", "TDB");

                entity.Property(e => e.DateAdded).HasColumnType("date");
            });

            modelBuilder.Entity<SourceTypes>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("SourceTypes", "TDB");

                entity.Property(e => e.SourceDateAdded)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SourceTypeDesc).HasMaxLength(50);
            });

            modelBuilder.Entity<Sources>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Sources", "TDB");

                entity.Property(e => e.DateAdded).HasColumnType("date");

                entity.Property(e => e.Location).HasMaxLength(500);

                entity.Property(e => e.Location)
                   .HasColumnName("OriginalLocation");

                entity.Property(e => e.YearFrom)
                   .HasColumnName("SourceDate");

                entity.Property(e => e.YearTo)
                   .HasColumnName("SourceDateTo");


                entity.Property(e => e.SourceDateStr)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SourceDateStrTo)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SourceDescription).HasColumnType("text");

                entity.Property(e => e.SourceNotes).HasColumnType("text");

                entity.Property(e => e.SourceRef).HasMaxLength(500);
            });

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

}
