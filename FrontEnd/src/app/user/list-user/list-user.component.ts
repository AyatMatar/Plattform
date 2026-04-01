import { Component, OnInit, ViewChild } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../user.service';
import * as alertifyjs from 'alertifyjs';
import { Router } from '@angular/router';
import { PageModeEnum } from '../../constants/enums';
@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {
  constructor(private userService: UserService, private router: Router) { }
  users: User[] = new Array<User>();
  isPopup: boolean = true;
  isValid: boolean = false;
  user: User = new User();
  pageMode: PageModeEnum = PageModeEnum.Add;
  @ViewChild('closeButton') closeButton: any;
  @ViewChild('openModalButton') openModalButton: any;
  ngOnInit(): void {
    this.getAllUsers();
  }

  delete(user: User) {
    if (user.id) {
      this.userService.deleteUser(user.id).subscribe(result => {
        this.getAllUsers();
        alertifyjs.success(result.statusMessage);
      });
    }
  }

  getAllUsers() {
    this.userService.getAllUser().subscribe(result => {
      this.users = result;
    });
  }

  goToupdateuser(user: User) {
    if(user.id)
      this.router.navigateByUrl(`user/user-update/${user.id}`);
  }
  reset() {
    this.user = new User();
    this.pageMode = PageModeEnum.Add;
  }
  save() {
    if (this.isValid) {
      if (!(this.user.password === this.user.confirmPassword))
        alertifyjs.error("In valid form => password != confirmPassword");
      else {
        this.userService.addUpdateUser(this.user).subscribe(
          result => {
            alertifyjs.success(result.statusMessage);
            this.closeButton.nativeElement.click();
            this.getAllUsers();
          });
      }
    }
    else
      alertifyjs.error("In valid form")
  }

  edit(user: User) {
    this.user = user;
    this.user.confirmPassword = this.user.password;
    this.pageMode = PageModeEnum.Update;
    this.openModalButton.nativeElement.click();
  }
  view(user: User) {
    this.user = user;
    this.user.confirmPassword = this.user.password;
    this.pageMode = PageModeEnum.View;
    this.openModalButton.nativeElement.click();
  }
  get PageModeEnum(): any {
    return PageModeEnum;
  }
}
