import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

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

  eventosFiltrados: any = [];
  eventos: any = [];
  imgLargura = 50;
  imgMargem = 2;
  exibirImagem = false;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      eventos => eventos.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
      );
    }

    alternarImagem(){
      this.exibirImagem = !this.exibirImagem;
    }

    getEventos() {
      this.http.get('http://localhost:5000/api/values').subscribe( response => {
      this.eventos = response;
    }, error => {
      console.log(error);
    }
    );
  }
}
