import { orderdata } from './../model/orderdata';
import { cartproductdata } from './../model/cartproductdata';
import { orderproductdata } from './../model/orderproductdata';
import { contactusdata } from './../model/contactusdata';
import { reviewdata } from './../model/reviewdata';
import { wishlistdata } from './../model/wishlistdata';
import { userdata } from './../model/userdata';
import { paymentdata } from './../model/paymentdata';
import { billdata } from './../model/billdata';
import { feedbackdata } from './../model/feedbackdata';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { cartdata } from "../model/cartdata";
import { purchasedata } from "../model/purchasedata";
import { returnjewellerydata } from "../model/returnjewellerydata";
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class restapi {

  constructor(private http: HttpClient) { }
  readonly baseUrl = 'http://localhost:18250/api/Customer/';

  //User
  getUserList(): Observable<any> {
    return this.http.get(this.baseUrl + "UserList")
  }
  getUserdata(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "UserData/" + id);
  }
  InsertUser(formData: FormData): Observable<any> {
    return this.http.post(this.baseUrl + "InsertUser", formData);
  }
  UpdateUser(formData: FormData): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateUser", formData);
  }
  DeleteUser(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteUser/" + id);
  }
  //gold
  getGoldList(): Observable<any> {
    return this.http.get(this.baseUrl + "GoldList");
  }

  getGolddata(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "GoldData/" + id);
  }


  //diamond
  getDiamondList(): Observable<any> {
    return this.http.get(this.baseUrl + "DiamondList");
  }

  getDiamondData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "DiamondData/" + id);
  }


  //SubJewellery
  getSubJewelleryList(): Observable<any> {
    return this.http.get(this.baseUrl + "SubtypejewelleyList")
  }
  getTOpSubJewelleryList(): Observable<any> {
    return this.http.get(this.baseUrl + "TopSubtypejewelleyList")
  }
  subjewellerydata(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "SubjewelleryData/" + id);
  }

  //jewellery

  getJewelleryList(): Observable<any> {
    return this.http.get(this.baseUrl + "JewelleryList")
  }
  getJewellerydata(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "JewelleryData/" + id);
  }

  //discount
  getDiscountList(): Observable<any> {
    return this.http.get(this.baseUrl + "DiscountList");
  }

  getDiscountData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "DiscountData/" + id);
  }

  //Return Jewellery
  getReturnJewelleryList(): Observable<any> {
    return this.http.get(this.baseUrl + "ReturnJewelleryList");
  }

  getReturnJewelleryData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "ReturnJewelleryData/" + id);
  }

  InsertReturnJewellery(returnjewellery: returnjewellerydata): Observable<any> {
    return this.http.post(this.baseUrl + "InserReturnJewellery", returnjewellery);
  }

  UpdateReturnJewellery(returnjewellery: returnjewellerydata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateReturnJewellery", returnjewellery);
  }

  DeleteReturnJewellery(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteReturnJewellery/" + id);
  }

  getPurchaseList(): Observable<any> {
    return this.http.get(this.baseUrl + "PurchaseList");
  }

  getPurchaseData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "PurchaseData/" + id);
  }

  InsertPurchase(purchase: purchasedata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertPurchase", purchase);
  }

  UpdatePurchase(purchase: purchasedata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdatePurchase", purchase);
  }

  DeletePurchase(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeletePurchase/" + id);
  }

  //Cart
  getCartList(user_id: number): Observable<any> {
    return this.http.get(this.baseUrl + "UserCartList/" + user_id);
  }

  getCartData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "CartData/" + id);
  }

  InsertCart(cart: cartdata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertCart", cart);
  }

  CartListCount(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"CartListCount/"+id);
  }

  UpdateCart(cart: cartdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateCart", cart);
  }

  DeleteCart(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteCart/" + id);
  }

