import { Injectable } from '@angular/core';
import { myObject } from '../parent/parent.component';

@Injectable({
  providedIn: 'root'
})
export class MasterService {
  servisearray: Array<myObject> = new Array<myObject>();
  constructor() { }

  getData() {
    return this.servisearray;
  }

  saveData(obj: myObject) {
    this.servisearray.push(obj);
  }
}
