using EcoClean.Models;
using Microsoft.EntityFrameworkCore;

namespace EcoClean.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<CaminhaoModel> Caminhao { get; set; }
        public DbSet<ColetaModel> Coleta { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }
        public DbSet<MoradorModel> Morador { get; set; }
        public DbSet<NotificacaoModel> Notificacao { get; set; }
        public DbSet<RotaModel> Rota { get; set; }
        public DbSet<TipoResiduoModel> TipoResiduo { get; set; }
        public DbSet<ColetaTipoResiduoModel> ColetaTipoResiduo { get; set; }
        public DbSet<RotaEnderecoModel> RotaEndereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaminhaoModel>(entity =>
            {
                entity.ToTable(nameof(Caminhao));
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Placa).IsRequired();
                entity.Property(c => c.CoordenadaX);
                entity.Property(c => c.CoordenadaY);
                entity.Property(c => c.CreatedAt).HasColumnType("DATE");
                entity.Property(c => c.UpdatedAt).HasColumnType("DATE");
            });

            modelBuilder.Entity<ColetaModel>(entity =>
            {
                entity.ToTable(nameof(Coleta));
                entity.HasKey(c => c.Id);

                //Relacionamento com RotaModel
                entity.HasOne(c => c.Rota)
                .WithMany()
                .HasForeignKey(c => c.RotaId);

                //Relacionamento com CaminhaoModel
                entity.HasOne(c => c.Caminhao)
                .WithMany()
                .HasForeignKey(c => c.CaminhaoId);

                //Relacionamento com EnderecoModel
                entity.HasOne(c => c.Endereco)
                .WithMany()
                .HasForeignKey(c => c.EnderecoId);

                //Relacionamento com ColetaMOdel e TipoResiduoModel
                entity.HasMany(c => c.ColetaTipoResiduo)
                .WithOne(cc => cc.Coleta)
                .HasForeignKey(cc => cc.ColetaId);

                //Possa ser que tenha mais alguma relação para implementar

                entity.Property(c => c.PrevisaoHorario).HasColumnType("DATE");
                entity.Property(c => c.CreatedAt).HasColumnType("DATE");
                entity.Property(c => c.UpdatedAt).HasColumnType("DATE");
            });

            modelBuilder.Entity<ColetaTipoResiduoModel>(entity =>
            {
                entity.HasKey(ctr => new { ctr.ColetaId, ctr.TipoResiduoId});
                
                entity.HasOne(ctr => ctr.Coleta)
                .WithMany(ct => ct.ColetaTipoResiduo)
                .HasForeignKey(ctr => ctr.ColetaId);

                entity.HasOne(ctr => ctr.TipoResiduo)
                .WithMany(ct => ct.ColetaTipoResiduo)
                .HasForeignKey(ctr => ctr.TipoResiduoId);

            });


            modelBuilder.Entity<EnderecoModel>(entity =>
            {
                entity.ToTable(nameof(Endereco));
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Cep).HasMaxLength(10).IsRequired();
                entity.Property(e => e.Rua).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Bairro).HasMaxLength(50).IsRequired();
                entity.Property(e => e.Numero).IsRequired();
                entity.Property(e => e.Complemento);
                entity.Property(e => e.Cidade).HasMaxLength(30).IsRequired();
                entity.Property(e => e.Estado).HasMaxLength(20).IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnType("DATE");
                entity.Property(e => e.UpdatedAt).HasColumnType("DATE");

            });

            modelBuilder.Entity<MoradorModel>(entity =>
            {
                entity.ToTable(nameof(Morador));
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Nome).HasMaxLength(50).IsRequired();
                entity.Property(m => m.Email).HasMaxLength(50).IsRequired();

                //Relacionamento com EnderecoModel
                entity.HasOne(m => m.Endereco)
                .WithMany()
                .HasForeignKey(m => m.EnderecoId);

                entity.Property(e => e.CreatedAt).HasColumnType("DATE");
                entity.Property(e => e.UpdatedAt).HasColumnType("DATE");

            });

            modelBuilder.Entity<NotificacaoModel>(entity =>
            {
                entity.ToTable(nameof(Notificacao));
                entity.HasKey(n => n.Id);
                entity.Property(n => n.Destinatario).HasMaxLength(100).IsRequired();
                entity.Property(n => n.Assunto).HasMaxLength(100).IsRequired();
                entity.Property(n => n.Mensagem).HasMaxLength(4000).IsRequired();
                entity.Property(n => n.DataEnvio).HasColumnType("DATE");
            });

            modelBuilder.Entity<RotaEnderecoModel>(entity =>
            {
                entity.HasKey(rt => new { rt.EnderecoId, rt.RotaId });

                entity.HasOne(rt => rt.Endereco)
                .WithMany(r => r.RotaEndereco)
                .HasForeignKey(rt => rt.EnderecoId);

                entity.HasOne(rt => rt.Rota)
                .WithMany(r => r.RotaEndereco)
                .HasForeignKey(rt => rt.RotaId);
            });

            modelBuilder.Entity<RotaModel>(entity =>
            {
                entity.ToTable(nameof(Rota));
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Nome).HasMaxLength(50);
                entity.Property(r => r.CreatedAt).HasColumnType("DATE");
                entity.Property(r => r.UpdatedAt).HasColumnType("DATE");
            });

            modelBuilder.Entity<TipoResiduoModel>(entity =>
            {
                entity.ToTable(nameof(TipoResiduo));
                entity.HasKey(tr => tr.Id);
                entity.Property(tr => tr.Nome).HasMaxLength(30);
                entity.Property(tr => tr.Descricao).HasMaxLength(50);
                entity.Property(e => e.CreatedAt).HasColumnType("DATE");
                entity.Property(e => e.UpdatedAt).HasColumnType("DATE");

              
            });

        }//OnModelCreating end

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }

    }
}
