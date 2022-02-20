import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {

  titulo = 'Perfil'; // [Aula.90] → Desafio titulo, chama o componente titulo para apresentar na página (html) selecionada.

  constructor() { }

  ngOnInit() {
  }

}
