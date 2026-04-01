import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import * as alertifyjs from 'alertifyjs';
import { PageModeEnum } from '../../constants/enums';
import { Status } from '../../models/status';
import { User } from '../../models/user';
import { UserService } from '../user.service';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {
  constructor(private userService: UserService, private router: Router, private activatedRoute: ActivatedRoute) {

  }
  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      this.userId = params['id'];
      if (this.userId) {
        this.pageMode = PageModeEnum.Update;
        this.userService.getUserById(this.userId).subscribe(result => {
          this.user = result;
          this.user.confirmPassword = this.user.password;
        });

      }
    });
  }
  @Input() isPopup: boolean = false;

  pageModeTest: string = "Add";
  @Input() pageMode: PageModeEnum = PageModeEnum.Add;
  userId!: number;
  @Input() user: User = new User();
  @Output() isValid = new EventEmitter<boolean>();
  @ViewChild('userForm') userForm!: NgForm;
  status: Status = new Status();

  get PageModeEnum(): any {
    return PageModeEnum;
  }
  onSubmit(form: NgForm) {
    if (form.valid) {
      if (!(this.user.password === this.user.confirmPassword)) {
        alertifyjs.error('in valid => Password not equal with Confirm Password.....!');
      }
      else {
        this.userService.addUpdateUser(this.user).subscribe(result => {
          if (result) {
            alertifyjs.success(result.statusMessage);
            this.router.navigate(['/user/login']);
          }
        });
      }

    }
    else {
      alertifyjs.error('in valid')
    }


   
  }
  reset() {
    this.user = new User();
  }

  ngAfterViewInit() {
    if (this.userForm.statusChanges)
      this.userForm.statusChanges.subscribe(
        result => this.isValid.emit(result != 'INVALID')
      );
  }
}
