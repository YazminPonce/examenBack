using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using tareasApi.Models;

namespace tareasApi.models;

public partial class Bdtareas903Context : DbContext
{
   
    public Bdtareas903Context()
    {
    }

    public Bdtareas903Context(DbContextOptions<Bdtareas903Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Compra> Compras { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.IdTarea).HasName("PK__Tareas__756A54029693573C");

            entity.Property(e => e.IdTarea).HasColumnName("idTarea");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });
        modelBuilder.Entity<Product>(entity =>
        {

            entity.HasKey(e => e.Id).HasName("PK__Products__3213E83F9D96CAF9");

        entity.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        entity.Property(e => e.AvailabilityStatus)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("availabilityStatus");
        entity.Property(e => e.Barcode)
            .HasMaxLength(20)
            .IsUnicode(false)
            .HasColumnName("barcode");
        entity.Property(e => e.Brand)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("brand");
        entity.Property(e => e.Category)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("category");
        entity.Property(e => e.Depth)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("depth");
        entity.Property(e => e.Description)
            .IsUnicode(false)
            .HasColumnName("description");
        entity.Property(e => e.DiscountPercentage)
            .HasColumnType("decimal(5, 2)")
            .HasColumnName("discountPercentage");
        entity.Property(e => e.Height)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("height");
        entity.Property(e => e.MinimumOrderQuantity).HasColumnName("minimumOrderQuantity");
        entity.Property(e => e.Price)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("price");
        entity.Property(e => e.QrCode)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("qrCode");
        entity.Property(e => e.Rating)
            .HasColumnType("decimal(3, 2)")
            .HasColumnName("rating");
        entity.Property(e => e.ReturnPolicy)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("returnPolicy");
        entity.Property(e => e.ShippingInformation)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("shippingInformation");
        entity.Property(e => e.Sku)
            .HasMaxLength(50)
            .IsUnicode(false)
            .HasColumnName("sku");
        entity.Property(e => e.Stock).HasColumnName("stock");
        entity.Property(e => e.Thumbnail)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("thumbnail");
        entity.Property(e => e.Title)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("title");
        entity.Property(e => e.WarrantyInformation)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("warrantyInformation");
        entity.Property(e => e.Weight)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("weight");
        entity.Property(e => e.Width)
            .HasColumnType("decimal(10, 2)")
            .HasColumnName("width");
    });
        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.CompraId).HasName("PK__Compras__067DA725ACEB705D");

            entity.Property(e => e.CompraId).HasColumnName("CompraID");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
