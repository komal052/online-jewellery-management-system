import { reviewdata } from './reviewdata';

export interface showreviewresponse {
  result: string;
  message: string;
  data: reviewdata[];
}
