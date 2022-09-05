import { cartcount } from './../model/cartcount';
import { userdata } from './../model/userdata';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { cartdata } from '../model/cartdata';
import { showcartresponse } from '../model/showcartresponse';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { getuserresponse } from '../model/getuserresponse';
import { cartproductdata } from '../model/cartproductdata';
import { showcartproductresponse } from '../model/showcartproductresponse';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  encapsulation : ViewEncapsulation.None
})
export class HeaderComponent implements OnInit {
  isLoggedIn=false;
  userResponce! :getuserresponse   ;
  userdata:userdata[]|undefined;
  cartdata:cartdata[]|undefined;
  showcartresponse:showcartresponse|undefined;
  insertresponse:insertresponse|undefined;

  showcartproductresponse!:showcartproductresponse;
  cartproductdata:cartproductdata[]|undefined;

  cartcount:cartcount|undefined;

  data1=0;

  userData : userdata={
    user_id_pk : 0,
    f_name: "",
    l_name : "",
    gender : "",
    birthdate : "",
    status : "",
    anniversary_date : "",
    state_id_fk : 0,
    state_name : "",
    city_id_fk : 0,
    city_name : "",
    address : "",
    pincode:"",
    email : "",
    password : "",
    contact : "",
    u_type : "",
    profile:"",
    is_active : 1
  };
  user_id_pk = 0;


  constructor(private route: ActivatedRoute, private utils:Utils,
    public service:restapi,
    private router: Router) { }

    cartData: cartdata = {
      cart_id_pk : 0,
      user_id_fk : 0,
      f_name : "",
      l_name : "",
      total_amount : "",

    };

    cartProduct:cartproductdata={
      cart_product_id_pk : 0,
      cart_id_fk: 0,
      subtype_jewellery_id_fk :0,
      jewellery_name:"",
      quantity:"",
      price: '',
      images: '',


    }


    user_id!: number;
    cart_id!: number;
    baseUrl =''

  ngOnInit(): void {
    this.baseUrl=this.utils.baseUrl
    this.user_id_pk = Number(sessionStorage.getItem("user_id")?.toString());
    this.getUserData();

    this.user_id = Number(sessionStorage.getItem("user_id")?.toString());
    console.log("ID ::::"+this.user_id);
    this.cart_id=Number(sessionStorage.getItem('cart_id')?.toString());

    this.showCartProduct();
    this.countcart();

    console.log('isLoggedIn');
    console.log(sessionStorage.getItem('isLoggedIn'));
    if(sessionStorage.getItem('isLoggedIn')=="true")
    {
      this.isLoggedIn =true;
    }


  }

  logout(){
    sessionStorage.clear();
    this.router.navigate(['/client'], {
      relativeTo: this.route,
    });
    window.location.reload();
  }


  showCartProduct()
  {
    this.service.getCartProductList(this.cart_id).subscribe(res=>{
    console.log('cart data:'+res);

      this.showcartproductresponse=res as showcartproductresponse;
      this.cartproductdata=this.showcartproductresponse.data;

    },err=>{
      console.log(err);

    });
  }


  deletecartProduct(id:number)
  {
    if(confirm('are u sure to remove from cart'))
    {
      this.service.DeleteCartProduct(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        //this.showCartProduct();
      },err=>{
        console.log(err);
      });
    }
  }
  getUserData() {
    console.log("User ID:"+this.user_id_pk);
    this.service.getUserdata(this.user_id_pk).subscribe(res=>{
      console.log(res);
      this.userResponce=res as getuserresponse;
      this.userData=this.userResponce.data;
    },err=>{
      console.log(err);
    });
  }

  countcart(){
    this.service.CartListCount(this.user_id)
    .subscribe(res=>{
      this.cartcount = res as  cartcount;
      this.data1  =  this.cartcount.data
      console.log(this.data1)
    },err=>{
      console.log(err);
    })

  }

}
