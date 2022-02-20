import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  // [Aula.90 e 93] → Criado um paramentro Input que recebe o nome e altera o titulo da página selecionada.
  @Input() titulo: string | undefined;

  constructor() { }

  ngOnInit() {
  }

}
