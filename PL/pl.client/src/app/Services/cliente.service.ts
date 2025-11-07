import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result } from '../Model/result/result.model';
import { Cliente } from '../Model/cliente/cliente.model';

@Injectable({ providedIn: 'root' })
export class ClienteService {
  private urlBase = 'http://localhost:8400/api/Cliente';
  private urlGetAll = `${this.urlBase}/GetAll`;
  private urlGetById = `${this.urlBase}/GetById`;
  private urlAdd = `${this.urlBase}/Add`;
  private urlUpdate = `${this.urlBase}/Update`;
  private urlDelete = `${this.urlBase}/Delete`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Result> {
    return this.http.get<Result>(this.urlGetAll);
  }

  getById(idCliente: number): Observable<Result> {
    const params = new HttpParams().set('IdCliente', idCliente.toString());
    return this.http.get<Result>(this.urlGetById, { params });
  }

  add(nombre: string, apellidoPaterno: string, apellidoMaterno: string): Observable<Result> {
    const params = new HttpParams()
      .set('Nombre', nombre)
      .set('ApellidoPaterno', apellidoPaterno)
      .set('ApellidoMaterno', apellidoMaterno);
    return this.http.post<Result>(this.urlAdd, {}, { params });
  }

  update(modelo: Cliente): Observable<Result> {
    return this.http.put<Result>(this.urlUpdate, modelo);
  }

  delete(idCliente: number): Observable<Result> {
    const params = new HttpParams().set('IdCliente', idCliente.toString());
    return this.http.delete<Result>(this.urlDelete, { params });
  }
}
