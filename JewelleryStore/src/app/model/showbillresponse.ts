import { billdata } from './billdata';

export interface showbillresponse {
  result: string;
  message: string;
  data: billdata[];
}
