using Microsoft.EntityFrameworkCore;
using ProEventos.API.Models;

namespace ProEventos.API.Data
{
    /// <summary>
    /// [Aula.192] → Contexto que será utilizado para a criação da tabela de Evento dentro do banco de dados SQLite.
    /// </summary>
    public class DataContext : DbContext
    {
        // [Aula.192] → Cria o construtor que fará a conexão com o Banco de Dados.
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
    }
}