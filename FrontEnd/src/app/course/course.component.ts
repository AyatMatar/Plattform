import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { PageModeEnum } from '../constants/enums';
import { Course } from './course';
import { CourseService } from './course.service';
import * as alertifyjs from 'alertifyjs';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {
  constructor(private courseService: CourseService, private router: Router) { }
  ngOnInit(): void {
    this.getData();

    }
  course: Course = new Course();
  courses: Course[] = new Array<Course>();
  pageMode: PageModeEnum = PageModeEnum.Add;
  @ViewChild('closeButton') closeButton: any;
  @ViewChild('openModalButton') openModalButton: any;
  getData() {
    this.courseService.getAllCourses().subscribe(result => {
      this.courses = result;
    });
  }
  reset() {
    this.course = new Course();
    this.pageMode = PageModeEnum.Add;
  }
  edit(course: Course) {
    this.course = course;
    this.pageMode = PageModeEnum.Update;
    this.openModalButton.nativeElement.click();
  }
  view(course: Course) {
    this.course = course;
    this.pageMode = PageModeEnum.View;
    this.openModalButton.nativeElement.click();
  }
  delete(course: Course) {
    if (course)
      if (course.id)
        this.courseService.deleteCourse(course.id).subscribe(result => {
          alertifyjs.success(result.statusMessage);
          this.getData();
        });
  }
  get PageModeEnum(): any {
    return PageModeEnum;
  }
  save() {
    if (this.course.id) {
      this.courseService.updateCourse(this.course).subscribe(result => {
        if (result) {
          alertifyjs.success(result.statusMessage);
          this.getData();
          this.closeButton.nativeElement.click();
        }
        });

    }
    else {
      this.courseService.addCourse(this.course).subscribe(result => {
        if (result) {
          alertifyjs.success(result.statusMessage);
          this.getData();
          this.closeButton.nativeElement.click();
        }
      });
    }
   
  }

}
