import { Department } from "../templete/services/department";


export class GetCourseDto {
  id: number;
  name: string;
  description: string;
  department: Department
}
