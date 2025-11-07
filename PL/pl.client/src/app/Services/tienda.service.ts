import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result } from '../Model/result/result.model';
import { Tienda } from '../Model/tienda/tienda.model';

@Injectable({ providedIn: 'root' })
export class TiendaService {
  private urlBase = 'http://localhost:8400/api/Tienda';
  private urlGetAll = `${this.urlBase}/GetAll`;
  private urlGetById = `${this.urlBase}/GetById`;
  private urlAdd = `${this.urlBase}/Add`;
  private urlUpdate = `${this.urlBase}/Update`;
  private urlDelete = `${this.urlBase}/Delete`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Result> {
    return this.http.get<Result>(this.urlGetAll);
  }

  getById(idTienda: number): Observable<Result> {
    const params = new HttpParams().set('IdTienda', idTienda.toString());
    return this.http.get<Result>(this.urlGetById, { params });
  }

  add(sucursal: string): Observable<Result> {
    const params = new HttpParams().set('sucursal', sucursal);
    return this.http.post<Result>(this.urlAdd, {}, { params });
  }

  update(modelo: Tienda): Observable<Result> {
    return this.http.put<Result>(this.urlUpdate, modelo);
  }

  delete(idTienda: number): Observable<Result> {
    const params = new HttpParams().set('IdTienda', idTienda.toString());
    return this.http.delete<Result>(this.urlDelete, { params });
  }
}
