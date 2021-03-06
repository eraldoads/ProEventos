import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '../../models/Evento';
import { EventoService } from '../../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
  // providers: [EventoService] // [Aula.80] → 2ª maneira de injetar o serviço.
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
  #endregion */

  // [Aula.86] → Acrescentando a referencia do Modal.
  modalRef?: BsModalRef;

  titulo = 'Eventos'; // [Aula.90] → Desafio titulo, chama o componente titulo para apresentar na página (html) selecionada.

  // [Aula.205] → Criar uma propriedade.
  // [Aula.43] → Colocar o "[]" para que não apresente erro no "*ngIf="!eventos.length"" dessa forma atribuimos um valor vazio, alocando um espaço de memoria informando que é um array.
  // public eventos: any = [];
  // [Aula.81] → Declarar como evento.
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  // [Aula.44] → Determinando a Largura e Margem da imagem.
  // [Aula.45] → Alterado os nomes das propriedades e criando uma nova.
  /// public larguraImagem: number = 70;
  /// public margemImagem: number = 15;
  /// public exibirImagem: boolean = true;
  // [Aula.46] → Cria uma nova propriedade.
  // [Aula.47] → Altera a propriedade para uma privada.
  /// private _filtroLista: string = '';
  // public eventosFiltrados: any = [];

  // [Aula.82] → Removendo o tipo
  public larguraImagem = 70;
  public margemImagem = 15;
  public exibirImagem = true;
  private _filtroListado = '';

  // [Aula.47] → Cria os métodos GET e SET para não apresentar mais o erro no html.
  public get filtroLista(): string {
    return this._filtroListado;
  }

  public set filtroLista(value: string) {
    this._filtroListado = value;
    // [Aula.47] → Toda vez que é alterado o valor ele deve carregar novamente o eventos, aqui ele tem que receber os eventos filtrados.
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  // [Aula.47] → Criação do método que vai filtar o que esta sendo digitado no campo de busca.
  // filtrarEventos(filtrarPor: string): any {
  // [Aula.81] → Anterar para Evento.
  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      (evento: { tema: string; local: string; }) =>
      // [Aula.47] → Coloca os campos que deseja que sejam filtrados.
      evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }

  // [Aula.205] → Após inserir o HttpClientModule dentro do app.module.ts, injetamos o HttpCliente no construtor.
  /// constructor(private http: HttpClient) {}

  // [Aula.79] → O contrutor agora passa a receber o EventoServices dentro do Serviço criado.
  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService, // [Aula.86] → Injetando o serviço do Modal.
    private toastr: ToastrService, // [Aula.87]→ Injetando o serviço do Toastr.
    private spinner: NgxSpinnerService, // [Aula.88] → Injetando o serviço do Spinner.
  ) { }

  // Método que é chamado antes de iniciar a aplicação (antes do HTML ser interpretado e atribuido valores ao HTML).
  public ngOnInit(): void {
    // [Aula.205] → Chamar o método
    this.getEventos();
    this.spinner.show();

  }

  // [Aula.45] → Cria o método que ira apresentar ou ocultar as imagens na tela.
  public alterarImagem(): void {
    this.exibirImagem = !this.exibirImagem;
  }

  // [Aula.205] → Criar um método
  public getEventos(): void {
    /// this.http.get('https://localhost:5001/api/eventos').subscribe(
    // [Aula.79] → O Get agora será realizado dentro do Services, encapsula a chamada dos eventos.
    // this.eventoService.getEventos().subscribe(
    // [Aula.47] → Trecho alterado para que quando a tela seja atualizada a Grid não fique vazia.
    // (response) => {
    // [Aula.81] → Agora como o componente é Tipado muda o seguinte trecho no código.
    // (eventos: Evento[]) => {
    //     (this.eventos = eventos);
    //     this.eventosFiltrados = this.eventos
    //   },
    //   (error) => console.log(error)
    // );

    // [Aula.82] → Ajustando o Observable com métodos para não ficar obsoletos. (TSLint Reclama).
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        (this.eventos = eventos);
        this.eventosFiltrados = this.eventos
      },
      // error: (error: any) => console.log(error),
      error: (error: any) => {
        this.spinner.hide(),
        this.toastr.error('Não foi possível carregar os eventos!', 'ERRO!')
      },
      complete: () => this.spinner.hide()
    });

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

    public openModal(template: TemplateRef<any>): void {
      this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
    }

    public confirm(): void {
      this.modalRef?.hide();
      this.toastr.success('Evento excluido com sucesso!', 'EXCLUIDO!');
    }

    public decline(): void {
      this.modalRef?.hide();

  }
}
