import { Component, OnInit } from '@angular/core';
import { TeacherDto } from '../../models/teacher';
import { UserService } from '../../user/user.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.css']
})
export class TeamComponent implements OnInit {
  teams: TeacherDto[];
  constructor(private service: UserService) { }
  ngOnInit(): void {
    this.service.getTeam().subscribe(result => {
      console.log(result)
      this.teams = result;
    });
    }
  getfullName(team: TeacherDto) {
    return `${team.firstName}  ${team.lastName}`
  }
}
