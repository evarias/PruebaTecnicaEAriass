import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:8400/api/Usuario/GetUser';
  private tokenKey = 'jwt_token';

  private authStatus = new BehaviorSubject<boolean>(false);
  authStatus$ = this.authStatus.asObservable();

  constructor(private http: HttpClient, private cookieService: CookieService) {
    const isLoggedIn = this.cookieService.check(this.tokenKey);
    this.authStatus.next(isLoggedIn);
  }

  login(email: string, password: string): Observable<any> {
    const body = { email, password };

    return this.http.post<any>(this.apiUrl, body).pipe(
      tap((response) => {
        if (response && response.token) {
          this.cookieService.set(this.tokenKey, response.token, 1, '/');
          this.authStatus.next(true);
        }
      })
    );
  }

  logout(): void {
    this.cookieService.delete(this.tokenKey, '/');
    this.authStatus.next(false);
  }

  getToken(): string {
    return this.cookieService.get(this.tokenKey);
  }

  hasToken(): boolean {
    return this.cookieService.check(this.tokenKey);
  }
}
