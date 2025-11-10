import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './login/login.component';

import { GetallComponent as ClienteGetallComponent } from './cliente/getall/getall.component';
import { FormComponent as ClienteFormComponent } from './cliente/form/form.component';

import { GetallComponent as ArticuloGetallComponent } from './articulo/getall/getall.component';
import { FormComponent as ArticuloFormComponent } from './articulo/form/form.component';

import { GetallComponent as TiendaGetallComponent } from './tienda/getall/getall.component';
import { FormComponent as TiendaFormComponent } from './tienda/form/form.component';

import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full' },

  {
    path: 'cliente',
    canActivate: [AuthGuard], 
    children: [
      { path: '', component: ClienteGetallComponent },
      { path: 'nuevo', component: ClienteFormComponent },
      { path: 'editar/:id', component: ClienteFormComponent },
    ]
  },

  {
    path: 'articulo',
    canActivate: [AuthGuard],
    children: [
      { path: '', component: ArticuloGetallComponent },
      { path: 'nuevo', component: ArticuloFormComponent },
      { path: 'editar/:id', component: ArticuloFormComponent },
    ]
  },

  {
    path: 'tienda',
    canActivate: [AuthGuard],
    children: [
      { path: '', component: TiendaGetallComponent },
      { path: 'nuevo', component: TiendaFormComponent },
      { path: 'editar/:id', component: TiendaFormComponent },
    ]
  },

  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
