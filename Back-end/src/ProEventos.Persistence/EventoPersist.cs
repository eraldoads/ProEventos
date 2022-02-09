using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    /// <summary>
    /// [Aula.64] - Classe de Persistencia de Eventos.
    /// </summary>
    public class EventoPersist : IEventoPersist
    {
        // [Aula.60] → Cria o construtor injetar o contexto da aplicação dentro da Persistencia.
        private readonly ProEventosContext _context;
        public EventoPersist(ProEventosContext context)
        {
            _context = context;
            // [Aula.71] → Forma de resolver o problema do Tracked quando tenta atualizar um evento. Porém,
            // essa forma ele vai ser utilizado para todos os métodos da classe "EcentoPersist".
            // Vai ficar comentado como uma forma de solucionar o problema, a solução para esse projeto é colocar
            // dentro dos métodos.
            /// _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region EVENTOS

        /// <summary>
        /// [Aula.61] → Método responsável por retornar todos os EVENTOS cadastrados. Como ele é uma "Task" ele precisa ser "Async".
        /// </summary>
        /// <param name="includePalestrantes"> [Aula.61] → Como esse parametro é opcional ele inicia como "false". </param>
        /// <returns> [Aula.61] → Retorna um Array Assincrono com todos os eventos cadastrados. </returns>
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            // [Aula.71] → colocando o AsNoTracking() para desabilitar o controle de alterações e não retornar o erro de Tracker.
            query = query.AsNoTracking().OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// [Aula.61] → Metodo responável por retornar os EVENTOS por Tema. Como ele é uma "Task" ele precisa ser "Async".
        /// </summary>
        /// <param name="tema"></param>
        /// <param name="includePalestrantes"> [Aula.61] → Como esse parametro é opcional ele inicia como "false". </param>
        /// <returns> [Aula.61] → Retorna um Array Assincrono de um tema especifico cadastrado. </returns>
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            // [Aula.71] → colocando o AsNoTracking() para desabilitar o controle de alterações e não retornar o erro de Tracker.
            query = query.AsNoTracking().OrderBy(e => e.Id)
                             .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// [Aula.61] → Método responsável por retornar os EVENTOS pelo ID. Como ele é uma "Task" ele precisa ser "Async".
        /// </summary>
        /// <param name="EventoId"></param>
        /// <param name="includePalestrantes"> [Aula.61] → Como esse parametro é opcional ele inicia como "false". </param>
        /// <returns> [Aula.61] → Retorna somente um evento, o primeiro que encontrar. </returns>
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if(includePalestrantes){
                query = query
                    .Include(e => e.PalestrantesEventos)
                    .ThenInclude(pe => pe.Palestrante);
            }

            // [Aula.71] → colocando o AsNoTracking() para desabilitar o controle de alterações e não retornar o erro de Tracker.
            query = query.AsNoTracking().OrderBy(e => e.Id)
                         .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        #endregion

    }
}