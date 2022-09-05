import { saledata } from './saledata';

export interface showsaleresponse {
  result: string;
  message: string;
  data: saledata[];
}
