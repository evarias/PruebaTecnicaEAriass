import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result } from '../Model/result/result.model';
import { Articulo } from '../Model/articulo/articulo.model';

@Injectable({ providedIn: 'root' })
export class ArticuloService {
  private urlBase = 'http://localhost:8400/api/Articulo';
  private urlGetAll = `${this.urlBase}/GetAll`;
  private urlGetById = `${this.urlBase}/GetById`;
  private urlAdd = `${this.urlBase}/Add`;
  private urlUpdate = `${this.urlBase}/Update`;
  private urlDelete = `${this.urlBase}/Delete`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Result> {
    return this.http.get<Result>(this.urlGetAll);
  }

  getById(idArticulo: number): Observable<Result> {
    const params = new HttpParams().set('IdArticulo', idArticulo.toString());
    return this.http.get<Result>(this.urlGetById, { params });
  }

  add(modelo: Articulo): Observable<Result> {
    return this.http.post<Result>(this.urlAdd, modelo);
  }

  update(modelo: Articulo): Observable<Result> {
    return this.http.put<Result>(this.urlUpdate, modelo);
  }

  delete(idArticulo: number): Observable<Result> {
    if (!idArticulo) {
      throw new Error('El ID del artículo no puede ser undefined o 0');
    }

    const params = new HttpParams().set('IdArticulo', idArticulo.toString());
    return this.http.delete<Result>(this.urlDelete, { params });
  }


}
