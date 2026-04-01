import { DepartmentLookupDto } from "../templete/services/department";


export class Course {
  id!: number;
  name!: string;
  description!: string;
  creationDate?: Date;
  updateDate?: Date;
  departmentId: number;
  department?: DepartmentLookupDto
}
