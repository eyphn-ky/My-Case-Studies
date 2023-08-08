using Microsoft.EntityFrameworkCore;
using VehicleFine.Entities.Concrete;

#nullable disable

namespace VehicleFine.DataAccess.Context
{
    public partial class VehicleFineContext : DbContext
    {
        public VehicleFineContext()
        {
        }

        public VehicleFineContext(DbContextOptions<VehicleFineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleFineInformation> VehicleFineInformations { get; set; }
        public virtual DbSet<VehicleFineReason> VehicleFineReasons { get; set; }
        public virtual DbSet<VehicleFineStatus> VehicleFineStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VehicleFine;Encrypt=False;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Brand1)
                    .HasMaxLength(50)
                    .HasColumnName("Brand");

                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Year).HasMaxLength(50);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.TelephoneNumber).HasMaxLength(15);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Plate).HasMaxLength(15);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Vehicles_Brands");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Vehicles_Owners");
            });

            modelBuilder.Entity<VehicleFineInformation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.VehicleFineRealizationDate).HasColumnType("datetime");

                entity.HasOne(d => d.VehicleFineReason)
                    .WithMany()
                    .HasForeignKey(d => d.VehicleFineReasonId)
                    .HasConstraintName("FK_VehicleFines_VehicleFineReasons");

                entity.HasOne(d => d.VehicleFineStatus)
                    .WithMany()
                    .HasForeignKey(d => d.VehicleFineStatusId)
                    .HasConstraintName("FK_VehicleFines_VehicleFineStatuses");

                entity.HasOne(d => d.Vehicle)
                    .WithMany()
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_VehicleFines_Vehicles");
            });

            modelBuilder.Entity<VehicleFineReason>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<VehicleFineStatus>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Detail).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
