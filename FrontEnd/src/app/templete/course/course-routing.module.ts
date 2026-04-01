import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageModeEnum } from '../../constants/enums';
import { CourseManagementComponent } from './course-management/course-management.component';
import { CourseComponent } from './course.component';


//new path => course/......
const routes: Routes = [
{ path: 'courses', component: CourseComponent },
{ path: 'courses/:departmentId', component: CourseComponent },
{ path: 'course/add', component: CourseManagementComponent, data: { pageMode: PageModeEnum.Add } },
{ path: 'course/edit/:id', component: CourseManagementComponent, data: { pageMode: PageModeEnum.Update } },
{ path: 'course/view/:id', component: CourseManagementComponent, data: { pageMode: PageModeEnum.View } },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CourseRoutingModule { }
