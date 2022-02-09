using System.Threading.Tasks;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    /// <summary>
    /// [Aula.64] - Classe de Persistencia Geral.
    /// </summary>
    public class GeralPersist : IGeralPersist
    {
        // [Aula.60] → Cria o construtor injetar o contexto da aplicação dentro da Persistencia.
        private readonly ProEventosContext _context;
        public GeralPersist(ProEventosContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            // [Aula.60] → Retorna um boll e se for maio que "0" retorna "true".
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}