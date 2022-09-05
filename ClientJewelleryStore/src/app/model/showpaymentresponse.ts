import { paymentdata } from './paymentdata';

export interface showpaymentresponse {
  result: string;
  message: string;
  data: paymentdata[];
}
