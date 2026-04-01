import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from '../../alert.service';
import { Course } from '../../course/course';
import { CourseService } from '../../course/course.service';
import { GetCourseDto } from '../../models/course';
import { SectionForAddUodate } from '../../models/section';
import { TeacherDto } from '../../models/teacher';
import { DepartmentLookupDto } from '../../templete/services/department';
import { ServiseService } from '../../templete/services/servise.service';
import { UserService } from '../../user/user.service';
import { SectionService } from '../section.service';

@Component({
  selector: 'app-section-add',
  templateUrl: './section-add.component.html',
  styleUrls: ['./section-add.component.css']
})

export class SectionAddComponent implements OnInit {
  constructor(private service: SectionService, private departmentService: ServiseService, private courseServce: CourseService,
    private teamservice: UserService, private alert: AlertService, private router:Router) { }
  ngOnInit(): void {
    this.getDepartment();
    this.getTeam();
  }
  section: SectionForAddUodate = new SectionForAddUodate();
  departmentId: number;
  departments: DepartmentLookupDto[] = new Array<DepartmentLookupDto>();
  courses: Course[] = new Array<Course>();
  teams: TeacherDto[];
  getDepartment() {
    this.departmentService.getAllDepartmentLookup().subscribe(departmentes => this.departments = departmentes);
  }
  departmentChange(departmentId: number) {
    this.courseServce.getCoursesByDepartmentId(departmentId).subscribe(result => {
      if (result.length) {
        this.courses = result;
      }
      else {
        this.courses = new Array<Course>();
        this.section.courseId = null;
        this.alert.error("You should add Course Before Add Section......Please add Course...!")
      }
       
      
    });
  }
  getTeam() {
    this.teamservice.getTeam().subscribe(result => {
      console.log(result)
      this.teams = result;
    });
  }
  save(form:any) {
    if (form.valid) {
      this.service.addSection(this.section).subscribe(result => {
        this.alert.success(result.statusMessage);
        this.router.navigateByUrl('/sections');
      });
    }
    
    else
      this.alert.error("Please fill all requerd fields...!")
  }

}
