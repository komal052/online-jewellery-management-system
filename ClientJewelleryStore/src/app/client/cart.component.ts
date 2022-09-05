import { orderdata } from './../model/orderdata';
import { getcartresponse } from './../model/getcartresponse';

import { getorderresponse } from './../model/getorderresponse';
import { getcartproductresponse } from './../model/getcartproductdata';

import { showcartproductresponse } from './../model/showcartproductresponse';
import { insertresponse } from './../model/insertresponse';
import { showcartresponse } from './../model/showcartresponse';
import { cartdata } from './../model/cartdata';
import { Component, OnInit } from '@angular/core';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { cartproductdata } from '../model/cartproductdata';
import { NgForm } from '@angular/forms';
import { orderproductdata } from '../model/orderproductdata';
import { userdata } from '../model/userdata';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styles: [],
})
export class CartComponent implements OnInit {
  cartdata: cartdata | undefined;
  cartproductdata: cartproductdata[] | undefined;
  showcartresponse: getcartresponse | undefined;

  showcartproductresponse: showcartproductresponse | undefined;
  insertresponse: insertresponse | undefined;
  getcartproductresponse!: getcartproductresponse;

  getorderresponse!: getorderresponse;

  currentDate = new Date();
  constructor(
    private utils: Utils,
    public service: restapi,
    private route: ActivatedRoute,
    private router: Router
  ) {
  }

  userData: userdata = {
    user_id_pk: 0,
    f_name: '',
    l_name: '',
    gender: '',
    birthdate: '',
    status: '',
    anniversary_date: '',
    state_id_fk: 0,
    state_name: '',
    city_id_fk: 0,
    city_name: '',
    address: '',
    pincode: '',
    email: '',
    password: '',
    contact: '',
    u_type: '',
    profile: '',
    is_active: 1,
  };

  cartData: cartdata = {
    cart_id_pk: 0,
    user_id_fk: 0,
    f_name: '',
    l_name: '',
    total_amount: '',
  };

  cartProduct: cartproductdata = {
    cart_product_id_pk: 0,
    cart_id_fk: 0,
    subtype_jewellery_id_fk: 0,
    jewellery_name: '',
    quantity: '',
    price: '',
    images: '',
  };

  OrderData: orderdata = {
    order_id_pk: 0,
    user_id_fk: 0,
    f_name: '',
    l_name: '',
    address: '',
    total_amount: '',
    date: '',
  };
  orderPoduct: orderproductdata = {
    order_product_id_pk: 0,
    order_id_fk: 0,
    subtype_jewellery_id_fk: 0,
    jewellery_name: '',
    images: '',
    price:'',
    quantity: '',
    total_amount: '',
    date: '',
    status: 0,
  };

  baseUrl = '';

  user_id!: number;
  cart_id!: number;
  total = 0;
  cartproduct_id!: number;
  // total:number[]=[];
  price!: number;
  qty!: number;

  ngOnInit(): void {
    this.user_id = Number(sessionStorage.getItem('user_id')?.toString());
    console.log('ID ::::' + this.user_id);

    this.cart_id = Number(sessionStorage.getItem('cart_id')?.toString());
    console.log('cartid:' + this.cart_id);
    this.baseUrl = this.utils.baseUrl;
    this.showCartProduct();

    // this.cartData.user_id_fk = this.user_id;
    // this.service.UpdateCart(this.cartData).subscribe(res=>{
    //   this.insertresponse= res as insertresponse;
    //   this.cartData.total_amount=this.total.toString();
    //   console.log('update tot:'+this.cartData.total_amount);
    // });
  }

  onSubmit(form: NgForm) {
    this.user_id = Number(sessionStorage.getItem('user_id')?.toString());
    this.service.getCartData(this.cart_id).subscribe((res) => {
      console.log(res);
      console.log('getcartid:' + this.cart_id);
      this.showcartresponse = res as getcartresponse;
      if (this.showcartresponse.result === 'success') {
        this.cartData = this.showcartresponse.data;
        this.insertOrder(this.user_id);
       alert("your order has been placed!!")
        this.router.navigate(['/client/ordersucess'], {
          relativeTo: this.route,
        });
      }
    });
  }

  showCartProduct() {
    this.service.getCartProductList(this.cart_id).subscribe(
      (res) => {
        console.log('cart data:' + res);
        console.log('ji');
        this.showcartproductresponse = res as showcartproductresponse;
        this.cartproductdata = this.showcartproductresponse.data;
        console.log('jhii');
        this.cartproductdata.forEach((item) => {
          this.total += Number(item.price) * Number(item.quantity);
          console.log('showcartp'+this.total);
        });
        //this.updateDetails(this.user_id);
      },
      (err) => {
        console.log(err);
      }
    );
  }

  deletecartProduct(id: number) {
    if (confirm('are u sure to remove from cart')) {
      this.service.DeleteCartProduct(id).subscribe(
        (res) => {
          console.log(res);
          this.insertresponse = res as insertresponse;
          this.showCartProduct();
          window.location.reload();
        },
        (err) => {
          console.log(err);
        }
      );
    }
  }





  insertOrder(userId: number) {
    this.OrderData.user_id_fk = userId;
    console.log('user_id_fk' + this.OrderData.user_id_fk);
    this.OrderData.total_amount = this.total.toString();
    const orderDate = formatDate(this.currentDate, 'dd-MM-yyyy', 'en-US');
    this.OrderData.date = orderDate;
    this.service.InsertOrder(this.OrderData).subscribe(
      (res) => {
        console.log(res);
        this.insertresponse = res as insertresponse;
        if (this.insertresponse.result === 'success') {
          var order_id = this.insertresponse.data;

          this.updateCart();

          this.cartproductdata?.forEach(cartProduct => {
            this.insertOrderProduct(order_id,cartProduct);
          });

        } else {
          console.log(res);
        }
      },
      (err) => {
        console.log(err);
      }
    );
  }

  updateCart() {
    this.cartData.total_amount = "0";
    this.service.UpdateCart(this.cartData).subscribe(res => {
      console.log(res);
    },err => {
      console.log(err);
    });
  }
  // updatecartProduct(form:NgForm){
  //   this.service.UpdateCartProduct(this.cartProduct).subscribe(res=>{
  //     this.insertresponse= res as insertresponse;
  //     if(this.insertresponse.result === "success"){
  //     }else{
  //       console.log(res);
  //     }
  //   },err=>{
  //     console.log(err);
  //   });
  // }

  insertOrderProduct(data: number, cartProduct: cartproductdata) {
    this.orderPoduct.order_id_fk = data;
    this.orderPoduct.quantity = cartProduct.quantity;
    this.orderPoduct.subtype_jewellery_id_fk = cartProduct.subtype_jewellery_id_fk;
    this.orderPoduct.status = 1;


    this.service.InsertOrderProduct(this.orderPoduct).subscribe(
      (res) => {
        console.log(res);
        this.deleteCartProduct(cartProduct.cart_product_id_pk);
      },
      (err) => {
        console.log(err);
      }
    );


  }

  deleteCartProduct(id:number){
    this.service.DeleteCartProduct(id).subscribe(
      (res) => {
        console.log(res);
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
