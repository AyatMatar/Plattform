import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { myObject } from '../parent/parent.component';
import { MasterService } from '../sharing-data/master.service';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit {
  constructor(private service: MasterService) {
    this.serviceList = this.service.getData();
  }
  ngOnInit(): void {
    this.newName = sessionStorage.getItem("loginName");
  }
  newName:any;
  serviceList: Array<myObject> = new Array<myObject>();
  @Input() childName!: string;
  @Input() childMark!: string;

  @Input() childObject: myObject = new myObject();
  @Input() childObjectForm: myObject = new myObject();

  @Input() childListArray: Array<myObject> = new Array<myObject>();
  @Output() updateEvent = new EventEmitter<string>();
  childList: Array<myObject> = new Array<myObject>();

  updateData(obj: myObject) {
    this.childList.push(obj);
    return `Good...Student Add with name ${obj.name} and mark ${obj.mark}`
  }
}
