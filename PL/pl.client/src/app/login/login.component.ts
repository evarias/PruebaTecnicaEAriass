import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  loading: boolean = false;

  constructor(private authService: AuthService, private router: Router) { }

  onSubmit() {
    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        if (response && response.token) {
          this.router.navigate(['/cliente']);
        }
      },
      error: (err) => {

        if (err.status === 401) {
          alert('Usuario o contraseña incorrectos');
        } else {
          alert('Error al conectar con el servidor.');
        }
      }
    });
  }

}
