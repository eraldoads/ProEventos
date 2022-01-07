using Microsoft.EntityFrameworkCore;
//using ProEventos.API.Models;
using ProEventos.Domain;

// [Aula.55] → Movido de ProEventos.API e realizado alguns ajustes.
namespace ProEventos.Persistence
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
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId}); // [Aula.55] → São as chaves do PalestranteEventos e faz a Associação.
        }

    }
}