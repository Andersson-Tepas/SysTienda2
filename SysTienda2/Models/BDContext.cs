using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SysTienda2.Models;

public partial class BDContext : DbContext
{
    public BDContext()
    {
    }

    public BDContext(DbContextOptions<BDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Cliente { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("workstation id=BDTienda.mssql.somee.com;packet size=4096;user id=Andersson_Tepas7_SQLLogin_1;pwd=ugp57g58he;data source=BDTienda.mssql.somee.com;persist security info=False;initial catalog=BDTienda;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.DetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Factura_Factura");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.DetalleFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Detalle_Factura_Servicio");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Factura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Cliente");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
