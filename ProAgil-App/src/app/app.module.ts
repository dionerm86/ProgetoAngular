import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; //  two way databind
import { AppRoutingModule } from './app-routing.module';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { EventoService } from './_services/evento.service';

import { NavComponent } from './nav/nav.component';
import { AppComponent } from './app.component';
import { EventosComponent } from './eventos/eventos.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { DateTimeFormatPipe } from './_helps/dateTimeFormat.pipe';

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
      FontAwesomeModule,
      BsDropdownModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      BrowserAnimationsModule
    ],
   providers: [
     EventoService
    ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
