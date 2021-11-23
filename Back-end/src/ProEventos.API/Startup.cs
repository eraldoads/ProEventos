using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProEventos.API.Data;

namespace ProEventos.API
{
    public class Startup
    {

        /// <summary>
        /// [Aula.175] -> o construtor da Classe esta recebendo o "IConfiguration" e sendo injetado.
        /// Arquivo de configuração de acordo com o ambiente.
        /// </summary>
        /// <param name="configuration"> [Aula.175] -> IConfiguration </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; // [Aula.192] → O configuration consegue acessar o appsettings.json.
        }

        public IConfiguration Configuration { get; } // [Aula.175] -> Propriedade.

        // [Aula.175] -> Este método é chamado pelo tempo de execução. Use este método para adicionar serviços ao contêiner.
        public void ConfigureServices(IServiceCollection services)
        {
            // [Aula.192] → Após criar o context deve ser informado. Aqui informa qual o contexto que deverá ser utilizado.
            services.AddDbContext<DataContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default")) // [Aula.192] Faz a conexão como banco de dados.
            );

            services.AddControllers(); // [Aula.175] -> Aqui é onde informa que esta trabalhando com a arquiterua MVC. Chamada da "Controller".
            // [Aula.175] -> Forma de dizer que vai utilizar o "Swagger" na aplicação.

            // [Aula.206] -> Corrigindo o problema de CORS
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProEventos.API", Version = "v1" });
            });
        }

        // [Aula.175] -> Este método é chamado em tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /// <summary>
            /// [Aula.175] -> Entra nessa condição se estiver configurado para rodar no ambiente de desenvvolvimento.
            /// Dentro do arquivo "lauchSettings.josn" é onde informamos em qual ambiente a aplicação vai rodar.
            /// </summary>
            /// <returns></returns>
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(); // [Aula.175] -> Chama o "Swagger".
                // [Aula.175] -> Forma de assinatura do "Contrato" do Swagger.
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProEventos.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting(); // [Aula.175] -> Uso de Rotas. Chama o "Controller".

            app.UseAuthorization();

            /*  [Aula.206] -> Corrigindo o problema de CORS, permitir o acesso.
                Permitindo qualquer configuração de cabeçalho (Header) da requisição do HTTP, 
                vinda de qualquer método (Method), ou seja, GET | POST | PUT | DELETE | PATCH...
                e, vinda de qualquer origem (Origin), vai ser permitida todas as requisições aqui.
            */ 
            app.UseCors(acesso => acesso.AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowAnyOrigin());

            // [Aula.175] -> Uso de determinados endpoints para as rotas.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // [Aula.175] -> Mapeamento de Rotas. Chama o "Controller".
            });
        }
    }
}
