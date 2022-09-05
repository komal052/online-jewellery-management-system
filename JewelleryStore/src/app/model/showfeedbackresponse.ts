import { feedbackdata } from './feedbackdata';

export interface showfeedbackresponse {
  result: string;
  message: string;
  data: feedbackdata[];
}
