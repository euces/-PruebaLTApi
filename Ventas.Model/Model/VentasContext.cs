using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Ventas.Model.Model
{
    public partial class VentasContext : DbContext
    {
        public VentasContext()
        {
        }

        public VentasContext(DbContextOptions<VentasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=VENTAS;Password=Admin123;Data Source=localhost:1521/Ventas;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("VENTAS");

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("FACTURA");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID");

                entity.Property(e => e.Descuento)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("DESCUENTO");

                entity.Property(e => e.Documentocliente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTOCLIENTE");

                entity.Property(e => e.Fecha)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA");

                entity.Property(e => e.Iva)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("IVA");

                entity.Property(e => e.Nombrecliente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECLIENTE");

                entity.Property(e => e.Numerofactura)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NUMEROFACTURA");

                entity.Property(e => e.Productoid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PRODUCTOID");

                entity.Property(e => e.Subtotal)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("SUBTOTAL");

                entity.Property(e => e.Tipopago)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TIPOPAGO");

                entity.Property(e => e.Total)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("TOTAL");

                entity.Property(e => e.Totaldescuento)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("TOTALDESCUENTO");

                entity.Property(e => e.Totalimpuesto)
                    .HasColumnType("NUMBER(18,2)")
                    .HasColumnName("TOTALIMPUESTO");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Facturas)
                    .HasForeignKey(d => d.Productoid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FACTURA_PRODUCTO_FK");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("PRODUCTO");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ID");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");
            });

            modelBuilder.HasSequence("SEQ_FACTURA");

            modelBuilder.HasSequence("SEQ_PRODUCTO");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
