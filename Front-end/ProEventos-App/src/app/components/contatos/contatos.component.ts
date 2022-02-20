import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contatos',
  templateUrl: './contatos.component.html',
  styleUrls: ['./contatos.component.scss']
})
export class ContatosComponent implements OnInit {

  titulo = 'Contatos'; // [Aula.90] → Desafio titulo, chama o componente titulo para apresentar na página (html) selecionada.

  constructor() { }

  ngOnInit() {
  }

}
