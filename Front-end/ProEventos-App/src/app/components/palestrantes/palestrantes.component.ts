import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-palestrantes',
  templateUrl: './palestrantes.component.html',
  styleUrls: ['./palestrantes.component.scss']
})
export class PalestrantesComponent implements OnInit {

  titulo = 'Paletrantes'; // [Aula.90] → Desafio titulo, chama o componente titulo para apresentar na página (html) selecionada.

  constructor() { }

  ngOnInit() {
  }

}
