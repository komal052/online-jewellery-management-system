import { cartproductdata } from './cartproductdata';

export interface showcartproductresponse {
  result: string;
  message: string;
  data: cartproductdata[];
}
