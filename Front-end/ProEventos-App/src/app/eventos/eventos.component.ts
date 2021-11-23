import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {
  /* #region [Aula.204]
  // Exemplo utilizado para usar dentro do eventos.component.html com a diretiva ngfor.
  // criar uma propriedade que gera um array com 3 valores.
  public eventos: any = [
    {
      Tema: 'Angular 12',
      Local: 'Porto Alegre'
    },
    {
      Tema: '.NET 5 com Angular',
      Local: 'Cachoeirinha'
    },
    {
      Tema: 'NodeJS',
      Local: 'Canoas'
    }
  ]
  /* #endregion */

  // [Aula.205] → Criar uma propriedade
  public eventos: any;

  // [Aula.205] → Após inserir o HttpClientModule dentro do app.module.ts, injetamos o HttpCliente no construtor.
  constructor(private http: HttpClient) {}

  // Método que é chamado antes de iniciar a aplicação (antes do HTML ser interpretado e atribuido valores ao HTML).
  ngOnInit(): void {
    // [Aula.205] → Chamar o método
    this.getEventos();
  }

  // [Aula.205] → Criar um método
  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      (response) => (this.eventos = response),
      (error) => console.log(error)
    );

    /* #region | Dados para testes antes de utilizar a chamada a API com o banco de dados.
    this.eventos = [
      {
        Tema: 'Angular 12',
        Local: 'Porto Alegre',
      },
      {
        Tema: '.NET 5 com Angular',
        Local: 'Cachoeirinha',
      },
      {
        Tema: 'NodeJS com Angular',
        Local: 'Canoas',
      },
    ];
    /* #endregion */
  }
}