//bill
  getBillList(): Observable<any> {
    return this.http.get(this.baseUrl + "BillList")
  }
  getBilldata(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "BillData/" + id);
  }
  InsertBill(billdata: billdata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertBill", billdata);
  }
  UpdateBill(billdata: billdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateBill", billdata);
  }
  DeleteBill(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteBill/" + id);
  }
  //payment
  getPaymentList(): Observable<any> {
    return this.http.get(this.baseUrl + "PaymentList")
  }
  getPaymentdata(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "PaymentData/" + id);
  }
  InsertPayment(paymentdata: paymentdata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertPayment", paymentdata);
  }
  UpdatePayment(paymentdata: paymentdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdatePayment", paymentdata);
  }
  DeletePayment(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeletePayment/" + id);
  }

  //contactus
  getContactusList(): Observable<any> {
    return this.http.get(this.baseUrl + "ContactusList")
  }
  getContactusdata(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "ContactusData/" + id);
  }
  InsertContact(contactusdata: contactusdata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertContactus", contactusdata);
  }
  // InsertPayment(paymentdata:paymentdata):Observable<any>
  // {
  //   return this.http.post(this.baseUrl+"InsertPayment",paymentdata);
  // }
  // UpdatePayment(paymentdata:paymentdata):Observable<any>
  // {
  //   return this.http.post(this.baseUrl+"UpdatePayment",paymentdata);
  // }
  DeleteContactus(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteContactus/" + id);
  }
  //feedback

  InsertFeedback(feedbackdata: feedbackdata): Observable<any> {
    return this.http.post(this.baseUrl + "FeedbackPayment", feedbackdata);
  }
  //state
  getStateList(): Observable<any> {
    return this.http.get(this.baseUrl + "StateList")
  }
  //city
  getCityList(): Observable<any> {
    return this.http.get(this.baseUrl + "CityList")
  }
  getCitydata(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "cityData/" + id);
  }

  //wishlist
  getWishlistList(user_id: number): Observable<any> {
    return this.http.get(this.baseUrl + "WishlistList/"+ user_id)
  }
  getWishlishData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "WishlishData/" + id);
  }
  InsertWishlist(wishlistdata: wishlistdata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertWishlist", wishlistdata);
  }
  UpdateWishlist(wishlistdata: wishlistdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateWishlist", wishlistdata);
  }
  DeleteWishlist(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteWishlist/" + id);
  }

  //product review
  getProductreviewtList(id:number): Observable<any> {
    return this.http.get(this.baseUrl + "ProductreviewtList/"+ id);
  }
  getProductreviewData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "ProductreviewData/" + id);
  }
  InsertProductreview(reviewdata: reviewdata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertProductreview", reviewdata);
  }
  DeleteProductreview(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteProductreview/" + id);
  }

  LoginUser(userdata: userdata): Observable<any> {
    return this.http.post(this.baseUrl + "LoginData", userdata);
  }

  //order Product
  getOrderProduct(id:number): Observable<any> {
    return this.http.get(this.baseUrl + "OrderProductList/"+id);
  }
  getOrderProductData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "OrderProductData/" + id);
  }
  InsertOrderProduct(orderproductdata: orderproductdata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertOrderProduct",orderproductdata);
  }

  DeleteOrderProduct(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteOrderProduct/" + id);
  }

  //cart Product
  getCartProductList(id:number): Observable<any> {
    return this.http.get(this.baseUrl + "UserCartProductList/"+ id);
  }
  InsertCartProduct(cartproductdata: cartproductdata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertCartProduct" , cartproductdata);
  }
  UpdateCartProduct(cartproductdata: cartproductdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateCartProduct", cartproductdata);
  }
  DeleteCartProduct(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteCartProduct/" + id);
  }

  //order
  getOrderList(user_id:number): Observable<any> {
    return this.http.get(this.baseUrl + "OrderList/"+user_id)
  }
  getOrderData(id: number): Observable<any> {
    return this.http.get(this.baseUrl + "OrderData/" + id);
  }
  InsertOrder(orderdata: orderdata): Observable<any> {
    return this.http.post(this.baseUrl + "InsertOrder", orderdata);
  }
  UpdateOrder(orderdata: orderdata): Observable<any> {
    return this.http.post(this.baseUrl + "UpdateOrder", orderdata);
  }
  DeleteOrder(id: number): Observable<any> {
    return this.http.delete(this.baseUrl + "DeleteOrder/" + id);
  }


}



