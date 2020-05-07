using AmigoOculto.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AmigoOculto.Repository.Context
{
    public class AmigoOcultoContext : DbContext
    {
        public AmigoOcultoContext(DbContextOptions<AmigoOcultoContext> options) : base(options)
        {

        }
        public AmigoOcultoContext()
        {

        }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<GrupoUsuario> GrupoUsuarios { get; set; }

        private void ConfiguraGrupo(ModelBuilder contrutorDeModelos)
        {
            contrutorDeModelos.Entity<Grupo>(x =>
           {
               x.ToTable("tb_grupo");
               x.HasKey(c => c.Id).HasName("Pk_Grupo");
               x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
               x.Property(c => c.Descricao).HasColumnName("Descricao");
               x.Property(c => c.Localizacao).HasColumnName("Localizacao");
               x.Property(c => c.DataHoraEntrega).HasColumnName("DataHoraEntrega");
               x.Property(c => c.Observacao).HasColumnName("Observacao");
           });
        }
        private void ConfiguraUsuario(ModelBuilder contrutorDeModelos)
        {
            contrutorDeModelos.Entity<Usuario>(x =>
            {
                x.ToTable("tb_usuario");
                x.HasKey(c => c.Id).HasName("Pk_Usuario");
                x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                x.Property(c => c.Nome).HasColumnName("Nome").HasMaxLength(200);
                x.Property(c => c.Email).HasColumnName("Email");
                x.Property(c => c.Telefone).HasColumnName("Telefone");
                x.Property(c => c.DataNascimento).HasColumnName("DataNascimento");
                x.Property(c => c.Detalhes).HasColumnName("Detalhes");
            });
        }
        private void ConfiguraGrupoUsuario(ModelBuilder contrutorDeModelos)
        {
            contrutorDeModelos.Entity<GrupoUsuario>(x =>
            {
                x.ToTable("tb_grupousuario");
                x.HasKey(c => c.Id).HasName("Pk_GrupoUsuario");
                x.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                x.HasOne(c => c.Grupo).WithMany(c => c.GrupoUsuarios).HasForeignKey(p => p.GrupoId);
                x.HasOne(c => c.Usuario).WithMany(c => c.GrupoUsuarios).HasForeignKey(p => p.AmigoId);
            });
        }
        protected override void OnModelCreating(ModelBuilder constructorDeModelos)
        {
            constructorDeModelos.ForSqlServerUseIdentityColumns();
            constructorDeModelos.HasDefaultSchema("bdAmigoOculto");

            ConfiguraUsuario(constructorDeModelos);
            ConfiguraGrupo(constructorDeModelos);
            ConfiguraGrupoUsuario(constructorDeModelos);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            //dbContextOptionsBuilder.UseLazyLoadingProxies();
        }
    }
}
