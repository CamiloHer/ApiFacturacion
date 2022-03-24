namespace ApiFacturacion.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class conexion : DbContext
    {
        public conexion()
            : base("name=conexion")
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<TiposDocumentos> TiposDocumentos { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
        public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .HasMany(e => e.Ventas)
                .WithRequired(e => e.Clientes)
                .HasForeignKey(e => e.idCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .HasMany(e => e.DetalleVenta)
                .WithRequired(e => e.Productos)
                .HasForeignKey(e => e.idProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TiposDocumentos>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TiposDocumentos>()
                .HasMany(e => e.Clientes)
                .WithRequired(e => e.TiposDocumentos)
                .HasForeignKey(e => e.tipoDocumento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ventas>()
                .HasMany(e => e.DetalleVenta)
                .WithRequired(e => e.Ventas)
                .HasForeignKey(e => e.idVenta)
                .WillCascadeOnDelete(false);
        }
    }
}
