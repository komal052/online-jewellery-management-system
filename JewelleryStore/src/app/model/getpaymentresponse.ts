import { paymentdata } from './paymentdata';

export interface getpaymentresponse {
  result: string;
  message: string;
  data: paymentdata;
}
