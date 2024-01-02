using Api.Entities.MSGCore.Auth;
using ConfigHelper;
using Microsoft.EntityFrameworkCore;

namespace Api.DB
{
    public partial class MSGCoreContext : DbContext
    {
        public string ConnectionString { get; set; }

        public MSGCoreContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public MSGCoreContext(DbContextOptions<MSGCoreContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<MsgapplicationMapGroup> MsgapplicationMapGroup { get; set; }
        public virtual DbSet<Msgapplications> Msgapplications { get; set; }
        public virtual DbSet<MsgfunctionMapGroup> MsgfunctionMapGroup { get; set; }
        public virtual DbSet<Msgfunctions> Msgfunctions { get; set; }
        public virtual DbSet<MsggroupMapUser> MsggroupMapUser { get; set; }
        public virtual DbSet<Msggroups> Msggroups { get; set; }
        public virtual DbSet<MsgPages> MsgPages { get; set; }

        public virtual DbSet<Msgblogs> MsgBlogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
            modelBuilder.Entity<MsgapplicationMapGroup>(entity =>
            {
                entity.ToTable("MSGApplicationMapGroup");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.MsgapplicationMapGroup)
                    .HasForeignKey(x => x.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MSGApplicationMapGroup_MSGApplications");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.MsgapplicationMapGroup)
                    .HasForeignKey(x => x.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MSGApplicationMapGroup_MSGGroups");
            });

            modelBuilder.Entity<Msgapplications>(entity =>
            {
                entity.ToTable("MSGApplications");

                entity.Property(e => e.ApplicationName).IsRequired();
            });

            modelBuilder.Entity<MsgPages>(entity =>
            {
                entity.ToTable("MSGPages");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<MsgfunctionMapGroup>(entity =>
            {
                entity.ToTable("MSGFunctionMapGroup");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.MsgfunctionMapGroup)
                    .HasForeignKey(x => x.FunctionId)
                    .HasConstraintName("FK_MSGFunctionMapGroup_MSGFunctions");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.MsgfunctionMapGroup)
                    .HasForeignKey(x => x.GroupId)
                    .HasConstraintName("FK_MSGFunctionMapGroup_MSGGroups");
            });

            modelBuilder.Entity<Msgfunctions>(entity =>
            {
                entity.ToTable("MSGFunctions");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<MsggroupMapUser>(entity =>
            {
                entity.ToTable("MSGGroupMapUser");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.MsggroupMapUser)
                    .HasForeignKey(x => x.GroupId)
                    .HasConstraintName("FK_MSGGroupMapUser_MSGGroups");
            });

            modelBuilder.Entity<Msggroups>(entity =>
            {
                entity.ToTable("MSGGroups");
            });

            modelBuilder.Entity<Msgblogs>(entity =>
            {
                entity.ToTable("MSGBlog");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

}
