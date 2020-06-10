import { EventoService } from './../_services/evento.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Evento } from '../models/Evento';
import { BsModalService, BsModalRef, } from 'ngx-bootstrap/modal';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale, ptBrLocale } from 'ngx-bootstrap/chronos';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  // tslint:disable-next-line:variable-name
  _filtroLista: string;

  eventosFiltrados: Evento[];
  eventos: Evento[];
  evento: Evento;
  imgLargura = 50;
  imgMargem = 2;
  exibirImagem = false;
  //modalRef: BsModalRef;
  listaEventos: any;
  registerForm: FormGroup;
  modoSalvar: string = 'post';


  constructor(
    private eventoService: EventoService
    ,private modalService: BsModalService
    ,private localeService: BsLocaleService) {
      this.localeService.use('pt-br')
     }

  get filtroLista() {
    return this._filtroLista;
  }

  set filtroLista(values: string) {
    this._filtroLista = values;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      eventos => eventos.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }

    ngOnInit() {
      this.getEventos();
      this.validation();
    }



  editarEvento(evento: Evento, template: any){
    this.modoSalvar = 'put';
    this.openModal(template);
    this.evento = evento;
    this.registerForm.patchValue(evento);
  }

  novoEvento(template: any){
    this.modoSalvar = 'post';
    this.openModal(template);
  }

     openModal(template: any){
      //this.modalRef = this.modalService.show(template);
      this.registerForm.reset();
      template.show();
    }

    alternarImagem(){
      this.exibirImagem = !this.exibirImagem;
    }

    obterEventos() {
      //this.listaEventos = this.getEventos();

      if (this.eventos.length === 0 || this.filtroLista === undefined){
        return this. eventos;
      }

      return this.eventos.filter(
        res => res.tema.toLocaleLowerCase().includes(this.filtroLista.toLocaleLowerCase()))
    }

    getEventos() {
      this.eventoService.getAllEventos().subscribe(
        (_eventos: Evento[]) =>{
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
        console.log(_eventos);
      },
      error => {
        console.log(error);
      });
  }

  validation(){
    this.registerForm = new FormGroup({
      tema: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(25)]),
      local: new FormControl('', Validators.required),
      dataEvento: new FormControl('', Validators.required),
      qtdPessoas: new FormControl('', [Validators.required, Validators.max(5000)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      telefone: new FormControl('', Validators.required),
      imagemURL: new FormControl('', Validators.required)
    })
  }

  salvarAlteracao(template: any){
    if (this.registerForm.valid){
      if(this.modoSalvar == 'post'){
        this.evento = Object.assign({}, this.registerForm.value);
        this.eventoService.postEvento(this.evento).subscribe(
        (novoEvento: Evento) => {
          console.log(novoEvento);
          template.hide();
          this.getEventos();
        }, error => {
          console.log('Erro no post', error);
        }
      );
      }
      else {
        this.evento = Object.assign({id : this.evento.id}, this.registerForm.value);
        this.eventoService.putEvento(this.evento).subscribe(
        (novoEvento: Evento) => {
          console.log(novoEvento);
          template.hide();
          this.getEventos();
        }, error => {
          console.log('Erro no post', error);
        }
      );
      }
    }
  }
}
