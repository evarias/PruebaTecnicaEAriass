import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/auth.service';

import { Subscription } from 'rxjs';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  standalone: false,
})
export class NavbarComponent implements OnInit, OnDestroy {
  isAuthenticated: boolean = false;
  private authSub!: Subscription;

  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
    this.authSub = this.authService.authStatus$.subscribe(
      (status) => (this.isAuthenticated = status)
    );
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/']);
  }

  ngOnDestroy() {
    if (this.authSub) this.authSub.unsubscribe();
  }
}
