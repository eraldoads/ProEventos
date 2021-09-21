﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    /// <summary>
    /// [Aula.175] -> Todo o controller precisa ter o sufixo "Controller" ao final do nome da classe.
    /// A Classe herda de ": ControllerBase"
    /// </summary>
    public class EventoController : ControllerBase
    {

        // [Aula.180] -> Criar eventos "mockados" para testes.
        public IEnumerable<Evento> _evento = new Evento[] {
                new Evento {
                    EventoId = 1,
                    Tema = "Angular 12 e .NET 5.0",
                    Local = "Porto Alegre",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    ImagemURL = "fotoAngularNet5.png"
                },
                new Evento {
                    EventoId = 2,
                    Tema = ".NET Core",
                    Local = "Porto Alegre",
                    Lote = "1º Lote",
                    QtdPessoas = 50,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                    ImagemURL = "fotoNetCore.png"
                }
            };

        public EventoController()
        {
        }

        /// <summary>
        /// [Aula.177] -> Verbo GET.
        /// [Aula.180] -> Por ser um "IEnumerable<>" é esperado que seja retornado um array.
        /// </summary>
        /// <returns> [Aula.180] -> array dos Eventos. </returns>
        [HttpGet]
        public IEnumerable<Evento> Get(){
            // [Aula.180] -> retorna uma array em formato JSON.
            return _evento;
        }

        /// <summary>
        /// [Aula.180] -> Verbo GET.
        /// Por ser um "IEnumerable<>" é esperado que seja retornado um array.
        /// </summary>
        /// <param name="id"> [Aula.180] -> id do Evento. </param>
        /// <returns> [Aula.180] -> array de um Evento. </returns>
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id){
            return _evento.Where(evento => evento.EventoId == id); // [Aula.180] -> Espressão para passar o ID.
        }

        /// <summary>
        /// [Aula.177] -> Verbo Post.
        /// </summary>
        /// <returns> [Aula.177] -> Cadastra um registro. </returns>
        [HttpPost]
        public string Post(){
            return "Exemplo de POST.";
        }

        /// <summary>
        /// [Aula.177] -> Verbo PUT.
        /// </summary>
        /// <param name="id"> [Aula.177] -> id do registro. </param>
        /// <returns> [Aula.177] -> Atualiza um registro especifico. </returns>
        [HttpPut("{id}")]
        public string Put(int id){
            return $"Exemplo de PUT com o id = {id}.";
        }

        /// <summary>
        /// [Aula.177] -> Delete um registro.
        /// </summary>
        /// <param name="id"> [Aula.177] -> id do registro. </param>
        /// <returns> [Aula.177] -> Deleta um registro especifico. </returns>
        [HttpDelete("{id}")]
        public string Delete(int id){
            return $"Exemplo de Delete com o id = {id}.";
        }


    }
}
