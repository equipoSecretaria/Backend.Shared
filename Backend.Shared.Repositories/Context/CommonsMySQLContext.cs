﻿using Microsoft.EntityFrameworkCore;

namespace Backend.Shared.Repositories.Context
{
    public partial class CommonsMySQLContext : DbContext
    {
        public CommonsMySQLContext(DbContextOptions<CommonsMySQLContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entities.Models.Tramites.Persona> Persona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Models.Tramites.Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PRIMARY");

                entity.ToTable("persona");

                entity.HasIndex(e => e.NumeIdentificacion)
                    .HasName("nume_identificacion")
                    .IsUnique();

                entity.Property(e => e.IdPersona).HasColumnName("id_persona");

                entity.Property(e => e.Barrio)
                    .HasColumnName("barrio")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CiudadNacimiento).HasColumnName("ciudad_nacimiento");

                entity.Property(e => e.CiudadNacimientoOtro)
                    .HasColumnName("ciudad_nacimiento_otro")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CiudadResi).HasColumnName("ciudad_resi");

                entity.Property(e => e.Cx).HasColumnName("cx");

                entity.Property(e => e.Cy).HasColumnName("cy");

                entity.Property(e => e.DepaResi).HasColumnName("depa_resi");

                entity.Property(e => e.Departamento).HasColumnName("departamento");

                entity.Property(e => e.DirCodificada)
                    .IsRequired()
                    .HasColumnName("dir_codificada")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DireResi).HasColumnName("dire_resi");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil).HasColumnName("estado_civil");

                entity.Property(e => e.Estadogeo).HasColumnName("estadogeo");

                entity.Property(e => e.Etnia).HasColumnName("etnia");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.Localidad).HasColumnName("localidad");

                entity.Property(e => e.Nacionalidad).HasColumnName("nacionalidad");

                entity.Property(e => e.NivelEducativo).HasColumnName("nivel_educativo");

                entity.Property(e => e.NombreRs)
                    .HasColumnName("nombre_rs")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.NumeIdenRl).HasColumnName("nume_iden_rl");

                entity.Property(e => e.NumeIdentificacion).HasColumnName("nume_identificacion");

                entity.Property(e => e.Orientacion).HasColumnName("orientacion");

                entity.Property(e => e.PApellido)
                    .HasColumnName("p_apellido")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.PNombre)
                    .IsRequired()
                    .HasColumnName("p_nombre")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SApellido)
                    .HasColumnName("s_apellido")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.SNombre)
                    .IsRequired()
                    .HasColumnName("s_nombre")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo).HasColumnName("sexo");

                entity.Property(e => e.TelefonoCelular)
                    .IsRequired()
                    .HasColumnName("telefono_celular")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoFijo)
                    .IsRequired()
                    .HasColumnName("telefono_fijo")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdenRl).HasColumnName("tipo_iden_rl");

                entity.Property(e => e.TipoIdentificacion).HasColumnName("tipo_identificacion");

                entity.Property(e => e.Upz).HasColumnName("upz");

                entity.Property(e => e.Zona).HasColumnName("zona");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
