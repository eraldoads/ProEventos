import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {

  isCollapsed = true; // [Aula.38] - inicia como true para a barra de navegação começar escondida quando diminuir a tela e esconder os itens de navegação.

  constructor() { }

  ngOnInit() {
  }

}
