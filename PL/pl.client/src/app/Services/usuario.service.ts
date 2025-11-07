import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Result } from '../Model/result/result.model';
import { Usuario } from '../Model/usuario/usuario.model';

@Injectable({ providedIn: 'root' })
export class UsuarioService {
  private getAllUrl = 'http://localhost:5065/api/Usuario/GetAll';
  private getByIdUrl = 'http://localhost:5065/api/Usuario/GetById';

  constructor(private http: HttpClient) { }

  private authHeaders(): HttpHeaders {
    const token = localStorage.getItem('token') || '';
    return new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: token ? `Bearer ${token}` : ''
    });
  }

  getUsuarios(): Observable<Result> {
    return this.http.get<Result>(this.getAllUrl, { headers: this.authHeaders() });
  }

  getUsuario(IdUsuario: number): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.getByIdUrl}/${IdUsuario}`, { headers: this.authHeaders() });
  }
}
