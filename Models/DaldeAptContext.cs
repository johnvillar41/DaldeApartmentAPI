using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DaldeApartmentAPI.Models
{
    public partial class DaldeAptContext : DbContext
    {
        public DaldeAptContext()
        {
        }

        public DaldeAptContext(DbContextOptions<DaldeAptContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartments { get; set; } = null!;
        public virtual DbSet<ApartmentRenter> ApartmentRenters { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Renter> Renters { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ApartmentRenter>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.ApartmentId).HasMaxLength(50);

                entity.Property(e => e.DateEnded).HasColumnType("datetime");

                entity.Property(e => e.DateStarted).HasColumnType("datetime");

                entity.Property(e => e.RenterId).HasMaxLength(50);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.ApartmentRenters)
                    .HasForeignKey(d => d.ApartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApartmentRenters_Apartments");

                entity.HasOne(d => d.Renter)
                    .WithMany(p => p.ApartmentRenters)
                    .HasForeignKey(d => d.RenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApartmentRenters_Renters");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.TimeStamp)
                    .IsClustered(false);

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.LogEvent).HasMaxLength(2048);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.DatePaid).HasColumnType("datetime");

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.Property(e => e.PaidTo).HasMaxLength(50);

                entity.Property(e => e.RenterId).HasMaxLength(50);

                entity.Property(e => e.Sum).HasColumnType("money");

                entity.Property(e => e.Type).HasMaxLength(10);

                entity.HasOne(d => d.PaidToNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaidTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Users");

                entity.HasOne(d => d.Renter)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.RenterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payments_Renters");
            });

            modelBuilder.Entity<Renter>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.ContactNumber).HasMaxLength(50);

                entity.Property(e => e.ContractLink).HasMaxLength(50);

                entity.Property(e => e.DateRented).HasColumnType("datetime");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.ReceiptLink).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.Salt).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
