using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SP_MedicalGroup.Domains;

#nullable disable

namespace SP_MedicalGroup.Contexts
{
    public partial class InLockContext : DbContext
    {
        public InLockContext()
        {
        }

        public InLockContext(DbContextOptions<InLockContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clinica> Clinicas { get; set; }
        public virtual DbSet<Consultum> Consulta { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Especialidade> Especialidades { get; set; }
        public virtual DbSet<Medico> Medicos { get; set; }
        public virtual DbSet<Paciente> Pacientes { get; set; }
        public virtual DbSet<SituacaoPaciente> SituacaoPacientes { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // diretiva de #aviso
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-404RQHFB\\SQLEXPRESS; initial catalog=SPMedicalGroup; user Id=sa; pwd=Alexandre2002;");
#pragma warning restore CS1030 // diretiva de #aviso
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Clinica>(entity =>
            {
                entity.HasKey(e => e.IdClinica)
                    .HasName("PK__Clinica__52A90951FF3E2782");

                entity.ToTable("Clinica");

                entity.HasIndex(e => e.NomeClinica, "UQ__Clinica__5D092ACE9567B0BD")
                    .IsUnique();

                entity.HasIndex(e => e.Cnpj, "UQ__Clinica__AA57D6B40DED596E")
                    .IsUnique();

                entity.HasIndex(e => e.RazaoVisita, "UQ__Clinica__E8DAECEDDFEC4760")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("CNPJ")
                    .IsFixedLength(true);

                entity.Property(e => e.NomeClinica)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoVisita)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Clinicas)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Clinica__IdEnder__3B75D760");
            });

            modelBuilder.Entity<Consultum>(entity =>
            {
                entity.HasKey(e => e.IdConsulta)
                    .HasName("PK__Consulta__9B2AD1D812A691DD");

                entity.Property(e => e.DataConsulta).HasColumnType("datetime");

                entity.Property(e => e.DescricaoConsulta)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMedicoNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdMedico)
                    .HasConstraintName("FK__Consulta__IdMedi__5629CD9C");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdPaciente)
                    .HasConstraintName("FK__Consulta__IdPaci__5535A963");

                entity.HasOne(d => d.IdSituacaoPacienteNavigation)
                    .WithMany(p => p.Consulta)
                    .HasForeignKey(d => d.IdSituacaoPaciente)
                    .HasConstraintName("FK__Consulta__IdSitu__571DF1D5");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PK__Endereco__0B7C7F179D18B15A");

                entity.ToTable("Endereco");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.NomeRua)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Especialidade>(entity =>
            {
                entity.HasKey(e => e.IdEspecialidadeMedica)
                    .HasName("PK__Especial__591CB07899F9BEBF");

                entity.ToTable("Especialidade");

                entity.HasIndex(e => e.TipoEspecialidade, "UQ__Especial__9DCAFB8C176AE0E6")
                    .IsUnique();

                entity.Property(e => e.TipoEspecialidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medico>(entity =>
            {
                entity.HasKey(e => e.IdMedico)
                    .HasName("PK__Medico__C326E65235F98284");

                entity.ToTable("Medico");

                entity.Property(e => e.NomeMedico)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClinicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdClinica)
                    .HasConstraintName("FK__Medico__IdClinic__4E88ABD4");

                entity.HasOne(d => d.IdEspecialidadeMedicaNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdEspecialidadeMedica)
                    .HasConstraintName("FK__Medico__IdEspeci__4F7CD00D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Medicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Medico__IdUsuari__4D94879B");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.IdPaciente)
                    .HasName("PK__Paciente__C93DB49B342F7A3D");

                entity.ToTable("Paciente");

                entity.HasIndex(e => e.Rg, "UQ__Paciente__321537C8BA9B25D5")
                    .IsUnique();

                entity.HasIndex(e => e.Telefone, "UQ__Paciente__4EC504B6F07B7E62")
                    .IsUnique();

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.NomePaciente)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("RG")
                    .IsFixedLength(true);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__Paciente__IdEnde__4AB81AF0");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Paciente__IdUsua__49C3F6B7");
            });

            modelBuilder.Entity<SituacaoPaciente>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoPaciente)
                    .HasName("PK__Situacao__49D8D724EE4564B5");

                entity.ToTable("SituacaoPaciente");

                entity.HasIndex(e => e.Avaliacao, "UQ__Situacao__8120BAAF3883592F")
                    .IsUnique();

                entity.Property(e => e.Avaliacao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B641B637A");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__TipoUsua__C6FB90A812C3F29F")
                    .IsUnique();

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF979235FF58");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D10534549E3CC3")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
