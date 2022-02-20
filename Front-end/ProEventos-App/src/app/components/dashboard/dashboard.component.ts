import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  titulo = 'Dashboard'; // [Aula.90] → Desafio titulo, chama o componente titulo para apresentar na página (html) selecionada.

  constructor() { }

  ngOnInit() {
  }

}
