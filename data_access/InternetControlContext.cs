using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using domain_layer.entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using domain_layer.Security;

#nullable disable

namespace data_access
{
    public partial class InternetControlContext : IdentityDbContext<User>
    {
        public InternetControlContext()
        {
        }

        public InternetControlContext(DbContextOptions<InternetControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anio> Anios { get; set; }
        public virtual DbSet<AnioMe> AnioMes { get; set; }
        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Bitacora> Bitacoras { get; set; }
        public virtual DbSet<CategoriaProcesoSistema> CategoriaProcesoSistemas { get; set; }
        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<DetalleEmisionServicioCable> DetalleEmisionServicioCables { get; set; }
        public virtual DbSet<Deuda> Deudas { get; set; }
        public virtual DbSet<DocumentoElectronico> DocumentoElectronicos { get; set; }
        public virtual DbSet<EmisionServicioCable> EmisionServicioCables { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EquipoEnlaceCliente> EquipoEnlaceClientes { get; set; }
        public virtual DbSet<EstadoSuscripcion> EstadoSuscripcions { get; set; }
        public virtual DbSet<FacturaServicio> FacturaServicios { get; set; }
        public virtual DbSet<GrupoUsuario> GrupoUsuarios { get; set; }
        public virtual DbSet<ImagenSuscripcion> ImagenSuscripcions { get; set; }
        public virtual DbSet<Me> Mes { get; set; }
        public virtual DbSet<ModuloSistema> ModuloSistemas { get; set; }
        public virtual DbSet<ParametroApp> ParametroApps { get; set; }
        public virtual DbSet<PermisoGrupo> PermisoGrupos { get; set; }
        public virtual DbSet<ProcesoSistema> ProcesoSistemas { get; set; }
        public virtual DbSet<Provincium> Provincia { get; set; }
        public virtual DbSet<PuntoAcceso> PuntoAccesos { get; set; }
        public virtual DbSet<PuntoAccesoServicio> PuntoAccesoServicios { get; set; }
        public virtual DbSet<SectorCiudad> SectorCiudads { get; set; }
        public virtual DbSet<ServicioAdicional> ServicioAdicionals { get; set; }
        public virtual DbSet<ServicioSuscripcion> ServicioSuscripcions { get; set; }
        public virtual DbSet<Servidor> Servidors { get; set; }
        public virtual DbSet<Sexo> Sexos { get; set; }
        public virtual DbSet<Sucursal> Sucursals { get; set; }
        public virtual DbSet<Suscripcion> Suscripcions { get; set; }
        public virtual DbSet<Suscriptor> Suscriptors { get; set; }
        public virtual DbSet<TipoEquipo> TipoEquipos { get; set; }
        public virtual DbSet<TipoSuscripcion> TipoSuscripcions { get; set; }
        public virtual DbSet<TorreDistribucion> TorreDistribucions { get; set; }
        public virtual DbSet<TrackinSuscripcionImage> TrackinSuscripcionImages { get; set; }
        public virtual DbSet<TrackingSuscripcion> TrackingSuscripcions { get; set; }
        public virtual DbSet<UbicacionEnlace> UbicacionEnlaces { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }
        public virtual DbSet<VwDeudasGenerale> VwDeudasGenerales { get; set; }
        public virtual DbSet<VwImprimirNcPunto2Ebilling> VwImprimirNcPunto2Ebillings { get; set; }
        public virtual DbSet<VwImprimirNcPunto3Ebilling> VwImprimirNcPunto3Ebillings { get; set; }
        public virtual DbSet<VwImprimirNcPunto4Ebilling> VwImprimirNcPunto4Ebillings { get; set; }
        public virtual DbSet<VwListaSuscripcione> VwListaSuscripciones { get; set; }
        public virtual DbSet<VwModeloConfiguracionPuntoAcceso> VwModeloConfiguracionPuntoAccesos { get; set; }
        public virtual DbSet<VwReporteGeneralRecuadacionFacElectronica> VwReporteGeneralRecuadacionFacElectronicas { get; set; }
        public virtual DbSet<VwValoresPagar> VwValoresPagars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=connectiondb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Anio>(entity =>
            {
                entity.HasKey(e => e.Idanio)
                    .HasName("PK_Periodo");

                entity.ToTable("Anio");

                entity.Property(e => e.Idanio)
                    .ValueGeneratedNever()
                    .HasColumnName("IDAnio");

                entity.Property(e => e.DescripcionAnio)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AnioMe>(entity =>
            {
                entity.HasKey(e => new { e.Idanio, e.Idmes });

                entity.Property(e => e.Idanio).HasColumnName("IDAnio");

                entity.Property(e => e.Idmes).HasColumnName("IDMes");

                entity.HasOne(d => d.IdanioNavigation)
                    .WithMany(p => p.AnioMes)
                    .HasForeignKey(d => d.Idanio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnioMes_Anio");

                entity.HasOne(d => d.IdmesNavigation)
                    .WithMany(p => p.AnioMes)
                    .HasForeignKey(d => d.Idmes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnioMes_Mes");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.Idoperacion);

                entity.ToTable("Bitacora");

                entity.Property(e => e.Idoperacion).HasColumnName("IDOperacion");

                entity.Property(e => e.DetalleOperacion)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionIp)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DireccionIP");

                entity.Property(e => e.DireccionMac)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DireccionMAC");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdmoduloSistema)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDModuloSistema");

                entity.Property(e => e.IdusuarioSistema)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUsuarioSistema");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdmoduloSistemaNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.IdmoduloSistema)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bitacora_ModuloSistema");

                entity.HasOne(d => d.IdusuarioSistemaNavigation)
                    .WithMany(p => p.Bitacoras)
                    .HasForeignKey(d => d.IdusuarioSistema)
                    .HasConstraintName("FK_Bitacora_Usuario");
            });

            modelBuilder.Entity<CategoriaProcesoSistema>(entity =>
            {
                entity.HasKey(e => e.IdcategoriaProceso);

                entity.ToTable("CategoriaProcesoSistema");

                entity.Property(e => e.IdcategoriaProceso)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCategoriaProceso");

                entity.Property(e => e.DescripcionCategoriaProceso)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.StrIdciudad);

                entity.ToTable("Ciudad");

                entity.Property(e => e.StrIdciudad)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDCiudad");

                entity.Property(e => e.StrDescripcionCiudad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionCiudad");

                entity.Property(e => e.StrIdprovincia)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDProvincia");

                entity.Property(e => e.StrObservaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strObservaciones");

                entity.HasOne(d => d.StrIdprovinciaNavigation)
                    .WithMany(p => p.Ciudads)
                    .HasForeignKey(d => d.StrIdprovincia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ciudad_Provincia");
            });

            modelBuilder.Entity<DetalleEmisionServicioCable>(entity =>
            {
                entity.HasKey(e => new { e.IdemisionCable, e.StrIdsucursal, e.DblCodigoSuscripcion });

                entity.ToTable("DetalleEmisionServicioCable");

                entity.Property(e => e.IdemisionCable).HasColumnName("IDEmisionCable");

                entity.Property(e => e.StrIdsucursal)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.Property(e => e.DblCodigoSuscripcion).HasColumnName("dblCodigoSuscripcion");

                entity.Property(e => e.AutSriretencion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AutSRIRetencion");

                entity.Property(e => e.CobrosAdicionales).HasColumnType("money");

                entity.Property(e => e.CodigoImpuestoRenta)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ComdigoImpuestiIva)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ComdigoImpuestiIVA");

                entity.Property(e => e.CostoEquiposAdicionalesFactura).HasColumnType("money");

                entity.Property(e => e.CostoEquiposIncluidosFactura).HasColumnType("money");

                entity.Property(e => e.DescuentoAplicado).HasColumnType("money");

                entity.Property(e => e.FechaAnulacion).HasColumnType("datetime");

                entity.Property(e => e.FechaAutorizacionRetencion).HasColumnType("datetime");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.FechaSicronizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaValidezComprobanteRetencion).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.IddocumentoElectronico).HasColumnName("IDDocumentoElectronico");

                entity.Property(e => e.IdpuntoAccesoCobro).HasColumnName("IDPuntoAccesoCobro");

                entity.Property(e => e.IdsucursalCobro)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDSucursalCobro");

                entity.Property(e => e.IdusuarioCobrador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUsuarioCobrador");

                entity.Property(e => e.IdusuarioCreador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUsuarioCreador");

                entity.Property(e => e.IdusuarioSincronizador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUsuarioSincronizador");

                entity.Property(e => e.IduusarioAnulador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUusarioAnulador");

                entity.Property(e => e.Ivacobrado).HasColumnName("IVACobrado");

                entity.Property(e => e.NroSerialRetencion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento).ValueGeneratedOnAdd();

                entity.Property(e => e.ObservacionesFactura)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeIvaaplicado).HasColumnName("PorcentajeIVAAplicado");

                entity.Property(e => e.PorcentajeRetencionIva).HasColumnName("PorcentajeRetencionIVA");

                entity.Property(e => e.SubtotalConIva)
                    .HasColumnType("money")
                    .HasColumnName("SubtotalConIVA");

                entity.Property(e => e.SubtotalSinIva)
                    .HasColumnType("money")
                    .HasColumnName("SubtotalSinIVA");

                entity.Property(e => e.Tag3).HasColumnType("money");

                entity.HasOne(d => d.IddocumentoElectronicoNavigation)
                    .WithMany(p => p.DetalleEmisionServicioCables)
                    .HasForeignKey(d => d.IddocumentoElectronico)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_DetalleEmisionServicioCable_DocumentoElectronico");

                entity.HasOne(d => d.IdusuarioCobradorNavigation)
                    .WithMany(p => p.DetalleEmisionServicioCableIdusuarioCobradorNavigations)
                    .HasForeignKey(d => d.IdusuarioCobrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEmisionServicioCable_UsuarioCobrador");

                entity.HasOne(d => d.IdusuarioCreadorNavigation)
                    .WithMany(p => p.DetalleEmisionServicioCableIdusuarioCreadorNavigations)
                    .HasForeignKey(d => d.IdusuarioCreador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEmisionServicioCable_UsuarioCreador");

                entity.HasOne(d => d.IdusuarioSincronizadorNavigation)
                    .WithMany(p => p.DetalleEmisionServicioCableIdusuarioSincronizadorNavigations)
                    .HasForeignKey(d => d.IdusuarioSincronizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEmisionServicioCable_UsuarioSincronizador");

                entity.HasOne(d => d.IduusarioAnuladorNavigation)
                    .WithMany(p => p.DetalleEmisionServicioCableIduusarioAnuladorNavigations)
                    .HasForeignKey(d => d.IduusarioAnulador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEmisionServicioCable_UsuarioAnulador");

                entity.HasOne(d => d.Suscripcion)
                    .WithMany(p => p.DetalleEmisionServicioCables)
                    .HasForeignKey(d => new { d.DblCodigoSuscripcion, d.StrIdsucursal })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEmisionServicioCable_Suscripcion");

                entity.HasOne(d => d.EmisionServicioCable)
                    .WithMany(p => p.DetalleEmisionServicioCables)
                    .HasForeignKey(d => new { d.IdemisionCable, d.StrIdsucursal })
                    .HasConstraintName("FK_DetalleEmisionServicioCable_EmisionServicioCable");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.DetalleEmisionServicioCables)
                    .HasForeignKey(d => new { d.IdpuntoAccesoCobro, d.IdsucursalCobro })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleEmisionServicioCable_PuntoAcceso");
            });

            modelBuilder.Entity<Deuda>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DEUDAS");

                entity.Property(e => e.Deuda1).HasColumnName("DEUDA");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(255)
                    .HasColumnName("NOMBRES");
            });

            modelBuilder.Entity<DocumentoElectronico>(entity =>
            {
                entity.HasKey(e => e.IddocumentoElectronico)
                    .HasName("PK_DocumentoElectronico_1");

                entity.ToTable("DocumentoElectronico");

                entity.Property(e => e.IddocumentoElectronico).HasColumnName("IDDocumentoElectronico");

                entity.Property(e => e.Ambiente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClaveAcceso)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionMatriz)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionSucursal)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAutorizacion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MensajeAdicionalAutorizacion)
                    .IsRequired()
                    .HasMaxLength(750)
                    .IsUnicode(false);

                entity.Property(e => e.MensajeAutorizacion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MensajeRecepcion)
                    .IsRequired()
                    .HasMaxLength(750)
                    .IsUnicode(false);

                entity.Property(e => e.NombreComercial)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NroContribuyenteEspecial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroAutorizacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroSerial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObligadoContabilidad)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RespuestaRecepcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Ruc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmisionServicioCable>(entity =>
            {
                entity.HasKey(e => new { e.IdemisionCable, e.StrIdsucursal });

                entity.ToTable("EmisionServicioCable");

                entity.Property(e => e.IdemisionCable).HasColumnName("IDEmisionCable");

                entity.Property(e => e.StrIdsucursal)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.Property(e => e.FechaEmision).HasColumnType("datetime");

                entity.Property(e => e.IdanioConsumo).HasColumnName("IDAnioConsumo");

                entity.Property(e => e.IdanioGenracion).HasColumnName("IDAnioGenracion");

                entity.Property(e => e.IdmesCosnumo).HasColumnName("IDMesCosnumo");

                entity.Property(e => e.IdmesGeneracion).HasColumnName("IDMesGeneracion");

                entity.Property(e => e.IdpuntoAccesoGenera).HasColumnName("IDPuntoAccesoGenera");

                entity.Property(e => e.IdsucursalGenera)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDSucursalGenera");

                entity.Property(e => e.IdusuarioCreador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUsuarioCreador");

                entity.Property(e => e.ObservacionesEmision)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdusuarioCreadorNavigation)
                    .WithMany(p => p.EmisionServicioCables)
                    .HasForeignKey(d => d.IdusuarioCreador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmisionServicioCable_Usuario");

                entity.HasOne(d => d.StrIdsucursalNavigation)
                    .WithMany(p => p.EmisionServicioCables)
                    .HasForeignKey(d => d.StrIdsucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmisionServicioCable_Sucursal1");

                entity.HasOne(d => d.Id)
                    .WithMany(p => p.EmisionServicioCableIds)
                    .HasForeignKey(d => new { d.IdanioConsumo, d.IdmesCosnumo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmisionServicioCable_AnioMesConsumo");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.EmisionServicioCableIdNavigations)
                    .HasForeignKey(d => new { d.IdanioGenracion, d.IdmesGeneracion })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmisionServicioCable_AnioMesGeneracion");

                entity.HasOne(d => d.Id1)
                    .WithMany(p => p.EmisionServicioCables)
                    .HasForeignKey(d => new { d.IdpuntoAccesoGenera, d.IdsucursalGenera })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmisionServicioCable_PuntoAccesoGenera");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.StrCedulaRuc);

                entity.ToTable("Empleado");

                entity.Property(e => e.StrCedulaRuc)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("strCedulaRuc");

                entity.Property(e => e.BlnActivo).HasColumnName("blnActivo");

                entity.Property(e => e.DblSueldo).HasColumnName("dblSueldo");

                entity.Property(e => e.DtFechaEgreso)
                    .HasColumnType("datetime")
                    .HasColumnName("dtFechaEgreso");

                entity.Property(e => e.DtFechaIngreso)
                    .HasColumnType("datetime")
                    .HasColumnName("dtFechaIngreso");

                entity.Property(e => e.ImgFoto)
                    .HasColumnType("image")
                    .HasColumnName("imgFoto");

                entity.Property(e => e.StrApellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strApellidos");

                entity.Property(e => e.StrCargo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strCargo");

                entity.Property(e => e.StrDireccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDireccion");

                entity.Property(e => e.StrEmail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("strEMail");

                entity.Property(e => e.StrIdciudad)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDCiudad");

                entity.Property(e => e.StrIdsexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("strIDSexo")
                    .IsFixedLength(true);

                entity.Property(e => e.StrIdsucursalPertenece)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursalPertenece");

                entity.Property(e => e.StrMovil)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("strMovil");

                entity.Property(e => e.StrNombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strNombres");

                entity.Property(e => e.StrObservaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strObservaciones");

                entity.Property(e => e.StrTelefono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("strTelefono");

                entity.HasOne(d => d.StrIdciudadNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.StrIdciudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Ciudad");

                entity.HasOne(d => d.StrIdsexoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.StrIdsexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Sexo");

                entity.HasOne(d => d.StrIdsucursalPerteneceNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.StrIdsucursalPertenece)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Sucursal");
            });

            modelBuilder.Entity<EquipoEnlaceCliente>(entity =>
            {
                entity.HasKey(e => e.Idequipo);

                entity.ToTable("EquipoEnlaceCliente");

                entity.Property(e => e.Idequipo).HasColumnName("IDEquipo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DireccionMAC");

                entity.Property(e => e.FechaCompra).HasColumnType("datetime");

                entity.Property(e => e.IdtipoEquipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IDTipoEquipo");

                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.Property(e => e.Marca)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroSerie)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdtipoEquipoNavigation)
                    .WithMany(p => p.EquipoEnlaceClientes)
                    .HasForeignKey(d => d.IdtipoEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipoEnlaceCliente_TipoEquipo");
            });

            modelBuilder.Entity<EstadoSuscripcion>(entity =>
            {
                entity.HasKey(e => e.IdestadoSuscripcion);

                entity.ToTable("EstadoSuscripcion");

                entity.Property(e => e.IdestadoSuscripcion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDEstadoSuscripcion");

                entity.Property(e => e.DescripcionEstadoSuscripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FacturaServicio>(entity =>
            {
                entity.HasKey(e => new { e.IdemisionCable, e.StrIdsucursal, e.DblCodigoSuscripcion, e.IdservicioAdicional });

                entity.ToTable("FacturaServicio");

                entity.Property(e => e.IdemisionCable).HasColumnName("IDEmisionCable");

                entity.Property(e => e.StrIdsucursal)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.Property(e => e.DblCodigoSuscripcion).HasColumnName("dblCodigoSuscripcion");

                entity.Property(e => e.IdservicioAdicional).HasColumnName("IDServicioAdicional");

                entity.Property(e => e.AplicaIva).HasColumnName("AplicaIVA");

                entity.Property(e => e.CostoServicio).HasColumnType("money");

                entity.Property(e => e.SubtotalAplicaIva)
                    .HasColumnName("SubtotalAplicaIVA")
                    .HasComputedColumnSql("(case when [AplicaIVA]=(1) then [Cantidad]*[CostoServicio] else (0) end)", false);

                entity.Property(e => e.SubtotalNoAplicaIva)
                    .HasColumnName("SubtotalNoAplicaIVA")
                    .HasComputedColumnSql("(case when [AplicaIVA]=(0) then [Cantidad]*[CostoServicio] else (0) end)", false);

                entity.HasOne(d => d.IdservicioAdicionalNavigation)
                    .WithMany(p => p.FacturaServicios)
                    .HasForeignKey(d => d.IdservicioAdicional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FacturaServicio_ServicioAdicional");

                entity.HasOne(d => d.DetalleEmisionServicioCable)
                    .WithMany(p => p.FacturaServicios)
                    .HasForeignKey(d => new { d.IdemisionCable, d.StrIdsucursal, d.DblCodigoSuscripcion })
                    .HasConstraintName("FK_FacturaServicio_DetalleEmisionServicioCable");
            });

            modelBuilder.Entity<GrupoUsuario>(entity =>
            {
                entity.HasKey(e => e.Idgrupo);

                entity.Property(e => e.Idgrupo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDGrupo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImagenSuscripcion>(entity =>
            {
                entity.HasKey(e => e.ImagenId);

                entity.ToTable("ImagenSuscripcion");

                entity.Property(e => e.ImagenId).HasColumnName("imagen_id");

                entity.Property(e => e.DblCodigoSuscripcion).HasColumnName("dblCodigoSuscripcion");

                entity.Property(e => e.ImagenDescripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("imagen_descripcion");

                entity.Property(e => e.ImagenPrincipal).HasColumnName("imagen_principal");

                entity.Property(e => e.ImagenValue)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("imagen_value");

                entity.Property(e => e.StrIdsucursal)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.HasOne(d => d.Suscripcion)
                    .WithMany(p => p.ImagenSuscripcions)
                    .HasForeignKey(d => new { d.DblCodigoSuscripcion, d.StrIdsucursal })
                    .HasConstraintName("FK_ImagenSuscripcion_Suscripcion");
            });

            modelBuilder.Entity<Me>(entity =>
            {
                entity.HasKey(e => e.Idmes);

                entity.Property(e => e.Idmes)
                    .ValueGeneratedNever()
                    .HasColumnName("IDMes");

                entity.Property(e => e.DescripcionMes)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModuloSistema>(entity =>
            {
                entity.HasKey(e => e.Idmodulo);

                entity.ToTable("ModuloSistema");

                entity.Property(e => e.Idmodulo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDModulo");

                entity.Property(e => e.DescripcionModulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParametroApp>(entity =>
            {
                entity.HasKey(e => e.IdParametro);

                entity.ToTable("ParametroApp");

                entity.Property(e => e.IdParametro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID_PARAMETRO");

                entity.Property(e => e.ValorParametro)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("VALOR_PARAMETRO");
            });

            modelBuilder.Entity<PermisoGrupo>(entity =>
            {
                entity.HasKey(e => new { e.Idgrupo, e.Idproceso });

                entity.ToTable("PermisoGrupo");

                entity.Property(e => e.Idgrupo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDGrupo");

                entity.Property(e => e.Idproceso)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("IDProceso");

                entity.HasOne(d => d.IdgrupoNavigation)
                    .WithMany(p => p.PermisoGrupos)
                    .HasForeignKey(d => d.Idgrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PermisoGrupo_GrupoUsuarios");

                entity.HasOne(d => d.IdprocesoNavigation)
                    .WithMany(p => p.PermisoGrupos)
                    .HasForeignKey(d => d.Idproceso)
                    .HasConstraintName("FK_PermisoGrupo_ProcesoSistema");
            });

            modelBuilder.Entity<ProcesoSistema>(entity =>
            {
                entity.HasKey(e => e.Idproceso);

                entity.ToTable("ProcesoSistema");

                entity.Property(e => e.Idproceso)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("IDProceso");

                entity.Property(e => e.DescripcionProceso)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdcategoriaProceso).HasColumnName("IDCategoriaProceso");

                entity.HasOne(d => d.IdcategoriaProcesoNavigation)
                    .WithMany(p => p.ProcesoSistemas)
                    .HasForeignKey(d => d.IdcategoriaProceso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProcesoSistema_CategoriaProcesoSistema");
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.HasKey(e => e.StrIdprovincia);

                entity.Property(e => e.StrIdprovincia)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDProvincia");

                entity.Property(e => e.StrDescripcionProvincia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionProvincia");

                entity.Property(e => e.StrObservaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strObservaciones");
            });

            modelBuilder.Entity<PuntoAcceso>(entity =>
            {
                entity.HasKey(e => new { e.IntIdpuntoAcceso, e.StrIdsucursal });

                entity.ToTable("PuntoAcceso");

                entity.Property(e => e.IntIdpuntoAcceso).HasColumnName("intIDPuntoAcceso");

                entity.Property(e => e.StrIdsucursal)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.Property(e => e.BlnActivo).HasColumnName("blnActivo");

                entity.Property(e => e.StrDescripcionPunto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionPunto");

                entity.Property(e => e.StrObservaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strObservaciones");

                entity.HasOne(d => d.StrIdsucursalNavigation)
                    .WithMany(p => p.PuntoAccesos)
                    .HasForeignKey(d => d.StrIdsucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoAcceso_Sucursal1");
            });

            modelBuilder.Entity<PuntoAccesoServicio>(entity =>
            {
                entity.HasKey(e => e.IdpuntoAcceso);

                entity.ToTable("PuntoAccesoServicio");

                entity.Property(e => e.IdpuntoAcceso).HasColumnName("IDPuntoAcceso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionMac)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DireccionMAC");

                entity.Property(e => e.EquipoFrecuencia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("equipo_frecuencia");

                entity.Property(e => e.EquipoIp)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("equipo_ip");

                entity.Property(e => e.EquipoMaxClientes).HasColumnName("equipo_max_clientes");

                entity.Property(e => e.EquipoModo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("equipo_modo");

                entity.Property(e => e.EquipoNumSuscriptores)
                    .HasColumnName("equipo_num_suscriptores")
                    .HasComputedColumnSql("([dbo].[numero_suscripciones_by_ap]([IDPuntoAcceso]))", false);

                entity.Property(e => e.EquipoSsid)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("equipo_ssid");

                entity.Property(e => e.EquipoSsidPassword)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("equipo_ssid_password");

                entity.Property(e => e.EquipoUserAdmin)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("equipo_user_admin");

                entity.Property(e => e.EquipoUserAdminPassword)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("equipo_user_admin_password");

                entity.Property(e => e.FechaCompra).HasColumnType("datetime");

                entity.Property(e => e.IdtipoEquipo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IDTipoEquipo");

                entity.Property(e => e.Idubicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDUbicacion");

                entity.Property(e => e.Imagen).HasColumnType("image");

                entity.Property(e => e.Marca)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroSerie)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ServidorId).HasColumnName("servidor_id");

                entity.Property(e => e.TorreId).HasColumnName("torre_id");

                entity.HasOne(d => d.IdtipoEquipoNavigation)
                    .WithMany(p => p.PuntoAccesoServicios)
                    .HasForeignKey(d => d.IdtipoEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoAccesoServicio_TipoEquipo");

                entity.HasOne(d => d.IdubicacionNavigation)
                    .WithMany(p => p.PuntoAccesoServicios)
                    .HasForeignKey(d => d.Idubicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PuntoAccesoServicio_UbicacionEnlace1");

                entity.HasOne(d => d.Servidor)
                    .WithMany(p => p.PuntoAccesoServicios)
                    .HasForeignKey(d => d.ServidorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PuntoAccesoServicio_Servidor");

                entity.HasOne(d => d.Torre)
                    .WithMany(p => p.PuntoAccesoServicios)
                    .HasForeignKey(d => d.TorreId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PuntoAccesoServicio_TorreDistribucion");
            });

            modelBuilder.Entity<SectorCiudad>(entity =>
            {
                entity.HasKey(e => e.Idsector)
                    .HasName("PK_SectorCiudad_1");

                entity.ToTable("SectorCiudad");

                entity.Property(e => e.Idsector)
                    .ValueGeneratedNever()
                    .HasColumnName("IDSector");

                entity.Property(e => e.DescripcionSector)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Referencia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StrIdciudad)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDCiudad");

                entity.HasOne(d => d.StrIdciudadNavigation)
                    .WithMany(p => p.SectorCiudads)
                    .HasForeignKey(d => d.StrIdciudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SectorCiudad_Ciudad");
            });

            modelBuilder.Entity<ServicioAdicional>(entity =>
            {
                entity.HasKey(e => e.IdservicioAdicional);

                entity.ToTable("ServicioAdicional");

                entity.Property(e => e.IdservicioAdicional)
                    .ValueGeneratedNever()
                    .HasColumnName("IDServicioAdicional");

                entity.Property(e => e.AplicaIva).HasColumnName("AplicaIVA");

                entity.Property(e => e.CostoServicioAdicional).HasColumnType("money");

                entity.Property(e => e.DescripcionServicioAdicional)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacionesServicioAdicional)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServicioSuscripcion>(entity =>
            {
                entity.HasKey(e => new { e.StrIdsucursal, e.DblCodigoSuscripcion, e.IdservicioAdicional });

                entity.ToTable("ServicioSuscripcion");

                entity.Property(e => e.StrIdsucursal)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.Property(e => e.DblCodigoSuscripcion).HasColumnName("dblCodigoSuscripcion");

                entity.Property(e => e.IdservicioAdicional).HasColumnName("IDServicioAdicional");

                entity.HasOne(d => d.IdservicioAdicionalNavigation)
                    .WithMany(p => p.ServicioSuscripcions)
                    .HasForeignKey(d => d.IdservicioAdicional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicioSuscripcion_ServicioAdicional");

                entity.HasOne(d => d.Suscripcion)
                    .WithMany(p => p.ServicioSuscripcions)
                    .HasForeignKey(d => new { d.DblCodigoSuscripcion, d.StrIdsucursal })
                    .HasConstraintName("FK_ServicioSuscripcion_Suscripcion");
            });

            modelBuilder.Entity<Servidor>(entity =>
            {
                entity.ToTable("Servidor");

                entity.Property(e => e.ServidorId).HasColumnName("servidor_id");

                entity.Property(e => e.ServidorIpv4)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servidor_ipv4");

                entity.Property(e => e.ServidorIpv6)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("servidor_ipv6");

                entity.Property(e => e.ServidorMacAddress)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("servidor_mac_address");

                entity.Property(e => e.ServidorMarca)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("servidor_marca");

                entity.Property(e => e.ServidorNombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("servidor_nombre");

                entity.Property(e => e.ServidorObservaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("servidor_observaciones");

                entity.Property(e => e.ServidorPassword)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("servidor_password");

                entity.Property(e => e.ServidorPuerto).HasColumnName("servidor_puerto");

                entity.Property(e => e.ServidorUser)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("servidor_user");
            });

            modelBuilder.Entity<Sexo>(entity =>
            {
                entity.HasKey(e => e.StrId);

                entity.ToTable("Sexo");

                entity.Property(e => e.StrId)
                    .HasMaxLength(1)
                    .HasColumnName("strID")
                    .IsFixedLength(true);

                entity.Property(e => e.StrDescripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcion");
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.HasKey(e => e.StrIdsucursal);

                entity.ToTable("Sucursal");

                entity.Property(e => e.StrIdsucursal)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.Property(e => e.DblLatitud).HasColumnName("dblLatitud");

                entity.Property(e => e.DblLongitud).HasColumnName("dblLongitud");

                entity.Property(e => e.ImgFoto)
                    .HasColumnType("image")
                    .HasColumnName("imgFoto");

                entity.Property(e => e.StrCedulaResponsable)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("strCedulaResponsable");

                entity.Property(e => e.StrDescripcionSucursal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionSucursal");

                entity.Property(e => e.StrDireccionSucursal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDireccionSucursal");

                entity.Property(e => e.StrEmail)
                    .HasMaxLength(10)
                    .HasColumnName("strEmail")
                    .IsFixedLength(true);

                entity.Property(e => e.StrFax)
                    .HasMaxLength(10)
                    .HasColumnName("strFax")
                    .IsFixedLength(true);

                entity.Property(e => e.StrIdciudad)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDCiudad");

                entity.Property(e => e.StrMovil)
                    .HasMaxLength(10)
                    .HasColumnName("strMovil")
                    .IsFixedLength(true);

                entity.Property(e => e.StrTelefono)
                    .HasMaxLength(10)
                    .HasColumnName("strTelefono")
                    .IsFixedLength(true);

                entity.HasOne(d => d.StrCedulaResponsableNavigation)
                    .WithMany(p => p.Sucursals)
                    .HasForeignKey(d => d.StrCedulaResponsable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sucursal_Empleado");

                entity.HasOne(d => d.StrIdciudadNavigation)
                    .WithMany(p => p.Sucursals)
                    .HasForeignKey(d => d.StrIdciudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sucursal_Ciudad");
            });

            modelBuilder.Entity<Suscripcion>(entity =>
            {
                entity.HasKey(e => new { e.DblCodigoSuscripcion, e.StrIdsucursal });

                entity.ToTable("Suscripcion");

                entity.Property(e => e.DblCodigoSuscripcion).HasColumnName("dblCodigoSuscripcion");

                entity.Property(e => e.StrIdsucursal)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.Property(e => e.DireccionSuscripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaSuscripcion).HasColumnType("datetime");

                entity.Property(e => e.IdequipoCliente).HasColumnName("IDEquipoCliente");

                entity.Property(e => e.IdestadoSuscripcion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDEstadoSuscripcion");

                entity.Property(e => e.IdpuntoAcceso).HasColumnName("IDPuntoAcceso");

                entity.Property(e => e.ImgFotoInstalacion)
                    .HasColumnType("image")
                    .HasColumnName("imgFotoInstalacion");

                entity.Property(e => e.Ipv4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IPV4");

                entity.Property(e => e.Ipv6)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IPV6");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordCliente)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenciaSuscripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StrCedulaUsuarioCreador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("strCedulaUsuarioCreador");

                entity.Property(e => e.StrIdsector).HasColumnName("strIDSector");

                entity.Property(e => e.TipoSuscripcionId).HasColumnName("tipo_suscripcion_id");

                entity.Property(e => e.Urlconsumo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("URLConsumo");

                entity.HasOne(d => d.CodigoSuscriptorNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.CodigoSuscriptor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suscripcion_Suscriptor");

                entity.HasOne(d => d.IdequipoClienteNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.IdequipoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suscripcion_EquipoEnlaceCliente");

                entity.HasOne(d => d.IdestadoSuscripcionNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.IdestadoSuscripcion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suscripcion_EstadoSuscripcion");

                entity.HasOne(d => d.IdpuntoAccesoNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.IdpuntoAcceso)
                    .HasConstraintName("FK_Suscripcion_PuntoAccesoServicio");

                entity.HasOne(d => d.StrCedulaUsuarioCreadorNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.StrCedulaUsuarioCreador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suscripcion_Usuario");

                entity.HasOne(d => d.StrIdsectorNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.StrIdsector)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suscripcion_SectorCiudad");

                entity.HasOne(d => d.StrIdsucursalNavigation)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.StrIdsucursal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suscripcion_Sucursal");

                entity.HasOne(d => d.TipoSuscripcion)
                    .WithMany(p => p.Suscripcions)
                    .HasForeignKey(d => d.TipoSuscripcionId)
                    .HasConstraintName("FK_Suscripcion_TipoSuscripcion");
            });

            modelBuilder.Entity<Suscriptor>(entity =>
            {
                entity.HasKey(e => e.DblCodigoSuscriptor);

                entity.ToTable("Suscriptor");

                entity.Property(e => e.DblCodigoSuscriptor).HasColumnName("dblCodigoSuscriptor");

                entity.Property(e => e.BlnActivo).HasColumnName("blnActivo");

                entity.Property(e => e.BlnPersonaNatural).HasColumnName("blnPersonaNatural");

                entity.Property(e => e.DblPorcentajeDescuento).HasColumnName("dblPorcentajeDescuento");

                entity.Property(e => e.ImgFoto)
                    .HasColumnType("image")
                    .HasColumnName("imgFoto");

                entity.Property(e => e.StrApellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strApellidos");

                entity.Property(e => e.StrCedulaRuc)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("strCedulaRuc");

                entity.Property(e => e.StrDireccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDireccion");

                entity.Property(e => e.StrEmail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("strEMail");

                entity.Property(e => e.StrIdciudad)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDCiudad");

                entity.Property(e => e.StrIdsexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("strIDSexo")
                    .IsFixedLength(true);

                entity.Property(e => e.StrMovil)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("strMovil");

                entity.Property(e => e.StrNombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strNombres");

                entity.Property(e => e.StrObservaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strObservaciones");

                entity.Property(e => e.StrRazonSocial)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strRazonSocial");

                entity.Property(e => e.StrTelefono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("strTelefono");

                entity.HasOne(d => d.StrIdciudadNavigation)
                    .WithMany(p => p.Suscriptors)
                    .HasForeignKey(d => d.StrIdciudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suscriptor_Ciudad");

                entity.HasOne(d => d.StrIdsexoNavigation)
                    .WithMany(p => p.Suscriptors)
                    .HasForeignKey(d => d.StrIdsexo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Suscriptor_Sexo");
            });

            modelBuilder.Entity<TipoEquipo>(entity =>
            {
                entity.HasKey(e => e.IdtipoEquipo);

                entity.ToTable("TipoEquipo");

                entity.Property(e => e.IdtipoEquipo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IDTipoEquipo");

                entity.Property(e => e.DescripcionTipo)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacionesTipo)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoSuscripcion>(entity =>
            {
                entity.HasKey(e => e.TipoId);

                entity.ToTable("TipoSuscripcion");

                entity.Property(e => e.TipoId)
                    .ValueGeneratedNever()
                    .HasColumnName("tipo_id");

                entity.Property(e => e.TipoDescripcion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("tipo_descripcion");
            });

            modelBuilder.Entity<TorreDistribucion>(entity =>
            {
                entity.HasKey(e => e.TorreId);

                entity.ToTable("TorreDistribucion");

                entity.Property(e => e.TorreId).HasColumnName("torre_id");

                entity.Property(e => e.TorreDescripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("torre_descripcion");

                entity.Property(e => e.TorreImagen)
                    .HasColumnType("image")
                    .HasColumnName("torre_imagen");

                entity.Property(e => e.TorreLatitud).HasColumnName("torre_latitud");

                entity.Property(e => e.TorreLongitud).HasColumnName("torre_longitud");

                entity.Property(e => e.TorreNumSuscriptores)
                    .HasColumnName("torre_num_suscriptores")
                    .HasComputedColumnSql("([dbo].[numero_suscripciones_by_torre]([torre_id]))", false);

                entity.Property(e => e.TorreObservaciones)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("torre_observaciones");

                entity.Property(e => e.TorreTiempoReservaBaterias)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("torre_tiempo_reserva_baterias");

                entity.Property(e => e.TorreUbicacionId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("torre_ubicacion_id");

                entity.HasOne(d => d.TorreUbicacion)
                    .WithMany(p => p.TorreDistribucions)
                    .HasForeignKey(d => d.TorreUbicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TorreDistribucion_UbicacionEnlace");
            });

            modelBuilder.Entity<TrackinSuscripcionImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("TrackinSuscripcion_Images");

                entity.Property(e => e.ImageId)
                    .ValueGeneratedNever()
                    .HasColumnName("image_id");

                entity.Property(e => e.ImageDescription)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("image_description");

                entity.Property(e => e.ImageTrackingId).HasColumnName("image_tracking_id");

                entity.Property(e => e.ImageValue)
                    .IsRequired()
                    .HasColumnType("image")
                    .HasColumnName("image_value");

                entity.HasOne(d => d.ImageTracking)
                    .WithMany(p => p.TrackinSuscripcionImages)
                    .HasForeignKey(d => d.ImageTrackingId)
                    .HasConstraintName("FK_TrackinSuscripcion_Images_TrackingSuscripcion");
            });

            modelBuilder.Entity<TrackingSuscripcion>(entity =>
            {
                entity.HasKey(e => e.Idtracking);

                entity.ToTable("TrackingSuscripcion");

                entity.Property(e => e.Idtracking).HasColumnName("IDTracking");

                entity.Property(e => e.DblCodigoSuscripcion).HasColumnName("dblCodigoSuscripcion");

                entity.Property(e => e.Evento)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAtencion).HasColumnType("datetime");

                entity.Property(e => e.FechaRegistro).HasColumnType("datetime");

                entity.Property(e => e.IdempleadoAsignado)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDEmpleadoAsignado");

                entity.Property(e => e.IdusuarioCrea)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUsuarioCrea");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StrIdsucursal)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.HasOne(d => d.IdempleadoAsignadoNavigation)
                    .WithMany(p => p.TrackingSuscripcions)
                    .HasForeignKey(d => d.IdempleadoAsignado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrackingSuscripcion_Empleado");

                entity.HasOne(d => d.IdusuarioCreaNavigation)
                    .WithMany(p => p.TrackingSuscripcions)
                    .HasForeignKey(d => d.IdusuarioCrea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TrackingSuscripcion_Usuario");

                entity.HasOne(d => d.Suscripcion)
                    .WithMany(p => p.TrackingSuscripcions)
                    .HasForeignKey(d => new { d.DblCodigoSuscripcion, d.StrIdsucursal })
                    .HasConstraintName("FK_TrackingSuscripcion_Suscripcion");
            });

            modelBuilder.Entity<UbicacionEnlace>(entity =>
            {
                entity.HasKey(e => e.Idubicacion);

                entity.ToTable("UbicacionEnlace");

                entity.Property(e => e.Idubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IDUbicacion");

                entity.Property(e => e.DescripcionUbicacion)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CedulaEmpleado);

                entity.ToTable("Usuario");

                entity.Property(e => e.CedulaEmpleado)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.CedulaEmpleadoNavigation)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.CedulaEmpleado)
                    .HasConstraintName("FK_Usuario_Empleado");
            });

            modelBuilder.Entity<UsuarioGrupo>(entity =>
            {
                entity.HasKey(e => new { e.CedulaUsuario, e.Idgrupo });

                entity.ToTable("UsuarioGrupo");

                entity.Property(e => e.CedulaUsuario)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Idgrupo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IDGrupo");

                entity.HasOne(d => d.CedulaUsuarioNavigation)
                    .WithMany(p => p.UsuarioGrupos)
                    .HasForeignKey(d => d.CedulaUsuario)
                    .HasConstraintName("FK_UsuarioGrupo_Usuario");

                entity.HasOne(d => d.IdgrupoNavigation)
                    .WithMany(p => p.UsuarioGrupos)
                    .HasForeignKey(d => d.Idgrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioGrupo_GrupoUsuarios");
            });

            modelBuilder.Entity<VwDeudasGenerale>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_DeudasGenerales");

                entity.Property(e => e.ApellidosSuscriptor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Baseimponiblefactura).HasColumnName("BASEIMPONIBLEFACTURA");

                entity.Property(e => e.CedulaRucsuscriptor)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CedulaRUCSuscriptor");

                entity.Property(e => e.CiudadSector)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CobrosAdicionales).HasColumnType("money");

                entity.Property(e => e.CostoEquiposAdicionalesFactura).HasColumnType("money");

                entity.Property(e => e.CostoEquiposIncluidosFactura).HasColumnType("money");

                entity.Property(e => e.DblCodigoSuscripcion).HasColumnName("dblCodigoSuscripcion");

                entity.Property(e => e.DescripcionEstadoSuscripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionSector)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DescuentoAplicado).HasColumnType("money");

                entity.Property(e => e.Descuentoconivafactura).HasColumnName("DESCUENTOCONIVAFACTURA");

                entity.Property(e => e.Descuentosinivafactura).HasColumnName("DESCUENTOSINIVAFACTURA");

                entity.Property(e => e.Descuentototalfactura).HasColumnName("DESCUENTOTOTALFACTURA");

                entity.Property(e => e.DireccionSuscripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionSuscriptor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmailSuscriptor)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAnulacion).HasColumnType("datetime");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.FechaSicronizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaSuscripcion).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.Icecobradofactura).HasColumnName("ICECOBRADOFACTURA");

                entity.Property(e => e.IdemisionCable).HasColumnName("IDEmisionCable");

                entity.Property(e => e.IdestadoSuscripcion)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDEstadoSuscripcion");

                entity.Property(e => e.IdpuntoAccesoCobro).HasColumnName("IDPuntoAccesoCobro");

                entity.Property(e => e.IdsucursalCobro)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDSucursalCobro");

                entity.Property(e => e.IdusuarioCobrador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUsuarioCobrador");

                entity.Property(e => e.IdusuarioCreador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUsuarioCreador");

                entity.Property(e => e.IdusuarioSincronizador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUsuarioSincronizador");

                entity.Property(e => e.IduusarioAnulador)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("IDUusarioAnulador");

                entity.Property(e => e.Ivacobrado).HasColumnName("IVACobrado");

                entity.Property(e => e.Ivacobradofactura).HasColumnName("IVACOBRADOFACTURA");

                entity.Property(e => e.MesAnioConsumo)
                    .IsRequired()
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.MesAnioGeneracion)
                    .IsRequired()
                    .HasMaxLength(152)
                    .IsUnicode(false);

                entity.Property(e => e.MovilSuscriptor)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NombresSuscriptor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacionesFactura)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacionesSuscripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ObservacionesSuscriptor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajeIvaaplicado).HasColumnName("PorcentajeIVAAplicado");

                entity.Property(e => e.PuntoAccesoCobro)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocialSuscriptor)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenciaSuscripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StrDescripcionSucursal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionSucursal");

                entity.Property(e => e.StrIdsector).HasColumnName("strIDSector");

                entity.Property(e => e.StrIdsucursal)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.Property(e => e.SubtotalConIva)
                    .HasColumnType("money")
                    .HasColumnName("SubtotalConIVA");

                entity.Property(e => e.SubtotalSinIva)
                    .HasColumnType("money")
                    .HasColumnName("SubtotalSinIVA");

                entity.Property(e => e.Subtotalconivafactura).HasColumnName("SUBTOTALCONIVAFACTURA");

                entity.Property(e => e.Subtotalserviciosconiva).HasColumnName("SUBTOTALSERVICIOSCONIVA");

                entity.Property(e => e.Subtotalserviciossiniva).HasColumnName("SUBTOTALSERVICIOSSINIVA");

                entity.Property(e => e.Subtotalsinivafactura).HasColumnName("SUBTOTALSINIVAFACTURA");

                entity.Property(e => e.Suscriptor)
                    .IsRequired()
                    .HasMaxLength(201)
                    .IsUnicode(false);

                entity.Property(e => e.Tag3).HasColumnType("money");

                entity.Property(e => e.TelefonoSuscriptor)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Totalapagar).HasColumnName("TOTALAPAGAR");

                entity.Property(e => e.UserIdcobrador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserIDCobrador");

                entity.Property(e => e.UserIdcreador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserIDCreador");

                entity.Property(e => e.UserIdsincronizador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserIDSincronizador");

                entity.Property(e => e.UserIdusuarioAnulador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserIDUsuarioAnulador");

                entity.Property(e => e.UsuarioAnulador)
                    .IsRequired()
                    .HasMaxLength(201)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCobrador)
                    .IsRequired()
                    .HasMaxLength(201)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreador)
                    .IsRequired()
                    .HasMaxLength(201)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioSincronizador)
                    .IsRequired()
                    .HasMaxLength(202)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwImprimirNcPunto2Ebilling>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ImprimirNC_Punto2_Ebilling");

                entity.Property(e => e.Idanio).HasColumnName("IDAnio");
            });

            modelBuilder.Entity<VwImprimirNcPunto3Ebilling>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ImprimirNC_Punto3_Ebilling");

                entity.Property(e => e.DescripcionAnio)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwImprimirNcPunto4Ebilling>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ImprimirNC_Punto4_Ebilling");

                entity.Property(e => e.DescripcionAnio)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Idanio).HasColumnName("IDAnio");
            });

            modelBuilder.Entity<VwListaSuscripcione>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ListaSuscripciones");

                entity.Property(e => e.BlnActivo).HasColumnName("blnActivo");

                entity.Property(e => e.DblCodigoSuscripcion).HasColumnName("dblCodigoSuscripcion");

                entity.Property(e => e.DblPorcentajeDescuento).HasColumnName("dblPorcentajeDescuento");

                entity.Property(e => e.DescripcionSector)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionSuscripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ReferenciaSuscripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StrApellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strApellidos");

                entity.Property(e => e.StrCedulaRuc)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("strCedulaRuc");

                entity.Property(e => e.StrDescripcionSucursal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionSucursal");

                entity.Property(e => e.StrIdsector).HasColumnName("strIDSector");

                entity.Property(e => e.StrNombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strNombres");

                entity.Property(e => e.StrRazonSocial)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strRazonSocial");
            });

            modelBuilder.Entity<VwModeloConfiguracionPuntoAcceso>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_ModeloConfiguracionPuntoAcceso");

                entity.Property(e => e.IntIdpuntoAcceso).HasColumnName("intIDPuntoAcceso");

                entity.Property(e => e.ObservacionesPunto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Responsable)
                    .IsRequired()
                    .HasMaxLength(201)
                    .IsUnicode(false);

                entity.Property(e => e.StrCedulaResponsable)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("strCedulaResponsable");

                entity.Property(e => e.StrDescripcionCiudad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionCiudad");

                entity.Property(e => e.StrDescripcionProvincia)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionProvincia");

                entity.Property(e => e.StrDescripcionPunto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionPunto");

                entity.Property(e => e.StrDescripcionSucursal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionSucursal");

                entity.Property(e => e.StrDireccionSucursal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDireccionSucursal");

                entity.Property(e => e.StrIdsucursal)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");
            });

            modelBuilder.Entity<VwReporteGeneralRecuadacionFacElectronica>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwReporteGeneralRecuadacionFacElectronica");

                entity.Property(e => e.Ambiente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BaseImponible).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.ClaveAcceso)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionMatriz)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionSucursal)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAutorizacion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.IddocumentoElectronico).HasColumnName("IDDocumentoElectronico");

                entity.Property(e => e.Ipv4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IPV4");

                entity.Property(e => e.Ipv6)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IPV6");

                entity.Property(e => e.Ivacobrado)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("IVACobrado");

                entity.Property(e => e.MensajeAdicionalAutorizacion)
                    .IsRequired()
                    .HasMaxLength(750)
                    .IsUnicode(false);

                entity.Property(e => e.MensajeAutorizacion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.MensajeRecepcion)
                    .IsRequired()
                    .HasMaxLength(750)
                    .IsUnicode(false);

                entity.Property(e => e.NombreComercial)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NroContribuyenteEspecial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroAutorizacion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroSerial)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ObligadoContabilidad)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodoConsumo)
                    .IsRequired()
                    .HasMaxLength(151)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.RespuestaRecepcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Ruc)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StrApellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strApellidos");

                entity.Property(e => e.StrCedulaRuc)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("strCedulaRuc");

                entity.Property(e => e.StrDireccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDireccion");

                entity.Property(e => e.StrEmail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("strEMail");

                entity.Property(e => e.StrMovil)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("strMovil");

                entity.Property(e => e.StrNombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strNombres");

                entity.Property(e => e.StrRazonSocial)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strRazonSocial");

                entity.Property(e => e.StrTelefono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("strTelefono");

                entity.Property(e => e.TipoDocumentoElectronico)
                    .IsRequired()
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TotalFactura).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.TotalRecaudado).HasColumnType("decimal(10, 4)");
            });

            modelBuilder.Entity<VwValoresPagar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VW_valores_pagar");

                entity.Property(e => e.DblCodigoSuscripcion).HasColumnName("dblCodigoSuscripcion");

                entity.Property(e => e.DblCodigoSuscriptor).HasColumnName("dblCodigoSuscriptor");

                entity.Property(e => e.DescripcionSector)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DireccionSuscripcion)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.StrApellidos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strApellidos");

                entity.Property(e => e.StrCedulaRuc)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("strCedulaRuc");

                entity.Property(e => e.StrDescripcionSucursal)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("strDescripcionSucursal");

                entity.Property(e => e.StrIdsucursal)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("strIDSucursal");

                entity.Property(e => e.StrMovil)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("strMovil");

                entity.Property(e => e.StrNombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("strNombres");

                entity.Property(e => e.StrRazonSocial)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("strRazonSocial");

                entity.Property(e => e.StrTelefono)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("strTelefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
