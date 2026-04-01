import { Component, Input, OnInit } from '@angular/core';
import { AlertService } from '../../alert.service';
import { SectionData, SectionForAddUodate } from '../../models/section';
import { TeacherDto } from '../../models/teacher';
import { SectionService } from '../section.service';

@Component({
  selector: 'app-section-management',
  templateUrl: './section-management.component.html',
  styleUrls: ['./section-management.component.css']
})
export class SectionManagementComponent implements OnInit {
  @Input() sectionId: number;
  canEdit: boolean = false;
  constructor(private service: SectionService, private alert: AlertService) { }
  ngOnInit(): void {
 /*   this.sectionId = 1;*/
    if (this.sectionId) {
      this.service.getSectionById(this.sectionId).subscribe(result => {
        this.section = result;
      }

      );
    }
  
  }
  section: SectionData;
  getfullName(teacher: TeacherDto) {
    return `${teacher.firstName} ${teacher.lastName}`
  }
  allwEdit() {
    this.canEdit = true;
  }
  save() {
    let sectionEdit = new SectionForAddUodate();
    Object.assign(sectionEdit, this.section);

    
    sectionEdit.courseId = this.section.course.id;
    sectionEdit.teacherId = this.section.teacher.id;
    console.log(sectionEdit)
    this.service.updateSection(sectionEdit).subscribe(result => {
      this.canEdit = false;
      this.alert.success("Save Successfull");
    });
  }
}
