import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { ListUserComponent } from './list-user/list-user.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    LoginComponent,
    RegistrationComponent,
    ListUserComponent,
  ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule,
    HttpClientModule
  ]
})
export class UserModule { }
