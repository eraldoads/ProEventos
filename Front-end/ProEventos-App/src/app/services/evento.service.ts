import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Evento } from '../models/Evento';


// [Aula.80] → nesse @Injectable significa que pode injetar a classe em qualquer lugar que quiser.
@Injectable(
  // { providedIn: 'root'} // [Aula.80] → 1ª maneira de injetar o serviço.
)
export class EventoService {
  baseURL = 'https://localhost:5001/api/eventos';

  constructor(private http: HttpClient) { }

  // [Aula.81] → Tipando os métodos utilizando o Observable. Método que traz todos os eventos cadastrados.
  public getEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(this.baseURL);
  }

  // [Aula.81] → Tipando os métodos utilizando o Observable. Método que traz o evento cadastrato pelo Tema.
  public getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.baseURL}/${tema}/tema`);
  }

  // [Aula.81] → Tipando os métodos utilizando o Observable. Método que traz o evento cadastrado pelo Id.
  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.baseURL}/${id}`);
  }
}
