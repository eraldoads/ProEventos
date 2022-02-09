using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    /// <summary>
    /// [Aula.64] - Classe de Persistencia de Palestrantes.
    /// </summary>
    public class PalestrantePersist : IPalestrantePersist
    {
        // [Aula.60] → Cria o construtor injetar o contexto da aplicação dentro da Persistencia.
        private readonly ProEventosContext _context;
        public PalestrantePersist(ProEventosContext context)
        {
            _context = context;
        }

        #region PALESTRANTES
        
        /// <summary>
        /// [Aula.62] → Método responsável por retornar todos os EVENTOS cadastrados. Como ele é uma "Task" ele precisa ser "Async".
        /// </summary>
        /// <param name="includeEventos"> [Aula.62] → Como esse parametro é opcional ele inicia como "false". </param>
        /// <returns> [Aula.61] → Retorna um Array Assincrono com todos os palestrantes cadastrados. </returns>
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            // [Aula.71] → colocando o AsNoTracking() para desabilitar o controle de alterações e não retornar o erro de Tracker.
            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// [Aula.62] → Metodo responável por retornar os EVENTOS por Tema. Como ele é uma "Task" ele precisa ser "Async".
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="includeEventos"> [Aula.62] → Como esse parametro é opcional ele inicia como "false". </param>
        /// <returns> [Aula.62] → Retorna um Array Assincrono de um nome especifico cadastrado. </returns>
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            // [Aula.71] → colocando o AsNoTracking() para desabilitar o controle de alterações e não retornar o erro de Tracker.
            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// [Aula.62] → Método responsável por retornar os Palestrantes pelo ID. Como ele é uma "Task" ele precisa ser "Async".
        /// </summary>
        /// <param name="palestranteId"></param>
        /// <param name="includeEventos"> [Aula.62] → Como esse parametro é opcional ele inicia como "false". </param>
        /// <returns> [Aula.62] → Retorna somente um palestrante, o primeiro que encontrar. </returns>
        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(p => p.RedeSociais);

            if(includeEventos){
                query = query
                    .Include(p => p.PalestrantesEventos)
                    .ThenInclude(pe => pe.Evento);
            }

            // [Aula.71] → colocando o AsNoTracking() para desabilitar o controle de alterações e não retornar o erro de Tracker.
            query = query.AsNoTracking().OrderBy(p => p.Id)
                         .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        #endregion

    }
}