import { orderdata } from './orderdata';

export interface showorderresponse {
  result: string;
  message: string;
  data: orderdata[];
}
