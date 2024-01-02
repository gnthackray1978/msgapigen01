using System;
using System.Collections.Generic;
using System.Data;
using Api.Entities.MSGCore.Auth;
using Api.Entities.Places;
using Api.Entities.Wills;
using Api.Models.Wills;
using Api.Services.interfaces.domain;
using Api.Types.DNAAnalyse;
using ConfigHelper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Api.DB
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
        public static bool east_or_west(double lat, double lng, double lat2, double lng2, double rad)
            => throw new NotSupportedException();


        public virtual DbSet<LincsWills> LincsWills { get; set; }

        public virtual DbSet<NorfolkWills> NorfolkWills { get; set; }
        
        

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
                .HasDbFunction(typeof(WillsContext).GetMethod(nameof(east_or_west),
                new[] {
                    typeof(double),
                    typeof(double),
                    typeof(double),
                    typeof(double),
                    typeof(double)
                }))
            .HasName("east_or_west");
            
            
            modelBuilder.Entity<NorfolkWillsRaw>(entity =>
            {
                entity.ToTable("NorfolkWillsRaw", "Wills");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<NorfolkWills>(entity =>
            {
                entity.ToTable("NorfolkWills", "Wills");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Aliases).IsUnicode(false);

                entity.Property(e => e.Collection).IsUnicode(false);

                entity.Property(e => e.DateString).HasMaxLength(500);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Occupation).IsUnicode(false);

                entity.Property(e => e.Place).IsUnicode(false);

                entity.Property(e => e.Reference).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);
            });

            modelBuilder.Entity<LincsWills>(entity =>
            {
                entity.ToTable("LincsWills", "Wills");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Aliases).IsUnicode(false);

                entity.Property(e => e.Collection).IsUnicode(false);

                entity.Property(e => e.DateString).HasMaxLength(500);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.Occupation).IsUnicode(false);

                entity.Property(e => e.Place).IsUnicode(false);

                entity.Property(e => e.Reference).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);

                entity.Property(e => e.Url).IsUnicode(false);
            });
            
           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public static List<FTMLatLng> ListLatLongs(string connectionString, IHeatMapSearch heatMapSearch )
        {
            List<FTMLatLng> ftmLatLngs = new List<FTMLatLng>();
            List<SqlParameter> paramCollection = new List<SqlParameter>();
            var origins = heatMapSearch.GetOrigins();
            
            string commandText = "";
            string originString = "";
            string commonQry = "DirectAncestor = 1 AND (birthlat<> 0 and birthlong <> 0) and (birthto > @yearFrom and birthto < @yearTo) GROUP BY birthlat, birthlong";

            

            if (origins.Count == 0)
            {
                commandText = "SELECT BirthLat ,BirthLong ,count(id) AS Count FROM [DNA].[FTMPersonView] WHERE " +
                              commonQry;
            }
            else
            {
                string originsQry = "";
                int originCounter = 0;

                origins.ForEach(i =>
                {
                    string paramName = "@Origin" + originCounter;

                    originsQry += paramName + ",";

                    paramCollection.Add(new SqlParameter(paramName, SqlDbType.Int)
                    {
                        Value = i
                    });

                    originCounter++;
                });

                originsQry = originsQry.Remove(originsQry.Length - 1, 1);

                commandText = "SELECT BirthLat ,BirthLong ,count(id) AS Count FROM [DNA].[FTMPersonView] WHERE " +
                              "Origin IN (" +originsQry + ") AND " + commonQry;
            }

            // Year=@Year            
            SqlParameter parameterYear = new SqlParameter("@yearFrom", SqlDbType.Int);
            parameterYear.Value = heatMapSearch.YearFrom;

            SqlParameter parameterYear2 = new SqlParameter("@yearTo", SqlDbType.Int);
            parameterYear2.Value = heatMapSearch.YearTo;

            paramCollection.Add(parameterYear);
            paramCollection.Add(parameterYear2);



            using (SqlDataReader reader = SqlHelper.ExecuteReader(connectionString, commandText, CommandType.Text,
                       paramCollection.ToArray()))
            {
                int idx = 0;
                while (reader.Read())
                {
                    var f = new FTMLatLng();

                    var blat = Convert.ToDouble(reader["BirthLat"]);
                    var blng = Convert.ToDouble(reader["BirthLong"]);
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
