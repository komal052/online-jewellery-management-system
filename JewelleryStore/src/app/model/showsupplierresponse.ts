import { supplierdata } from './supplierdata';

export interface showsupplierresponse {
  result: string;
  message: string;
  data: supplierdata[];
}
