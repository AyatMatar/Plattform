import { GetCourseDto } from "./course";
import { TeacherDto } from "./teacher";

export class SectionForAddUodate {
  id: number;
  name: string;
  courseId: number;
  teacherId: number;
  totalHoures: number;
  lecturesPerWeek: number;
  timeFrom: number;
  timeTo: number;

}

export class SectionData {
  id: number;
  name: string;
  totalHoures: number;
  lecturesPerWeek: number;
  timeFrom: number;
  timeTo: number;
  teacher: TeacherDto;
  course: GetCourseDto;  //course.department
}
