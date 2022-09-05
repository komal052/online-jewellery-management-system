import { cartproductdata } from './cartproductdata';

export interface getcartproductresponse {
  result: string;
  message: string;
  data: cartproductdata;
}
