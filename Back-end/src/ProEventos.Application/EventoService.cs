using System;
using System.Threading.Tasks;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Application
{
    /// <summary>
    /// [Aula.66] → Classe que implementa a interface IEventoService (novo Contrato).
    /// </summary>
    public class EventoService : IEventoService
    {
        #region Parâmentros e Construtor
        private readonly IGeralPersist _geralPersist;
        private readonly IEventoPersist _eventoPersist;

        // [Aula.66] → Cria o construtor que injeta o IGeralPersist e o IEventoPersist
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            _eventoPersist = eventoPersist;
            _geralPersist = geralPersist;

        }
        #endregion

        #region Contrato Geral
        /// <summary>
        /// [Aula.66] → Metodo responsável em adicionar/cadastrar um novo Evento.
        /// </summary>
        /// <param name="model"></param>
        /// <returns> [Aula.66] → Retorna o item que foi adicionado/cadastrado </returns>
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                // [Aula.66] → Se salvou alguma coisa ele retorna o model, o Id é alterado quando o SaveChangesAsync é executado,
                // ele vai no Banco de Dados e recupera o Id e retorna para quem chamar ou adicionar, então terá de retorno o item que foi adicionado.
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// [Aula.66] → Método responsável em atualizar um Evento.
        /// </summary>
        /// <param name="eventoId"></param>
        /// <param name="model"></param>
        /// <returns> [Aula.66] → Retorna o item que foi atualizado. </returns>
        public async Task<Evento> UpdateEventos(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if(evento == null) return null;

                model.Id = evento.Id;

                _geralPersist.Update(model);
                // [Aula.66] → Se salvou alguma coisa ele retorna o model, o Id é alterado quando o SaveChangesAsync é executado,
                // ele vai no Banco de Dados e recupera o Id e retorna para quem chamar ou atualizar, então terá de retorno o item que foi atualizado.
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// [Aula.66] → Método responsável por excluir um Evento.
        /// </summary>
        /// <param name="eventoId"></param>
        /// <returns> [Aula.66] → Retorna true ou false indicando se o Evento foi deletado ou não. </returns>
        public async Task<bool> DeleteEventos(int eventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("Evento para delete não foi encontrado.");

                _geralPersist.Delete<Evento>(evento);

                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Contrato de Eventos
        /// <summary>
        /// [Aula.67] → Método responsável por buscar todos os eventos cadastrados.
        /// </summary>
        /// <param name="includePalestrantes"> [Aula.67] → false ou true</param>
        /// <returns> [Aula.67] → Eventos cadastratos. </returns>
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosAsync(includePalestrantes);
                if (eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// [Aula.67] → Método responsável por buscar os eventos cadastrados por tema.
        /// </summary>
        /// <param name="tema"></param>
        /// <param name="includePalestrantes"> [Aula.67] → false ou true </param>
        /// <returns> [Aula.67] → retorna os eventos pelo tema. </returns>
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// [Aula.67] → Método responsável por buscar um evento pelo seu ID.
        /// </summary>
        /// <param name="eventoId"></param>
        /// <param name="includePalestrantes"> [Aula.67] → false ou true </param>
        /// <returns> [Aula.67] → retorna um evendo pelo seu ID. </returns>
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
                if(eventos == null) return null;

                return eventos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}