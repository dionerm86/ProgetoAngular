import { EventoService } from './../_services/evento.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Evento } from '../models/Evento';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

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
  imgLargura = 50;
  imgMargem = 2;
  exibirImagem = false;
  modalRef: BsModalRef;
  listaEventos: any;


  constructor(
    private eventoService: EventoService
    ,private modalService: BsModalService) { }

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
    }

     openModal(template: TemplateRef<any>){
      this.modalRef = this.modalService.show(template);
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
}
