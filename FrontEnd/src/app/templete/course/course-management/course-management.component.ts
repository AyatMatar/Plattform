import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../../../alert.service';
import { PageModeEnum } from '../../../constants/enums';
import { Course } from '../../../course/course';
import { CourseService } from '../../../course/course.service';
import { Department, DepartmentLookupDto } from '../../services/department';
import { ServiseService } from '../../services/servise.service';

@Component({
  selector: 'app-course-management',
  templateUrl: './course-management.component.html',
  styleUrls: ['./course-management.component.css']
})
export class CourseManagementComponent implements OnInit {
  courseId: number;
  course: Course = new Course();
  pageMode: PageModeEnum;
  departments: DepartmentLookupDto[] = new Array<DepartmentLookupDto>();
  constructor(private router: Router, private alert: AlertService, private service: CourseService, private route: ActivatedRoute, private departmentService: ServiseService) {

  }
  ngOnInit(): void {
    this.handelRouteData();
    this.getDepartment();
    }
  get PageModeEnum(): any {
    return PageModeEnum;
  }

  handelRouteData() {
    this.route.params.subscribe(params => {
      this.courseId = params['id'];
      if (this.courseId)
        this.service.getCourseById(this.courseId).subscribe(result => {
          this.course = result;
          console.log(this.course);
        });
    });

    this.route.data.subscribe(data => this.pageMode = data['pageMode']);
  }
  save() {
    if (this.courseId) {
      //edit
      this.service.updateCourse(this.course).subscribe(result => {
        if (result) {
          this.alert.success(result.statusMessage);
          this.router.navigateByUrl('/services');
        }
      });
    }
    else {
      //add
      this.service.addCourse(this.course).subscribe(result => {
        if (result) {
          this.alert.success(result.statusMessage);
          this.router.navigateByUrl('/services');
        }
      });
    }
  }
  getDepartment() {
    this.departmentService.getAllDepartmentLookup().subscribe(departmentes => this.departments = departmentes);
  }
}
