import { employeedata } from './employeedata';

export interface showemployeeresponse {
  result: string;
  message: string;
  data: employeedata[];
}
