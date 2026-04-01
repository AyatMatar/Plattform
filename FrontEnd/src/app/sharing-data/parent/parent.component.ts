import { Component, ViewChild } from '@angular/core';
import { ChildComponent } from '../child/child.component';
import { MasterService } from '../sharing-data/master.service';

@Component({
  selector: 'app-parent',
  templateUrl: './parent.component.html',
  styleUrls: ['./parent.component.css']
})
export class ParentComponent {
  constructor(private service: MasterService) {
    sessionStorage.setItem("loginName","Ali Ahmad");
  }
  title: string = "Parent Component";
  parentName!: string;
  parentMark!: string;
  parentObject: myObject = new myObject();
  parentObjectForm: myObject = new myObject();
  parentListArray: Array<myObject> = new Array<myObject>();
  response!: string;
  @ViewChild(ChildComponent) viewData!: ChildComponent;


  getData(name: string, mark: string) {
    //this.parentName = name;
    //this.parentMark = mark;
    this.parentObject = { "name": name, "mark": mark };
    this.service.saveData(this.parentObject);
   // this.parentListArray.push(this.parentObject);
    //this.response = this.viewData.updateData(this.parentObject);
  }
  updateTitle(newTitle: string) {
    this.title = newTitle;
  }
}


export class myObject {
  name: string='***';
  mark: string='***';
}
