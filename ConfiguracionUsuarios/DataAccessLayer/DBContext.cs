namespace ConfiguracionUsuarios.DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Aplicacion> Aplicacion { get; set; }
        public virtual DbSet<Password> Password { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<PermisoUsuario> PermisoUsuario { get; set; }
        public virtual DbSet<PermisoView> PermisoView { get; set; }
        public virtual DbSet<UsuarioView> UsuarioView { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aplicacion>()
                .Property(e => e.NombreAplicacion)
                .IsUnicode(false);

            modelBuilder.Entity<Aplicacion>()
                .HasMany(e => e.Permiso)
                .WithRequired(e => e.Aplicacion)
                .HasForeignKey(e => e.FK_IDAplicacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Password>()
                .Property(e => e.HashedRFID)
                .IsUnicode(false);

            modelBuilder.Entity<Password>()
                .Property(e => e.HashedPassword)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.NumeroPedido)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .Property(e => e.NumeroArticulo)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.NombrePermiso)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .HasMany(e => e.PermisoUsuario)
                .WithRequired(e => e.Permiso)
                .HasForeignKey(e => e.FK_IDPermiso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.LegajoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ApellidoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasOptional(e => e.Password)
                .WithRequired(e => e.Usuario);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Permiso_Usuario)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.FK_IDUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PermisoView>()
                .Property(e => e.NombreAplicacion)
                .IsUnicode(false);

            modelBuilder.Entity<PermisoView>()
                .Property(e => e.NombrePermiso)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.LegajoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.ApellidoUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.HashedPassword)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioView>()
                .Property(e => e.HashedRFID)
                .IsUnicode(false);
        }
    }
}
