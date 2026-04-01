import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlertService } from '../../alert.service';
import { Course } from '../../course/course';
import { CourseService } from '../../course/course.service';


@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css']
})
export class CourseComponent implements OnInit {
  departmentId: number;
  courses: Course[] = new Array<Course>();
  constructor(private route: ActivatedRoute, private service: CourseService, private alert: AlertService) { }
  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.departmentId = params['departmentId'];
      this.getData();
    });
    }

  delete(course: Course) {
    this.service.deleteCourse(course.id).subscribe(result => {
      if (result) {
        this.alert.success(result.statusMessage)
        this.getData();
      }
    });
  }
  getData() {
    if (this.departmentId) {

      this.service.getCoursesByDepartmentId(this.departmentId).subscribe(result => {
        this.courses = result;
      });
    }
    else {
      this.service.getAllCourses().subscribe(result => {
        this.courses = result;
      });
    }
  }
}
