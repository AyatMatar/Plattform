import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { AlertService } from '../../alert.service';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  constructor(private _authService: AuthService, private alert: AlertService, private router: Router) { }
  onLogin(loginForm: NgForm) {
    console.log(loginForm.value)

    this._authService.authUser(loginForm.value).subscribe(result => {
      if (result) {
        //localStorage.setItem('id', result.id.toString());
        //localStorage.setItem('fullName', `${result.firstName}  ${result.lastName}`);
        //localStorage.setItem('userName', result.userName);
        this._authService.storeToken(result.token);
        this._authService.storeFullName(`${result.firstName}  ${result.lastName}`)
        this.alert.success("Login successfuly");
        this.router.navigateByUrl('/services');
      }
      else
        this.alert.error("UserName or password not correct....!");
    });
  }
}
