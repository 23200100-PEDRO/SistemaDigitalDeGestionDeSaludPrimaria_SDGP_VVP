using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SDGP_VVP.Infrastructure.Data;

public partial class SDGP_VVPContext : DbContext
{
    public SDGP_VVPContext()
    {
    }

    public SDGP_VVPContext(DbContextOptions<SDGP_VVPContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admision> Admision { get; set; }

    public virtual DbSet<AgendaMedica> AgendaMedica { get; set; }

    public virtual DbSet<Auditoria> Auditoria { get; set; }

    public virtual DbSet<CitaMedica> CitaMedica { get; set; }

    public virtual DbSet<ConsultaMedica> ConsultaMedica { get; set; }

    public virtual DbSet<DetalleReceta> DetalleReceta { get; set; }

    public virtual DbSet<Diagnostico> Diagnostico { get; set; }

    public virtual DbSet<Enfermero> Enfermero { get; set; }

    public virtual DbSet<Especialidad> Especialidad { get; set; }

    public virtual DbSet<HistoriaClinica> HistoriaClinica { get; set; }

    public virtual DbSet<Medicamento> Medicamento { get; set; }

    public virtual DbSet<Medico> Medico { get; set; }

    public virtual DbSet<Paciente> Paciente { get; set; }

    public virtual DbSet<Receta> Receta { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<SignosVitales> SignosVitales { get; set; }

    public virtual DbSet<TecnicoFarmacia> TecnicoFarmacia { get; set; }

    public virtual DbSet<Triage> Triage { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PEDROLUIS-1409;Database=SDGP_VVP;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admision>(entity =>
        {
            entity.HasKey(e => e.IdAdmision).HasName("PK__Admision__9F5EC7394EBBCC9F");

            entity.HasIndex(e => e.IdUsuario, "UQ__Admision__5B65BF9669086AC4").IsUnique();

            entity.Property(e => e.CodigoEmpleado)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Admision)
                .HasForeignKey<Admision>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Admision_Usuario");
        });

        modelBuilder.Entity<AgendaMedica>(entity =>
        {
            entity.HasKey(e => e.IdAgenda).HasName("PK__AgendaMe__FACC499E08559BF5");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.AgendaMedica)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Agenda_Medico");
        });

        modelBuilder.Entity<Auditoria>(entity =>
        {
            entity.HasKey(e => e.IdAuditoria).HasName("PK__Auditori__7FD13FA0DB001D59");

            entity.Property(e => e.Accion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Detalle).IsUnicode(false);
            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auditoria_Usuario");
        });

        modelBuilder.Entity<CitaMedica>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__CitaMedi__394B02029913F645");

            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Pendiente");
            entity.Property(e => e.FechaReserva)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MotivoConsulta)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.TipoRegistro)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAgendaNavigation).WithMany(p => p.CitaMedica)
                .HasForeignKey(d => d.IdAgenda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cita_Agenda");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.CitaMedica)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cita_Paciente");
        });

        modelBuilder.Entity<ConsultaMedica>(entity =>
        {
            entity.HasKey(e => e.IdConsulta).HasName("PK__Consulta__9B2AD1D820F61313");

            entity.HasIndex(e => e.IdCita, "UQ__Consulta__394B020398AD011D").IsUnique();

            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Observaciones).IsUnicode(false);

            entity.HasOne(d => d.IdCitaNavigation).WithOne(p => p.ConsultaMedica)
                .HasForeignKey<ConsultaMedica>(d => d.IdCita)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consulta_Cita");

            entity.HasOne(d => d.IdHistoriaNavigation).WithMany(p => p.ConsultaMedica)
                .HasForeignKey(d => d.IdHistoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consulta_Historia");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.ConsultaMedica)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Consulta_Medico");
        });

        modelBuilder.Entity<DetalleReceta>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK__DetalleR__E43646A5103DA7CD");

            entity.Property(e => e.Dosis)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Duracion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Frecuencia)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMedicamentoNavigation).WithMany(p => p.DetalleReceta)
                .HasForeignKey(d => d.IdMedicamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleReceta_Medicamento");

            entity.HasOne(d => d.IdRecetaNavigation).WithMany(p => p.DetalleReceta)
                .HasForeignKey(d => d.IdReceta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleReceta_Receta");
        });

        modelBuilder.Entity<Diagnostico>(entity =>
        {
            entity.HasKey(e => e.IdDiagnostico).HasName("PK__Diagnost__BD16DB69AC3FA98B");

            entity.Property(e => e.CodigoCie10)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CodigoCIE10");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Diagnostico)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diagnostico_Consulta");
        });

        modelBuilder.Entity<Enfermero>(entity =>
        {
            entity.HasKey(e => e.IdEnfermero).HasName("PK__Enfermer__56277F2DA2F79171");

            entity.HasIndex(e => e.IdUsuario, "UQ__Enfermer__5B65BF9667C7A565").IsUnique();

            entity.Property(e => e.CodigoEnfermero)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Enfermero)
                .HasForeignKey<Enfermero>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enfermero_Usuario");
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK__Especial__693FA0AF8F2E420F");

            entity.HasIndex(e => e.Nombre, "UQ__Especial__75E3EFCFF457CA7F").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HistoriaClinica>(entity =>
        {
            entity.HasKey(e => e.IdHistoria).HasName("PK__Historia__230AB67FE3994AD7");

            entity.HasIndex(e => e.IdPaciente, "UQ__Historia__C93DB49A9111CE9E").IsUnique();

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdPacienteNavigation).WithOne(p => p.HistoriaClinica)
                .HasForeignKey<HistoriaClinica>(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historia_Paciente");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.IdMedicamento).HasName("PK__Medicame__AC96376E2D584F43");

            entity.Property(e => e.Concentracion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Presentacion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StockMinimo).HasDefaultValue(10);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("PK__Medico__C326E652C809DE05");

            entity.HasIndex(e => e.IdUsuario, "UQ__Medico__5B65BF96B7B5DAFF").IsUnique();

            entity.HasIndex(e => e.Cmp, "UQ__Medico__C1F8FCD1CEE7EACB").IsUnique();

            entity.Property(e => e.Cmp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CMP");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Medico)
                .HasForeignKey(d => d.IdEspecialidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medico_Especialidad");

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Medico)
                .HasForeignKey<Medico>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Medico_Usuario");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("PK__Paciente__C93DB49B2CBFA299");

            entity.HasIndex(e => e.IdUsuario, "UQ__Paciente__5B65BF9692906464").IsUnique();

            entity.HasIndex(e => e.Dni, "UQ__Paciente__C035B8DDF4AA1B8D").IsUnique();

            entity.Property(e => e.Direccion)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DNI");
            entity.Property(e => e.EstadoSeguro).HasDefaultValue(true);
            entity.Property(e => e.Seguro)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.Paciente)
                .HasForeignKey<Paciente>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paciente_Usuario");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.IdReceta).HasName("PK__Receta__2CEFF1570B4DE33D");

            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("Activa");
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdConsultaNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdConsulta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Receta_Consulta");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C4F9EA27E");

            entity.HasIndex(e => e.NombreRol, "UQ__Rol__4F0B537F34BCDE2B").IsUnique();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SignosVitales>(entity =>
        {
            entity.HasKey(e => e.IdSignos).HasName("PK__SignosVi__2D3B60D2ECB5375C");

            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Peso).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.PresionArterial)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.SaturacionOxigeno).HasColumnType("decimal(4, 1)");
            entity.Property(e => e.Talla).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Temperatura).HasColumnType("decimal(4, 1)");

            entity.HasOne(d => d.IdEnfermeroNavigation).WithMany(p => p.SignosVitales)
                .HasForeignKey(d => d.IdEnfermero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Signos_Enfermero");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.SignosVitales)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Signos_Paciente");
        });

        modelBuilder.Entity<TecnicoFarmacia>(entity =>
        {
            entity.HasKey(e => e.IdFarmacia).HasName("PK__TecnicoF__B89960A63E2CF8F1");

            entity.HasIndex(e => e.IdUsuario, "UQ__TecnicoF__5B65BF9676DE9F2A").IsUnique();

            entity.Property(e => e.CodigoFarmacia)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithOne(p => p.TecnicoFarmacia)
                .HasForeignKey<TecnicoFarmacia>(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TecnicoFarmacia_Usuario");
        });

        modelBuilder.Entity<Triage>(entity =>
        {
            entity.HasKey(e => e.IdTriage).HasName("PK__Triage__F6F3ED2D057D979A");

            entity.Property(e => e.FechaHora)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MotivoConsulta)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Prioridad)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEnfermeroNavigation).WithMany(p => p.Triage)
                .HasForeignKey(d => d.IdEnfermero)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Triage_Enfermero");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Triage)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Triage_Paciente");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF9708DAD592");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A19E5BD34CE").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Usuario_Rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
