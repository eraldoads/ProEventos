using Microsoft.EntityFrameworkCore;
//using ProEventos.API.Models;
using ProEventos.Domain;

// [Aula.55] → Movido de ProEventos.API e realizado alguns ajustes.
// [Aula.65] → Criado o diretório "Contexto" e movido o arquivo.
namespace ProEventos.Persistence.Contextos
{
    /// <summary>
    /// [Aula.192] → Contexto que será utilizado para a criação da tabela de Evento dentro do banco de dados SQLite.
    /// </summary>
    public class ProEventosContext : DbContext
    {
        // [Aula.192] → Cria o construtor que fará a conexão com o Banco de Dados.
        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options) { }
        
        // [Aula.55] → Acrescentar todas as outras as classes/objetos criados no ProEventos.Domain.
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        /// <summary>
        /// [Aula.55] → Método responsável por fazer a associação (quando houver "muitos" para "muitos") de Eventos e Palestrantes 
        /// mapeando para a tabela PalestrantesEventos.
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // [Aula.55] → Quando for criada no banco de dados vai ser feita a junção entre os Eventos e Palestrantes.
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId}); // [Aula.55] → São as chaves do PalestranteEventos e faz a Associação. Ids externos que estão dentro de PalestranteEventos.

            // [Aula.74] → Config Cascade.
            // Explicando: Fazer com que o modelBuilder tem uma entidade que se chama/tipo evento e ela tem muitas RedesSociais, dado todas essas RedesSociais
            // pode pertencer a somente um evento, com isso, toda vez que tiver deletando é para ter o comportamento de delete que seja Cascade, ou seja, 
            // deletou o Evento que tem RedesSociais que faça de forma cascatateada
            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            // [Aula.74] → Faz a mesma coisa so que ao invés de Evento é para os Palestrantes
            modelBuilder.Entity<Palestrante>()
                .HasMany(p => p.RedeSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}