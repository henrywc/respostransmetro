namespace BlackSys.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using BlackSys.Models.Modelos_transmetro;

    public partial class BlackSysEntities : DbContext
    {

        public BlackSysEntities()
            : base("name=BlackSysConnection")
        {
        }

        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Component> Component { get; set; }
        public virtual DbSet<ComponentCategory> ComponentCategory { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
    
        public virtual DbSet<CustomPermission> CustomPermission { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<MenuTemp> MenuTemp { get; set; }
        public virtual DbSet<PermissionMenu> PermissionMenu { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasure { get; set; }
        public virtual DbSet<Fabric> Fabric { get; set; }
        public virtual DbSet<FabricCategory> FabricCategory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductPhoto> ProductPhoto { get; set; }
        public virtual DbSet<MunicipalidadModel> MunicipalidadModels { get; set; }
        public virtual DbSet<LineaModel> LineaModels { get; set; }
        public virtual DbSet<ConsultarLinea> ConsultarLineaModel { get; set; }
        public virtual DbSet<EstacionModel> EstacionModels { get; set; }
        public virtual DbSet<ConsultarEstacion> ConsultarEstacionModel { get; set; }
        public virtual DbSet<AccesoModel> AccesoModels { get; set; }
        public virtual DbSet<ConsultarAcceso> ConsultarAccesoModel { get; set; }
        public virtual DbSet<ParqueoModel> ParqueoModels { get; set; }
        public virtual DbSet<ConsultarParqueo> ConsultarParqueoModel { get; set; }
        public virtual DbSet<PilotoModel> PilotoModels { get; set; }
        public virtual DbSet<GuardiaModel> GuardiaModels { get; set; }
        public virtual DbSet<ConsultarGuardia> ConsultarGuardiaModel { get; set; }
        public virtual DbSet<PilotoEducacionModel> PilotoEducacionModels { get; set; }
        public virtual DbSet<ConsultarPilotoEducacion> ConsultarPilotoEducacionModel { get; set; }
        public virtual DbSet<PilotoDireccionModel> PilotoDireccionModels { get; set; }
        public virtual DbSet<ConsultarPilotoDireccion> ConsultarPilotoDireccionModel { get; set; }
        public virtual DbSet<DistanciaModel> DistanciaModels { get; set; }
        public virtual DbSet<ConsultarDistancia> ConsultarDistanciaModel { get; set; }
        public virtual DbSet<BusModel> BusModels { get; set; }
        public virtual DbSet<ConsultarBus> ConsultarBusModel { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Component>()
               .Property(e => e.PurchasingPrice)
               .HasPrecision(19, 4);

            modelBuilder.Entity<Component>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ComponentCategory>()
                .HasMany(e => e.Component)
                .WithRequired(e => e.ComponentCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.Permission)
                .WithRequired(e => e.AspNetRoles)
                .HasForeignKey(e => e.RoleID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UnitMeasure>()
              .HasMany(e => e.Component)
              .WithRequired(e => e.UnitMeasure)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fabric>()
                .Property(e => e.PurchasingPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.StandardCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.WeightUnitMeasureCode)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Weight)
                .HasPrecision(8, 2);

            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.CustomPermission)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.CustomPermission)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.Permission)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MunicipalidadModel>()
              .HasKey(e => e.idmunicipalidad);

            modelBuilder.Entity<LineaModel>()
              .HasKey(e => e.idmunicipalidad);

            modelBuilder.Entity<ConsultarLinea>()
              .HasKey(e => e.idlinea);

            modelBuilder.Entity<EstacionModel>()
              .HasKey(e => e.idmunicipalidad);

            modelBuilder.Entity<ConsultarEstacion>()
              .HasKey(e => e.idestacion);

            modelBuilder.Entity<AccesoModel>()
              .HasKey(e => e.idestacion);

            modelBuilder.Entity<ConsultarAcceso>()
              .HasKey(e => e.idacceso);

            modelBuilder.Entity<ParqueoModel>()
              .HasKey(e => e.idestacion);

            modelBuilder.Entity<ConsultarParqueo>()
              .HasKey(e => e.idparqueo);

            modelBuilder.Entity<PilotoModel>()
              .HasKey(e => e.idpiloto);

            modelBuilder.Entity<GuardiaModel>()
              .HasKey(e => e.idacceso);

            modelBuilder.Entity<ConsultarGuardia>()
              .HasKey(e => e.idguardia);

            modelBuilder.Entity<PilotoEducacionModel>()
              .HasKey(e => e.idpiloto);

            modelBuilder.Entity<ConsultarPilotoEducacion>()
              .HasKey(e => e.idpilotos_educacion);

            modelBuilder.Entity<PilotoDireccionModel>()
              .HasKey(e => e.idpiloto);

            modelBuilder.Entity<ConsultarPilotoDireccion>()
              .HasKey(e => e.idpilotos_direccion);

            modelBuilder.Entity<DistanciaModel>()
              .HasKey(e => e.idlinea);

            modelBuilder.Entity<ConsultarDistancia>()
              .HasKey(e => e.iddistancia);

            modelBuilder.Entity<BusModel>()
              .HasKey(e => e.idpiloto);

            modelBuilder.Entity<ConsultarBus>()
              .HasKey(e => e.idbus);

        }
    }
}
