using System;

// [Aula.53] → Criado a Classe/Objeto.
namespace ProEventos.Domain
{
    public class Lote
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; } // [Aula.53] → Aqui seria a chave estrangeira (foreign key).
        public Evento Evento { get; set; }
    }
}