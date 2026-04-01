import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from '../../alert.service';
import { AuthService } from '../../auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  constructor(private alert: AlertService, private roter: Router, private auth:AuthService) { }
    ngOnInit(): void {
      this.loggedinUserId = +localStorage.getItem('id');
    }
  loggedinUser: string;
  loggedinUserId: number;
  loggedin() {
    //this.loggedinUser = localStorage.getItem('fullName');
    this.loggedinUser = this.auth.getFullName();
    return this.loggedinUser;
  }
  logout() {
    //localStorage.removeItem('fullName');
    //localStorage.removeItem('userName');
    this.auth.logOut();
    this.alert.success("Login successfuly");
    this.roter.navigateByUrl('/user/login');
  }

}
