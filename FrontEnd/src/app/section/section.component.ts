import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetCourseDto } from '../models/course';
import { SectionData } from '../models/section';
import { SectionService } from './section.service';

@Component({
  selector: 'app-section',
  templateUrl: './section.component.html',
  styleUrls: ['./section.component.css']
})
export class SectionComponent implements OnInit {
  ngOnInit(): void {
   
  }
  courseId: number;
  sections: SectionData[] = new Array<SectionData>();
  course: GetCourseDto;
  constructor(private route: ActivatedRoute, private service: SectionService) {
    this.route.params.subscribe(parmas =>
    {
      this.courseId = parmas['courseId'];
      if (this.courseId) {
        this.service.getSectionByCourseId(this.courseId).subscribe(result => {
          this.sections = result;
          this.course = this.sections[0].course;
        });
      }
      else {
        this.service.getAllSection().subscribe(result => {
          this.sections = result;
        });
      }
    });

    
  }

}
