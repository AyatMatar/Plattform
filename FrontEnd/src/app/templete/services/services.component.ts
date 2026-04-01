import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from '../../alert.service';
import { AuthService } from '../../auth.service';
import { Department } from './department';
import { ServiseService } from './servise.service';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {
  departments: Array<Department> = new Array<Department>();
  role: string;
  constructor(private service: ServiseService, private router: Router, private alert: AlertService, private auth: AuthService) { }
  ngOnInit(): void {
    this.getData();
    let userlogin = this.auth.decodedToken();
    this.role = userlogin.role
  }
  edit(department: Department) {
    if (department)
      this.router.navigateByUrl(`department-edit/${department.id}`);
  }
  view(department: Department) {
    if (department)
      this.router.navigateByUrl(`department-view/${department.id}`);
  }
  delete(department: Department) {
    if (department)
      this.service.delete(department.id).subscribe(
        result => {
          if (result) {
            this.alert.success(result.statusMessage);
            this.getData();
          }
          else
            this.alert.error("Error on deleting....!");
        }
      );
  }

  getData() {
    this.service.getAlll().subscribe(result => {
      console.log(result)
      this.departments = result;
      ;
    });
  }
}
