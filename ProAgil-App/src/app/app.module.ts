import { EventoService } from './_services/evento.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; //  two way databind

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { NavComponent } from './nav/nav.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { DateTimeFormatPipe } from './_helps/dateTimeFormat.pipe'

@NgModule({
   declarations: [
      AppComponent,
      EventosComponent,
      NavComponent,
      DateTimeFormatPipe
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule, // Two way databind
      FontAwesomeModule   ],
   providers: [
     EventoService
    ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
