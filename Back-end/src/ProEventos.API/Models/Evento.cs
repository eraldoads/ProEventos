namespace ProEventos.API.Models
{
    // [Aula.180] -> Este evento é utilizado dentro da Controller (EventoController.cs).
    public class Evento
    {
        // [Aula.180] -> Criar as propriedades.
        public int EventoId { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPessoas { get; set; }
        public string Lote { get; set; }
        public string ImagemURL { get; set; }

    }
}