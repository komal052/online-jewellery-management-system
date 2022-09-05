import { orderproductdata } from './orderproductdata';


export interface showorderproductresponse {
  result: string;
  message: string;
  data: orderproductdata[];
}
