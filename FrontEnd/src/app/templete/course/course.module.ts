import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CourseRoutingModule } from './course-routing.module';
import { CourseComponent } from './course.component';
import { CourseManagementComponent } from './course-management/course-management.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    CourseComponent,
    CourseManagementComponent,
  ],
  imports: [
    CommonModule,
    CourseRoutingModule,
    FormsModule,
    HttpClientModule,
  ]
})
export class CourseModule { }
