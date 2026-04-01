import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Department } from '../department';
import { ServiseService } from '../servise.service';
import * as alertifyjs from 'alertifyjs';
import { PageModeEnum } from '../../../constants/enums';
@Component({
  selector: 'app-department-add',
  templateUrl: './department-add.component.html',
  styleUrls: ['./department-add.component.css']
})
export class DepartmentAddComponent implements OnInit {
  department: Department = new Department();
  icons: string[] = ["fa fa-address-book", "bx bx-layer", "bx bx-tachometer", "fa fa-edit", "fa fa-eye", "fa fa-user-plus",
    "fa fa-female", "fa fa-server", "fa fa-user-circle", "bx bx-file","bx bx-calculator"];
  departmentId: number;
  pageMode: PageModeEnum;
  constructor(private router: Router, private service: ServiseService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    this.handelRouteData();
  }

  get PageModeEnum(): any{
    return PageModeEnum;
  }
  save() {
    this.service.addUpdate(this.department).subscribe(result => {
      alertifyjs.success(result.statusMessage);
      this.router.navigateByUrl('/services');
    });
  }

  handelRouteData() {
    this.route.params.subscribe(params => {
      this.departmentId = params['id'];
      if (this.departmentId)  //edit or view
        this.service.getById(this.departmentId).subscribe(result => {
          this.department = result;
        });   
    });

    this.route.data.subscribe(data => {
      this.pageMode = data['pageMode'];
      console.log(this.pageMode);
    });




  }
}
