import { orderproductdata } from "./orderproductdata";

export interface getorderproductresponse {
    result: string;
    message: string;
    data: orderproductdata;
  }