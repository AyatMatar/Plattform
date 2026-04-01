import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AlertService } from '../alert.service';
import { AuthService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private alert: AlertService, private router:Router) { }
  canActivate(): boolean{
    if (this.authService.isLoggedIn())
      return true
    else {
      this.alert.error("Please login first....!");
      this.router.navigate(['user/login'])
      return false;
    }
      
  }
}
