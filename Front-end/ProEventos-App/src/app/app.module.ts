import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CollapseModule } from 'ngx-bootstrap/collapse'; // [Aula.38] → NavBar.
import { TooltipModule } from 'ngx-bootstrap/tooltip'; // [Aula.85] → Tolltip.
import { BsDropdownModule } from 'ngx-bootstrap/dropdown'; // [Aula.85] → Dropdown.
import { ModalModule } from 'ngx-bootstrap/modal'; // [Aula.86] → Modal.

import { ToastrModule } from 'ngx-toastr'; // [Aula.87] → Toastr.
import { NgxSpinnerModule } from 'ngx-spinner'; // [Aula.88] → Spinner.

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContatosComponent } from './components/contatos/contatos.component'; // [Aula.91] → Components
import { DashboardComponent } from './components/dashboard/dashboard.component'; // [Aula.91] → Components
import { EventosComponent } from './components/eventos/eventos.component';
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component';
import { PerfilComponent } from './components/perfil/perfil.component'; // [Aula.91] → Components
import { TituloComponent } from './shared/titulo/titulo.component'; // [Aula.90] → Desafio do Titulo
import { NavComponent } from './shared/nav/nav.component';

import { EventoService } from './services/evento.service';

import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe'; // [Aula.84] → Filtro Data Pipe.

@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
    ContatosComponent, // [Aula.91] → Components
    DashboardComponent, // [Aula.91] → Components
    PerfilComponent, // [Aula.91] → Components
    TituloComponent, // [Aula.90] → Desafio do Titulo
    NavComponent,
    DateTimeFormatPipe // [Aula.84] → Filtro Data Pipe.
   ],
  imports: [
    BrowserModule,
    FormsModule, // [Aula.46] → Two-way Data Binding.
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(), // [Aula.38] → NavBar.
    TooltipModule.forRoot(), // [Aula.85] → Tolltip.
    BsDropdownModule.forRoot(), // [Aula.85] → Dropdown.
    ModalModule.forRoot(), // [Aula.86] → Modal.
    ToastrModule.forRoot({
      timeOut: 4000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }), // [Aula.87] → Toastr.
    NgxSpinnerModule // [Aula.88] → Spinner.
  ],
  providers: [
    EventoService // [Aula.80] → 3ª maneira de injetar o serviço.
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
