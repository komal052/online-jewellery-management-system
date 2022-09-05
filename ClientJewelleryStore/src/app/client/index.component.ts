

import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { cartdata } from '../model/cartdata';
import { cartproductdata } from '../model/cartproductdata';
import { insertresponse } from '../model/insertresponse';
import { jewellerydata } from '../model/jewellerydata';
import { showcartproductresponse } from '../model/showcartproductresponse';
import { showcartresponse } from '../model/showcartresponse';
import { showjewelleryresponse } from '../model/showjewelleryresponse';
import { showsubjewelleryresponse } from '../model/showsubjewelleryresponse';
import { subjewelleryData } from '../model/subjewellerydata';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class IndexComponent implements OnInit {
  jewellerydata: jewellerydata[] | undefined;
  subjewelleryData: subjewelleryData[] | undefined;
  cartdata!: cartdata[];
  cartproductdata:cartproductdata[]|undefined;

  showcartresponse:showcartresponse|undefined;
  showjewelleryresponse: showjewelleryresponse | undefined;
  showsubjewelleryresponse: showsubjewelleryresponse | undefined;
  showcartproductresponse!:showcartproductresponse;
  insertresponse: insertresponse | undefined;

  baseUrl = ''
  type = "";

  subjewellryData: subjewelleryData = {
    subtype_jewellery_id_pk: 0,
    jewellery_id_fk: 0,
    subtype: '',
    price: '',
    images: '',
    description: '',
    is_active: 0,
    jewellery_name: '',
  };
  subtype_jewellery_id_pk=0

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
  cart_id!:number;


  constructor(private utils: Utils, public service: restapi,private route: ActivatedRoute,
    private router: Router) {
    new Promise((resolve) => {
      utils.loadIndexScript();
      resolve(true);
    });
  }

  ngOnInit(): void {
    //window.location.reload();
    this.baseUrl = this.utils.baseUrl;
    this.user_id = Number(sessionStorage.getItem("user_id")?.toString());
    this.cart_id=Number(sessionStorage.getItem('cart_id')?.toString());
    console.log("ID ::::"+this.user_id);
    this.showTopsubjewelleryList();
    this.showCart();

    this.route.params.subscribe((params: Params) => {
      this.cartProduct.subtype_jewellery_id_fk = params['id'];
    });
  }

  showTopsubjewelleryList()
  {
    this.service.getTOpSubJewelleryList().subscribe(res=>{
    console.log(res);
      this.showsubjewelleryresponse= res as showsubjewelleryresponse;
      this.subjewelleryData=this.showsubjewelleryresponse.data;
    },err=>{
      console.log(err);
    });
  }

  showCart()
  {
    this.service.getCartList(this.user_id).subscribe(res=>{
    console.log(res);
      this.showcartresponse= res as showcartresponse;
      this.cartdata=this.showcartresponse.data;
    },err=>{
      console.log(err);
    });
  }
  showCartProduct()
  {
    this.service.getCartProductList(this.cart_id).subscribe(res=>{
    console.log('cart data:'+res);

      this.showcartproductresponse=res as showcartproductresponse;
      this.cartproductdata=this.showcartproductresponse.data;

      // this.cartproductdata.forEach((item) => {
      //   this.total+=Number(item.price)*Number(item.quantity);
      //   console.log(this.total);
      // });
      //this.updateDetails(this.user_id);

    },err=>{
      console.log(err);

    });
  }

  onCartsubmit(form: NgForm) {
    this.insertAddtocart(form);

}

insertAddtocart(form: NgForm) {
  console.log(sessionStorage.getItem('isLoggedIn')?.toString());
  if (sessionStorage.getItem('isLoggedIn')?.toString() === 'false' || sessionStorage.getItem('isLoggedIn') == undefined) {
    alert('please login firsrt');
    this.router.navigate(['/client/login'], {
      relativeTo: this.route,
    });
  }else{

    console.log("IN");
    this.cartProduct.subtype_jewellery_id_fk = this.subtype_jewellery_id_pk;
    this.cartData.user_id_fk = Number(sessionStorage.getItem("user_id")?.toString());

  this.service.InsertCart(this.cartData).subscribe(
    (res) => {
      console.log(res);
      this.insertresponse = res as insertresponse;
      if (this.insertresponse.result === 'success') {
        this.router.navigate(['/client/cart'], { relativeTo: this.route });
      } else {
        console.log(res);
      }
    },
    (err) => {
      console.log(err);
    }
  );
  }
}


}
