using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using iNUPCO.SHO.Data.Models;

namespace iNUPCO.SHO.Data.Context;

public partial class iNUPCOContext : DbContext
{
    public iNUPCOContext(DbContextOptions<iNUPCOContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<Podocument> Podocuments { get; set; }

    public virtual DbSet<PodocumentItem> PodocumentItems { get; set; }

    public virtual DbSet<Sho> Shos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.GoodCode);

            entity.ToTable("Good");

            entity.Property(e => e.GoodCode).HasColumnName("Good_Code");
            entity.Property(e => e.GoodName)
                .HasMaxLength(250)
                .HasColumnName("Good_Name");
        });

        modelBuilder.Entity<Podocument>(entity =>
        {
            entity.HasKey(e => e.PoNumber);

            entity.ToTable("PODocument");

            entity.Property(e => e.PoNumber).HasColumnName("PO_Number");
            entity.Property(e => e.PoDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PO_Date");
            entity.Property(e => e.PoIsHolded).HasColumnName("PO_IsHolded");
            entity.Property(e => e.PoState).HasColumnName("PO_State");
            entity.Property(e => e.PoTotalAmount)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("PO_TotalAmount");
        });

        modelBuilder.Entity<PodocumentItem>(entity =>
        {
            entity.HasKey(e => new { e.PodocumentNumber, e.GoodCode });

            entity.ToTable("PODocument_Item");

            entity.Property(e => e.PodocumentNumber).HasColumnName("PODocument_Number");
            entity.Property(e => e.GoodCode).HasColumnName("Good_Code");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");
            entity.Property(e => e.PurchasedGoodPrice).HasColumnType("decimal(18, 3)");

            entity.HasOne(d => d.GoodCodeNavigation).WithMany(p => p.PodocumentItems)
                .HasForeignKey(d => d.GoodCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PODocument_Item_Good");

            entity.HasOne(d => d.PodocumentNumberNavigation).WithMany(p => p.PodocumentItems)
                .HasForeignKey(d => d.PodocumentNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PODocument_Item_PODocument");
        });

        modelBuilder.Entity<Sho>(entity =>
        {
            entity.HasKey(e => e.ShoNumber);

            entity.ToTable("SHO");

            entity.HasIndex(e => e.ShoNumber, "IX_SHO");

            entity.Property(e => e.ShoNumber).HasColumnName("SHO_Number");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.PodocumentNumber).HasColumnName("PODocument_Number");

            entity.HasOne(d => d.PodocumentNumberNavigation).WithMany(p => p.Shos)
                .HasForeignKey(d => d.PodocumentNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SHO_PODocument");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
