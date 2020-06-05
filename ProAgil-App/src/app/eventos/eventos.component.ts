import { EventoService } from './../_services/evento.service';
import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  // tslint:disable-next-line:variable-name
  _filtroLista: string;

  get filtroLista() {
    return this._filtroLista;
  }

  set filtroLista(values: string) {
    this._filtroLista = values;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  eventosFiltrados: Evento[];
  eventos: Evento[];
  imgLargura = 50;
  imgMargem = 2;
  exibirImagem = false;

  constructor(private eventoService: EventoService) { }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      eventos => eventos.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }

    alternarImagem(){
      this.exibirImagem = !this.exibirImagem;
    }

    getEventos() {
      this.eventoService.getAllEvento().subscribe(
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
