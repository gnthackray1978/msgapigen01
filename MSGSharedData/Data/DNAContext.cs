using System.Data;
using FTMContextNet.Domain.Entities.Persistent.Cache;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MSGSharedData.Data.Services.interfaces.domain;
using MSGSharedData.Domain.Entities.NonPersistent.DNAAnalyse;
using MSGSharedData.Domain.Entities.Persistent.DNA;

namespace MSGSharedData.Data
{
    public partial class DNAContext : DbContext
    {
        public string ConnectionString { get; set; }

        public DNAContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DNAContext(DbContextOptions<DNAContext> options)
            : base(options)
        {
        }
        public static bool east_or_west(decimal lat, decimal lng, decimal lat2, decimal lng2, double rad)
            => throw new NotSupportedException();


        public virtual DbSet<PersonsOfInterest> PersonsOfInterest { get; set; }
        public virtual DbSet<TreeRecord> TreeRecord { get; set; }

        public virtual DbSet<TreeRecordMapGroup> TreeRecordMapGroup { get; set; }

        public virtual DbSet<TreeGroups> TreeGroups { get; set; }

        public virtual DbSet<FTMPersonView> FTMPersonView { get; set; }

        public virtual DbSet<Relationships> Relationships { get; set; }

        public virtual DbSet<DupeEntry> DupeEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasDbFunction(typeof(DNAContext).GetMethod(nameof(east_or_west),
                new[] {
                    typeof(decimal),
                    typeof(decimal),
                    typeof(decimal),
                    typeof(decimal),
                    typeof(double)
                }))
    .HasName("east_or_west");


            modelBuilder.Entity<DupeEntry>(entity =>
            {
                entity.ToTable("DupeEntries", "DNA");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.YearStart);

                entity.Property(e => e.YearEnd);

                entity.Property(e => e.Ident).HasMaxLength(500);

                entity.Property(e => e.Origin).HasMaxLength(500);

                entity.Property(e => e.FirstName).HasMaxLength(500);

                entity.Property(e => e.Surname).HasMaxLength(500);

            });

            modelBuilder.Entity<FTMPersonView>(entity =>
            {
                entity.ToTable("FTMPersonView", "DNA");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(500);

                entity.Property(e => e.Surname).HasMaxLength(500);

                entity.Property(e => e.Origin).HasMaxLength(250);

                entity.Property(e => e.Lat).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Lng).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.AltLat).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.AltLong).HasColumnType("decimal(10, 8)");

               // entity.Property(e => e.YearFrom).HasColumnName("BirthFrom");

               // entity.Property(e => e.YearTo).HasColumnName("BirthTo");

               // entity.Property(e => e.Location).HasColumnName("Location");

            });

            modelBuilder.Entity<Relationships>(entity =>
            {
                entity.ToTable("Relationships", "DNA");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Notes).HasMaxLength(2000).IsRequired(false);

                entity.Property(e => e.DateStr).HasMaxLength(500);

                entity.Property(e => e.Origin).HasMaxLength(500).IsRequired(false);

            });

            modelBuilder.Entity<PersonsOfInterest>(entity =>
            {
                entity.ToTable("PersonsOfInterest", "DNA");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TreeUrl).HasColumnName("TreeURL");

                entity.Property(e => e.Year).HasColumnName("BirthYear");

                entity.Property(e => e.Location).HasColumnName("BirthPlace");
            });

            modelBuilder.Entity<TreeRecord>(entity =>
            {
                entity.ToTable("TreeRecord", "DNA");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Name);
                entity.Property(e => e.Origin).HasMaxLength(250);
            });

            modelBuilder.Entity<TreeGroups>(entity =>
            {
                entity.ToTable("TreeGroups", "DNA");
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.GroupName).HasMaxLength(500);
            });

            modelBuilder.Entity<TreeRecordMapGroup>(entity =>
            {
                entity.ToTable("TreeRecordMapGroup", "DNA");
                entity.Property(e => e.Id).ValueGeneratedNever();
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public static List<FTMLatLng> ListLatLongs(string connectionString, IHeatMapSearch heatMapSearch)
        {
            List<FTMLatLng> ftmLatLngs = new List<FTMLatLng>();
            List<SqlParameter> paramCollection = new List<SqlParameter>();
            var origins = heatMapSearch.GetOrigins();

            string commandText = "";
            string originString = "";
            string commonQry = "DirectAncestor = 1 AND (lat<> 0 and lng <> 0) and (yearStart > @yearStart and yearStart < @yearEnd) GROUP BY lat, lng";

            if (origins.Count == 0)
            {
                commandText = "SELECT lat ,lng ,count(id) AS Count FROM [DNA].[FTMPersonView] WHERE " +
                              commonQry;
            }
            else
            {
                string originsQry = "";
                int originCounter = 0;

                //todo fix to use param not string!
                origins.ForEach(i =>
                {
                    //  string paramName = "@Origin" + originCounter;

                    // originsQry += paramName + ",";

                    //   paramCollection.Add(new SqlParameter(paramName, SqlDbType.VarChar, i.Length + 5)
                    //{
                    //    Value = i
                    //});

                    //originCounter++;

                    originsQry += "'" + i + "',";
                });

                if(originsQry.Last() == ',')
                    originsQry = originsQry.Remove(originsQry.Length - 1, 1);
                 

                commandText = "SELECT lat ,lng ,count(id) AS Count FROM [DNA].[FTMPersonView] WHERE " +
                              "Origin IN (" + originsQry + ") AND " + commonQry;
            }

            // Year=@Year            
            SqlParameter parameterYear = new SqlParameter("@yearStart", SqlDbType.Int);
            parameterYear.Value = heatMapSearch.YearStart;

            SqlParameter parameterYear2 = new SqlParameter("@yearEnd", SqlDbType.Int);
            parameterYear2.Value = heatMapSearch.YearEnd;

            paramCollection.Add(parameterYear);
            paramCollection.Add(parameterYear2);



            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, commandText, CommandType.Text,
                       paramCollection.ToArray()))
            {
                int idx = 0;
                while (reader.Read())
                {
                    var f = new FTMLatLng();

                    var blat = Convert.ToDouble(reader["lat"]);
                    var blng = Convert.ToDouble(reader["lng"]);
                    var count = Convert.ToInt32(reader["Count"]);

                    f.Lat = blat;
                    f.Long = blng;
                    f.Weight = count;
                    f.Id = idx;

                    ftmLatLngs.Add(f);

                    idx++;

                }
            }

            return ftmLatLngs;
        }
    }

}
