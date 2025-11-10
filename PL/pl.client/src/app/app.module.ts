import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service'

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { NavbarComponent } from './header/navbar/navbar.component';


import { GetallComponent as ClienteGetallComponent } from './cliente/getall/getall.component';
import { FormComponent as ClienteFormComponent } from './cliente/form/form.component';


import { GetallComponent as ArticuloGetallComponent } from './articulo/getall/getall.component';
import { FormComponent as ArticuloFormComponent } from './articulo/form/form.component';


import { GetallComponent as TiendaGetallComponent } from './tienda/getall/getall.component';
import { FormComponent as TiendaFormComponent } from './tienda/form/form.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  providers: [CookieService],
  declarations: [
    AppComponent,
    NavbarComponent,
    ClienteGetallComponent, ClienteFormComponent,
    ArticuloGetallComponent, ArticuloFormComponent,
    TiendaGetallComponent, TiendaFormComponent, LoginComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
