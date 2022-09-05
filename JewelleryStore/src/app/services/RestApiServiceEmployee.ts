import { userdata } from './../model/userdata';
import { paymentdata } from './../model/paymentdata';
import { billdata } from './../model/billdata';
import { jewellerydata } from './../model/jewellerydata';
import { supplierdata } from './../model/supplierdata';
import { employeedata } from './../model/employeedata';
import { purchasedata } from './../model/purchasedata';
import { returnjewellerydata } from './../model/returnjewellerydata';
import { saledata } from './../model/saledata';
import { discountdata } from './../model/discountdata';
import { subjewelleryData } from './../model/subjewellerydata';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { silverdata } from '../model/silverdata';
import { diamonddata } from '../model/diamonddata';
import { golddata } from '../model/golddata';


@Injectable({
    providedIn:'root'
  })
export class erestapi{
 

    constructor(private http:HttpClient){}
    readonly baseUrl='http://localhost:18250/api/Employee/';

//SubJewellery
  getSubJewelleryList():Observable<any>
  {
    return this.http.get(this.baseUrl+"SubJewelleryList")
  }
  getsubjewellerydata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"SubjewelleryData/"+id);
  }
  InsertSubJewellery(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"InsertSubJewellery",formData);
  }
  UpdateSubJewellery(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"UpdateSubJewellery",formData);
  }
  DeleteSubJewellery(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"DeleteSubJewellery/"+id);
  }
  SubtypeJewelleryListCount():Observable<any>{
    return this.http.get(this.baseUrl+"SubtypeJewelleryListCount");
  }

 
  //discount
  getDiscountList() :Observable<any>{
    return this.http.get(this.baseUrl+"DiscountList");
  }

  getDiscountData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"DiscountData/"+id);
  }

  InsertDiscount(discount:discountdata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertDiscount",discount);
  }

  UpdateDiscount(discount:discountdata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateDiscount",discount);
  }

  DeleteDiscount(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteDiscount/"+id);
  }
   //sale
   getSaleList() :Observable<any>{
    return this.http.get(this.baseUrl+"SaleList");
  }

  getSaleData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"SaleData/"+id);
  }

  InsertSale(sale:saledata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertSale",sale);
  }

  UpdateSale(sale:saledata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateSale",sale);
  }

  DeleteSale(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteSale/"+id);
  }
  //Return Jewellery
  getReturnJewelleryList() :Observable<any>{
    return this.http.get(this.baseUrl+"ReturnJewelleryList");
  }

  getReturnJewelleryData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"ReturnJewelleryData/"+id);
  }

  InsertReturnJewellery(returnjewellery:returnjewellerydata):Observable<any>{
    return this.http.post(this.baseUrl+"InserReturnJewellery",returnjewellery);
  }

  UpdateReturnJewellery(returnjewellery:returnjewellerydata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateReturnJewellery",returnjewellery);
  }

  DeleteReturnJewellery(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteReturnJewellery/"+id);
  }
  ReturnJewelleryListCount():Observable<any>{
    return this.http.get(this.baseUrl+"ReturnJewelleryListCount");
  }

  //Purchase
  getPurchaseList() :Observable<any>{
    return this.http.get(this.baseUrl+"PurchaseList");
  }

  getPurchaseData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"PurchaseData/"+id);
  }

  InsertPurchase(purchase:purchasedata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertPurchase",purchase);
  }

  UpdatePurchase(purchase:purchasedata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdatePurchase",purchase);
  }

  DeletePurchase(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeletePurchase/"+id);
  }
 

  //employee
  getEmployeeList() :Observable<any>{
    return this.http.get(this.baseUrl+"EmployeeList");
  }

  getEmployeeData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"EmployeeData/"+id);
  }

  InsertEmployee(employee:employeedata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertEmployee",employee);
  }

  UpdateEmployee(employee:employeedata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateEmployee",employee);
  }

  DeleteEmployee(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteEmployee/"+id);
  }
  EmployeeListCount():Observable<any>{
    return this.http.get(this.baseUrl+"EmployeeListCount");
  }

  //order
  getOrderList() :Observable<any>{
    return this.http.get(this.baseUrl+"OrderList");
  }

  getOrderData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"OrderData/"+id);
  }
  OrderListCount():Observable<any>{
    return this.http.get(this.baseUrl+"OrderListCount");
  }

//   InsertOrder(order:orderdata):Observable<any>{
//     return this.http.post(this.baseUrl+"InsertOrder",order);
//   }

//   UpdateOrder(order:orderdata):Observable<any>{
//     return this.http.post(this.baseUrl+"UpdateOrder",order);
//   }

