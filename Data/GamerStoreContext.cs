using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using gamer_store_api.Data.Models;

namespace gamer_store_api.Data;

public partial class GamerStoreContext : DbContext
{
    public GamerStoreContext()
    {
    }

    public GamerStoreContext(DbContextOptions<GamerStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Envio> Envios { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<MetodosPago> MetodosPagos { get; set; }

    public virtual DbSet<Plataforma> Plataformas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<UnidadesMedidum> UnidadesMedida { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    public virtual DbSet<VentasProducto> VentasProductos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__CB9033496A8C7803");

            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.IdEnvio).HasName("PK__Envios__3A8388337950ECB0");

            entity.Property(e => e.IdEnvio).HasColumnName("Id_Envio");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaEntregaEstimada)
                .HasColumnType("date")
                .HasColumnName("Fecha_Entrega_Estimada");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.FechaRecepcion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Recepcion");
            entity.Property(e => e.IdRepartidor).HasColumnName("Id_Repartidor");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");

            entity.HasOne(d => d.IdRepartidorNavigation).WithMany(p => p.Envios)
                .HasForeignKey(d => d.IdRepartidor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Id_Repartidor");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.Envios)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Envio_Id_Venta");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estados__AB2EB6F8A23FD4AC");

            entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");
        });

        modelBuilder.Entity<MetodosPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PK__Metodos___E4BD96C4BE45B5DD");

            entity.ToTable("Metodos_Pago");

            entity.Property(e => e.IdMetodoPago).HasColumnName("Id_Metodo_Pago");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");
        });

        modelBuilder.Entity<Plataforma>(entity =>
        {
            entity.HasKey(e => e.IdPlataforma).HasName("PK__Platafor__BDB8CABE03946348");

            entity.Property(e => e.IdPlataforma).HasColumnName("Id_Plataforma");
            entity.Property(e => e.Abreviacion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__2085A9CFBED6C454");

            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.IdCategoria).HasColumnName("Id_Categoria");
            entity.Property(e => e.IdPlataforma).HasColumnName("Id_Plataforma");
            entity.Property(e => e.IdUnidadMedida).HasColumnName("Id_Unidad_Medida");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Precio).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Id_Categoria");

            entity.HasOne(d => d.IdPlataformaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdPlataforma)
                .HasConstraintName("fk_Id_Plataforma");

            entity.HasOne(d => d.IdUnidadMedidaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdUnidadMedida)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Id_Unidad_Medida");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Roles__55932E868875D73D");

            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");
        });

        modelBuilder.Entity<UnidadesMedidum>(entity =>
        {
            entity.HasKey(e => e.IdUnidadMedida).HasName("PK__Unidades__DA58F4E717645BF7");

            entity.ToTable("Unidades_Medida");

            entity.Property(e => e.IdUnidadMedida).HasColumnName("Id_Unidad_Medida");
            entity.Property(e => e.Abreviacion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuarios__63C76BE2B5EBC8DA");

            entity.Property(e => e.IdUsuario).HasColumnName("Id_Usuario");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Apellido_Paterno");
            entity.Property(e => e.Calle)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Codigo_Postal");
            entity.Property(e => e.Colonia)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.IdEstado).HasColumnName("Id_Estado");
            entity.Property(e => e.IdRol).HasColumnName("Id_Rol");
            entity.Property(e => e.Nombres)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.NumeroExterior)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Numero_Exterior");
            entity.Property(e => e.NumeroInterior)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("Numero_Interior");
            entity.Property(e => e.NumeroTelefonico)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Numero_Telefonico");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Id_Estado");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Id_Rol");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Ventas__B3C9EABDA10CB5EF");

            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");
        });

        modelBuilder.Entity<VentasProducto>(entity =>
        {
            entity.HasKey(e => e.IdVentaProducto).HasName("PK__Ventas_P__B4E6DEA5E0842498");

            entity.ToTable("Ventas_Productos");

            entity.Property(e => e.IdVentaProducto).HasColumnName("Id_Venta_Producto");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Modificacion");
            entity.Property(e => e.IdProducto).HasColumnName("Id_Producto");
            entity.Property(e => e.IdVenta).HasColumnName("Id_Venta");
            entity.Property(e => e.UsuarioCreacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Creacion");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Usuario_Modificacion");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.VentasProductos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Id_Producto");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.VentasProductos)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Id_Venta");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
