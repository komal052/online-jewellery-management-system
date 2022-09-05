import { purchasedata } from './purchasedata';

export interface showpurchaseresponse {
  result: string;
  message: string;
  data: purchasedata[];
}
