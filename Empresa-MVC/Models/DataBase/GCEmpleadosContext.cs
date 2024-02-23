using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Empresa_MVC.Models.DataBase
{
    public partial class GCEmpleadosContext : DbContext
    {
        public GCEmpleadosContext()
        {
        }

        public GCEmpleadosContext(DbContextOptions<GCEmpleadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatPuesto> CatPuestos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatPuesto>(entity =>
            {
                entity.HasKey(e => e.IdPuesto)
                    .HasName("PK_Puesto");

                entity.ToTable("T-CAT-PUESTOS");

                entity.Property(e => e.IdPuesto).HasColumnName("Id_Puesto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Puesto)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdNumEmp)
                    .HasName("PK_Empleado");

                entity.ToTable("T-EMPLEADOS");

                entity.Property(e => e.IdNumEmp).HasColumnName("Id_NumEmp");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.PuestoNavigation)
                    .WithMany(p => p.Empleados)
                    .HasForeignKey(d => d.Puesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Puesto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