//   DeleteOrder(id:number):Observable<any>{
//     return this.http.delete(this.baseUrl+"DeleteOrder/"+id);
//   }
  //supplier
  getSupplierList() :Observable<any>{
    return this.http.get(this.baseUrl+"SupplierList");
  }

  getSupplierData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"SupplierData/"+id);
  }

  InsertSupplier(supplier:supplierdata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertSupplier",supplier);
  }

  UpdateSupplier(supplier:supplierdata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateSupplier",supplier);
  }

  DeleteSupplier(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteSupplier/"+id);
  }
  //jewelley
  getJewelleryList():Observable<any>
  {
    return this.http.get(this.baseUrl+"JewelleryList")
  }
  getJewellerydata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"JewelleryData/"+id);
  }
  InsertJewellery(formData :FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"InsertJewellery",formData);
  }
  UpdateJewellery(formData :FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"UpdateJewellery",formData);
  }
  DeleteJewellery(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"DeleteJewellery/"+id);
  }
  JewelleryListCount():Observable<any>{
    return this.http.get(this.baseUrl+"JewelleryListCount");
  }

  //bill
  getBillList():Observable<any>
  {
    return this.http.get(this.baseUrl+"BillList")
  }
  getBilldata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"BillData/"+id);
  }
  InsertBill(billdata:billdata):Observable<any>
  {
    return this.http.post(this.baseUrl+"InsertBill",billdata);
  }
  UpdateBill(billdata:billdata):Observable<any>
  {
    return this.http.post(this.baseUrl+"UpdateBill",billdata);
  }
  DeleteBill(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"DeleteBill/"+id);
  }
  BillListCount():Observable<any>{
    return this.http.get(this.baseUrl+"BillListCount");
  }
  //payment
  getPaymentList():Observable<any>
  {
    return this.http.get(this.baseUrl+"PaymentList")
  }
  getPaymentdata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"PaymentData/"+id);
  }
  InsertPayment(paymentdata:paymentdata):Observable<any>
  {
    return this.http.post(this.baseUrl+"InsertPayment",paymentdata);
  }
  UpdatePayment(paymentdata:paymentdata):Observable<any>
  {
    return this.http.post(this.baseUrl+"UpdatePayment",paymentdata);
  }
  DeletePayment(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"DeletePayment/"+id);
  }
  PaymentListCount():Observable<any>{
    return this.http.get(this.baseUrl+"PaymentListCount");
  }
  

  //contactus
  getContactusList():Observable<any>
  {
    return this.http.get(this.baseUrl+"ContactusList")
  }
  getContactusdata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"ContactusData/"+id);
  }
  // InsertPayment(paymentdata:paymentdata):Observable<any>
  // {
  //   return this.http.post(this.baseUrl+"InsertPayment",paymentdata);
  // }
  // UpdatePayment(paymentdata:paymentdata):Observable<any>
  // {
  //   return this.http.post(this.baseUrl+"UpdatePayment",paymentdata);
  // }
  DeleteContactus(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"DeleteContactus/"+id);
  }
  //feedback
  getFeedbackList():Observable<any>
  {
    return this.http.get(this.baseUrl+"FeedbackList")
  }
  getFeedbackdata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"FeedbackData/"+id);
  }
  // InsertFeedback(feedbackdata:paymentdata):Observable<any>
  // {
  //   return this.http.post(this.baseUrl+"FeedbackPayment",paymentdata);
  // }
  DeleteFeedback(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"DeleteFeedback/"+id);
  }
  ProductreviewList():Observable<any>
  {
    return this.http.get(this.baseUrl+"ProductreviewList") 
  }

  //User
  getUserList():Observable<any>
  {
    return this.http.get(this.baseUrl+"UserList")
  }
  getUserdata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"UserData/"+id);
  }
  UserListCount():Observable<any>{
    return this.http.get(this.baseUrl+"UserListCount");
  }
  
   //certificate
//    getCertiList() :Observable<any>{
//     return this.http.get(this.baseUrl+"CertiList");
//   }

//   getCertidata(id:number):Observable<any>{
//     return this.http.get(this.baseUrl+"Certidata/"+id);
//   }

//   InsertCerti(certidata:certidata):Observable<any>{
//     return this.http.post(this.baseUrl+"InsertCerti",certidata);
//   }

//   UpdateCerti(certidata:certidata):Observable<any>{
//     return this.http.post(this.baseUrl+"UpdateCerti",certidata);
//   }

//   DeleteCerti(id:number):Observable<any>{
//     return this.http.delete(this.baseUrl+"DeleteCerti/"+id);
//   }


  //gold
  getGoldList() :Observable<any>{
    return this.http.get(this.baseUrl+"GoldList");
  }

  getGolddata(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"GoldData/"+id);
  }

  InsertGold(gold:golddata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertGold",gold);
  }

  UpdateGold(gold:golddata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateGold",gold);
  }

  DeleteGold(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteGold/"+id);
  }
  //diamond
  getDiamondList() :Observable<any>{
    return this.http.get(this.baseUrl+"DiamondList");
  }

  getDiamondData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"DiamondData/"+id);
  }

  InsertDiamond(diamond:diamonddata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertDiamond",diamond);
  }

  UpdateDiamond(diamond:diamonddata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateDiamond",diamond);
  }

  DeleteDiamond(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteDiamond/"+id);
  }

  //Silver

  getSilverList() :Observable<any>{
    return this.http.get(this.baseUrl+"SilverList");
  }

  getSilverData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"SilverData/"+id);
  }

  InsertSilver(Silver:silverdata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertSilver",Silver);
  }

  UpdateSilver(Silver:silverdata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateSilver",Silver);
  }

  DeleteSilver(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteSilver/"+id);
  }
 
  ProductOrderList():Observable<any>{
    return this.http.get(this.baseUrl+"ProductOrderList");
  }
  ProductOrderListCount():Observable<any>{
    return this.http.get(this.baseUrl+"ProductOrderListCount");
  }
  ProductOrderLimit():Observable<any>
  {
    return this.http.get(this.baseUrl+"ProductOrderLimit")
  }
  ProductOrderLastList():Observable<any>
  {
    return this.http.get(this.baseUrl+"ProductOrderLastList") 
  }

  
  getStateList():Observable<any>
  {
    return this.http.get(this.baseUrl+"StateList")
  }
  //city
  getCityList():Observable<any>
  {
    return this.http.get(this.baseUrl+"CityList")
  }
  getCitydata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"cityData/"+id);
  }
  
  OrderStatus(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"OrderStatus/"+id)
  }
}
