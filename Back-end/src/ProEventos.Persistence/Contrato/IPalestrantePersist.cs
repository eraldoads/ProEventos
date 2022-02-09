using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        // [Aula.58] → Cria todas as chamadas da persistencia, implementação para fazer o CRUD da aplicação.

        // PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos); 
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);


    }
}