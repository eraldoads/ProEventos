using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProEventos.API
{
    /// <summary>
    /// [Aula.175] -> O Program.cs é o primeiro arquivo a ser executado ao rodar a aplicação, com isso,
    /// essa é a primeira Classe a ser executada.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// [Aula.175] -> Primeiro método a ser chamado.
        /// </summary>
        /// <param name="args"> [Aula.175] -> array de string </param>
        public static void Main(string[] args)
        {
            // [Aula.175] -> Chama o método que contém as configurações necessárias para rodar a aplicação.
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// [Aula.175] -> Método com diversas configuraçòes, ele inicializa uma nova instancia da classe "HostBuilder" com padrões configurados.
        /// Um dos padrões mais utilizados é o carregamento do "IConfiguration" do aplicativo de "appsettings.json" e
        /// "appsettings.[IHostEnvironment.Enviromentname].json".
        /// Se a aplicação estiver rodando no ambiente de DEV ele considera as configurações do "appsettings.Development.json",
        /// caso esteja no ambiente de produção vai considerar as configurações do "appsettings.json".
        /// Ele também vai carregar, na classe "<Startup>" que ele for inicializar, o "Iconfiguration" host a partir de variáveis de ambiente
        /// prefixadas "DOTNET_", levando isso em consideração.
        /// Configura o "ILoggerFactory" para registrar no console, depurar e saída da origem do evento. Ele injeta na classe "<Startup>" que 
        /// iniciar o método.
        /// </summary>
        /// <param name="args"> [Aula.175] ->array de string </param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // [Aula.175] -> Ele chama a Classe do "Startup.cs".
                    webBuilder.UseStartup<Startup>();
                });
    }
}
