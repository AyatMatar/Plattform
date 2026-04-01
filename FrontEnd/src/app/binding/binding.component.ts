import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { User } from '../models/user';
import * as alertifyjs from 'alertifyjs';

@Component({
  selector: 'app-binding',
  templateUrl: './binding.component.html',
  styleUrls: ['./binding.component.css']
})
export class BindingComponent {
  user: User = new User();
  name: string = "Ali";
  url: string = "../../assets/img/5.jpg";
  isValid: boolean = false;
  onClick() {
    this.name = "Mona";
    this.isValid = !this.isValid;
    console.log(this.name);
    console.log(this.isValid);
  }

  onSubmit(form: NgForm) {
    console.log(form);
    console.log(this.user);
    if (!(this.user.password === this.user.confirmPassword))
      alertifyjs.error('in valid')
    else
      alertifyjs.success('valid');
  }
}

