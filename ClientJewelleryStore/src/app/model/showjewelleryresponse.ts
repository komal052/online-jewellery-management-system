import { jewellerydata } from "./jewellerydata";

export interface showjewelleryresponse {
    result: string;
    message: string;
    data: jewellerydata[];
}