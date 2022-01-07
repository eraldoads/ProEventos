using System;
using System.Collections.Generic;

// [Aula.53] → Toda essa classe/objeto vou movido para dentro da camanda/projeto ProEventos.Domain.
namespace ProEventos.Domain
{
    // [Aula.180] -> Este evento é utilizado dentro da Controller (EventoController.cs).
    public class Evento
    {
        // [Aula.180] -> Criar as propriedades.
        // public int EventoId { get; set; } 
        public int Id { get; set; } // [Aula.53] → Alterado
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        //public string Lote { get; set; }
        public string ImagemURL { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // [Aula.53] → como 1 evento pode ter vários lotes, com isso, é preciso que a propriedade seja do tipo 'IEnumerable'.
        public IEnumerable<Lote> Lotes { get; set; } // [Aula.53] → referencia o objeto Lote.
        public IEnumerable<RedeSocial> RedesSociais { get; set; } // [Aula.53] → referencia o objeto RedesSociais.
        public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; } // [Aula.53] → referencia o objeto Palestrantes.

    }
}