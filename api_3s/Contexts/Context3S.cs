using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api_3s.Domains;

namespace api_3s.Contexts;

public partial class Context3S : DbContext
{
    public Context3S()
    {
    }

    public Context3S(DbContextOptions<Context3S> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Funcionario> Funcionarios { get; set; }

    public virtual DbSet<Marcacao> Marcacaos { get; set; }

    public virtual DbSet<TipoMarcacao> TipoMarcacaos { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-1MMUS7M\\SQLEXPRESS; initial catalog=db_3s; Integrated Security=SSPI;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("PK__Cargo__6C98562528BD8E27");

            entity.ToTable("Cargo");

            entity.Property(e => e.IdCargo).ValueGeneratedOnAdd();
            entity.Property(e => e.Cargo1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Cargo");
        });

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.IdFuncionario).HasName("PK__Funciona__35CB052AE0091A12");

            entity.ToTable("Funcionario");

            entity.Property(e => e.Ativo).HasColumnName("ativo");
            entity.Property(e => e.EmailEmpresarial)
                .HasMaxLength(256)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCargoNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Funcionar__IdCar__2E1BDC42");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Funcionarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Funcionar__IdUsu__2D27B809");
        });

        modelBuilder.Entity<Marcacao>(entity =>
        {
            entity.HasKey(e => e.IdMarcacao).HasName("PK__Marcacao__0FFD4331D2DB0B9D");

            entity.ToTable("Marcacao");

            entity.Property(e => e.DataHora).HasColumnType("datetime");

            entity.HasOne(d => d.IdFuncionarioNavigation).WithMany(p => p.Marcacaos)
                .HasForeignKey(d => d.IdFuncionario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marcacao__IdFunc__31EC6D26");

            entity.HasOne(d => d.IdTipoMarcacaoNavigation).WithMany(p => p.Marcacaos)
                .HasForeignKey(d => d.IdTipoMarcacao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marcacao__IdTipo__30F848ED");
        });

        modelBuilder.Entity<TipoMarcacao>(entity =>
        {
            entity.HasKey(e => e.IdTipoMarcacao).HasName("PK__tipoMarc__435AE568B5BAEC8F");

            entity.ToTable("tipoMarcacao");

            entity.Property(e => e.IdTipoMarcacao).ValueGeneratedOnAdd();
            entity.Property(e => e.TipoMarcacao1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tipoMarcacao");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.IdTipoUsuario).HasName("PK__TipoUsua__CA04062B1DA37638");

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.IdTipoUsuario).ValueGeneratedOnAdd();
            entity.Property(e => e.Descricao)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF974C7E5026");

            entity.ToTable("Usuario");

            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.Email)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.QrCode)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(9)
                .IsUnicode(false);

            entity.HasOne(d => d.IdTipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__IdTipoU__2A4B4B5E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
