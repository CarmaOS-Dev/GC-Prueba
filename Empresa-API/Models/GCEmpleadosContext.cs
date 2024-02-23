using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Empresa_API.Models
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

        public virtual DbSet<TCatPuesto> TCatPuestos { get; set; } = null!;
        public virtual DbSet<TEmpleado> TEmpleados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=vboxserver;Initial Catalog=GCEmpleados;Persist Security Info=True;User ID=sa;Password=a123456.;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCatPuesto>(entity =>
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

            modelBuilder.Entity<TEmpleado>(entity =>
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
                    .WithMany(p => p.TEmpleados)
                    .HasForeignKey(d => d.Puesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Empleado_Puesto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
