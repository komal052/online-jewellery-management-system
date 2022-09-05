
import { getcartproductresponse } from './../model/getcartproductdata';

import { showcartproductresponse } from './../model/showcartproductresponse';
import { showreviewresponse } from './../model/showreviewresponse';
import { reviewdata } from './../model/reviewdata';
import { cartdata } from './../model/cartdata';
import { subjewelleryData } from './../model/subjewellerydata';
import { wishlistdata } from './../model/wishlistdata';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { getjewelleryresponse } from '../model/getjewelleryresponse';
import { getsubjewelleryresponse } from '../model/getsubjewelleryresponse';
import { insertresponse } from '../model/insertresponse';
import { jewellerydata } from '../model/jewellerydata';
import { showjewelleryresponse } from '../model/showjewelleryresponse';
import { showsubjewelleryresponse } from '../model/showsubjewelleryresponse';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { NgForm } from '@angular/forms';
import { getuserresponse } from '../model/getuserresponse';
import { userdata } from '../model/userdata';
import { disableDebugTools } from '@angular/platform-browser';
import { getreviewresponse } from '../model/getreviewresponse';
import { cartproductdata } from '../model/cartproductdata';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styles: [],
})
export class ProductDetailsComponent implements OnInit {
  subjewellerylist!: subjewelleryData[];
  jewellerydata!: jewellerydata[];
  wishlist!: wishlistdata[];
  cartdata!: cartdata[];
  cartproductdata!:cartproductdata[];
  reviewlist!: reviewdata[];

  showsubjewelleryresponse: showsubjewelleryresponse | undefined;
  showjewelleryresponse!: showjewelleryresponse;
  showreviewresponse!: showreviewresponse;
  showcartproductresponse!:showcartproductresponse;

  insertresponse: insertresponse | undefined;

  getjewelleryresponse!: getjewelleryresponse;
  getsubjewelleryresponse!: getsubjewelleryresponse;
  getuserresponse!: getuserresponse;
  getreviewresponse!: getreviewresponse;
  getcartproductresponse!:getcartproductresponse;

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

  wishlistData: wishlistdata = {
    wishlist_id_pk: 0,
    subtype_jewellery_id_fk: 0,
    user_id_fk: 0,
    f_name: '',
    l_name: '',
    jewellery_name: '',
    price: '',
    images: '',
  };

  cartDatas: cartdata = {
    cart_id_pk : 0,
    user_id_fk : 0,
    f_name : "",
    l_name : "",
    total_amount : "",

  };

  cartProducts:cartproductdata={
    cart_product_id_pk : 0,
    cart_id_fk: 0,
    subtype_jewellery_id_fk :0,
    jewellery_name:"",
    quantity:'1',
    price: '',
    images: '',

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

  reviewData: reviewdata = {
    review_id_pk: 0,
    subtype_jewellery_id_fk: 0,
    jewellery_name: '',
    rating: '',
    description: '',
    user_id_fk: 0,
    f_name: '',
    l_name: '',
    profile:'',
    is_active: 1,
  };

  subtype_jewellery_id_pk = 0;
  subtype_jewellery_id_fk = 0;
  cartpid=0;

  jewellery_id!: number;

  baseUrl = '';

  constructor(
    private utils: Utils,
    public service: restapi,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.baseUrl = this.utils.baseUrl;
    this.route.params.subscribe((params: Params) => {
      this.subtype_jewellery_id_pk = params['id'];
      this.subtype_jewellery_id_fk = params['id'];
      this.wishlistData.subtype_jewellery_id_fk = params['id'];
      this.reviewData.subtype_jewellery_id_fk = params['id'];
      this.cartProducts.subtype_jewellery_id_fk = params['id'];
      //this.cartProducts.cart_id_fk = params['id'];

    });
    this.getReviewData();

    if (
      this.subtype_jewellery_id_pk != 0 ||
      this.subtype_jewellery_id_pk != undefined
    ) {
      this.getdata();
      this.getReviewData();
    }
  }
  totalamt=0;

  onSubmit(form: NgForm) {
    console.log('subtype_jewellery_id_pk:' + this.subtype_jewellery_id_pk);

    this.insertWishlist(form);
  }
  onCartsubmit(form: NgForm) {
     this.insertAddtocartproduct(form);
    // if(this.cartProducts.cart_product_id_pk==0 || this.cartProducts.cart_product_id_pk==undefined)
    // {
    //   this.insertAddtocartproduct(form);

    // }else{
    //   this.updatecartProduct(form);
    // }
  }
  onReviewsubmit(form: NgForm) {
    this.insertReview(form);
    window.location.reload();
  }

  updatecartProduct(form:NgForm){
    console.log('upadet');
    this.service.UpdateCartProduct(this.cartProducts).subscribe(res=>{
      this.insertresponse= res as insertresponse;
      if(this.insertresponse.result === "success"){
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }
  // insertAddtocart(form: NgForm){

  //   console.log(sessionStorage.getItem('isLoggedIn')?.toString());
  //     if (
  //       sessionStorage.getItem('isLoggedIn')?.toString() === 'false' ||
  //       sessionStorage.getItem('isLoggedIn') == undefined
  //     ) {
  //       alert('please login firsrt');
  //       this.router.navigate(['/client/login'], {
  //         relativeTo: this.route,
  //       });
  //     } else {
  //       console.log('IN');
  //       this.cartProducts.subtype_jewellery_id_fk = this.subtype_jewellery_id_pk;
  //        this.cartDatas.user_id_fk = Number(
  //         sessionStorage.getItem('user_id')?.toString()
  //       );
  //       this.cartProducts.cart_id_fk=Number(
  //         sessionStorage.getItem('cart_id')?.toString()
  //       );
  //       this.service.InsertCart(this.cartDatas).subscribe(
  //         (res) => {
  //           console.log(res);
  //           this.insertresponse = res as insertresponse;
  //           if (this.insertresponse.result === 'success') {
  //             //insert cartproduct
  //               this.service.InsertCartProduct(this.cartProducts).subscribe(
  //                 (res)=>{
  //                   console.log(res);
  //                     this.insertresponse=res as insertresponse;
  //                     if(this.insertresponse.result==='success'){
  //                       console.log(res);
  //                       //this.router.navigate(['/client/cart'], { relativeTo: this.route });
  //                     }
  //                 }
  //               )
  //               this.cartpid=this.cartDatas.cart_id_pk;
  //             this.router.navigate(['/client/cart'], { relativeTo: this.route });
  //           } else {
  //             console.log(res);
  //           }
  //         },
  //         (err) => {
  //           console.log(err);
  //         }
  //       );
  //     }
  // }
  insertAddtocartproduct(form: NgForm) {
    console.log(sessionStorage.getItem('isLoggedIn')?.toString());
    if (
      sessionStorage.getItem('isLoggedIn')?.toString() === 'false' ||
      sessionStorage.getItem('isLoggedIn') == undefined
    ) {
      alert('please login firsrt');
      this.router.navigate(['/client/login'], {
        relativeTo: this.route,
      });
    }
     else {

      console.log('IN');
      this.cartProducts.cart_id_fk = Number(
        sessionStorage.getItem('cart_id')?.toString()
      );
      console.log('cartid:'+sessionStorage.getItem('cart_id')?.toString());

        this.service.InsertCartProduct(this.cartProducts).subscribe(
          (res) => {
            console.log('insert');
            this.insertresponse = res as insertresponse;
            if (this.insertresponse.result === 'success') {
              sessionStorage.setItem('cartproduct_id',this.insertresponse.data.toString());
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

  insertWishlist(form: NgForm) {
    console.log(sessionStorage.getItem('isLoggedIn')?.toString());
    if (
      sessionStorage.getItem('isLoggedIn')?.toString() === 'false' ||
      sessionStorage.getItem('isLoggedIn') == undefined
    ) {
      alert('please login firsrt');
      this.router.navigate(['/client/login'], {
        relativeTo: this.route,
      });
    } else {
      console.log('IN');
      this.wishlistData.subtype_jewellery_id_fk = this.subtype_jewellery_id_pk;
      this.wishlistData.user_id_fk = Number(
        sessionStorage.getItem('user_id')?.toString()
      );

      this.service.InsertWishlist(this.wishlistData).subscribe(
        (res) => {
          console.log(res);
          this.insertresponse = res as insertresponse;
          if (this.insertresponse.result === 'success') {
            this.router.navigate(['/client/wishlist'], {
              relativeTo: this.route,
            });
          } else {
            console.log(res);
          }
        },
        (err) => {
          console.log('failed');
          console.log(err);
        }
      );
    }
  }

  insertReview(form: NgForm) {
    console.log(sessionStorage.getItem('isLoggedIn')?.toString());
    if (
      sessionStorage.getItem('isLoggedIn')?.toString() === 'false' ||
      sessionStorage.getItem('isLoggedIn') == undefined
    ) {
      alert('please login firsrt');
      this.router.navigate(['/client/login'], {
        relativeTo: this.route,
      });
    } else {
      console.log('IN');
      this.reviewData.subtype_jewellery_id_fk = this.subtype_jewellery_id_pk;
      this.reviewData.user_id_fk = Number(
        sessionStorage.getItem('user_id')?.toString()
      );

    this.service.InsertProductreview(this.reviewData).subscribe(
      (res) => {
        console.log(res);
        this.insertresponse = res as insertresponse;
        if (this.insertresponse.result === 'success') {
          this.resetForm(form);
          this.router.navigate(['/client/client'], { relativeTo: this.route });
          // window.location.reload();
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
  // getsubjewellery()
  // {
  //   console.log("subtype_jewellery_id_pk:"+this.subtype_jewellery_id_pk);
  //   this.service.subjewellerydata(this.subtype_jewellery_id_pk).subscribe(res=>{
  //     this.getsubjewelleryresponse=res as getsubjewelleryresponse;
  //     this.subjewellryData = this.getsubjewelleryresponse.data;
  //   },err=>{
  //     console.log(err);
  //   })
  // }

  getdata() {
    this.service
      .subjewellerydata(this.subtype_jewellery_id_pk)
      .subscribe((res) => {
        this.getsubjewelleryresponse = res as getsubjewelleryresponse;
        this.subjewellryData = this.getsubjewelleryresponse.data;
        if (this.getsubjewelleryresponse.result === 'sucsess') {
          this.subtype_jewellery_id_pk =
            this.subjewellryData.subtype_jewellery_id_pk;
          //this.Router.navigate(['/client/productdetails',this.subtype_jewellery_id_pk],{relativeTo:this.route});
        } else {
          console.log(res);
        }
      });
  }

  resetForm(form: NgForm) {
    form.form.reset();
    this.reviewData = new reviewdata();
  }

  getReviewData() {
    // console.log(" hijewellery ID:"+this.subtype_jewellery_id_pk);
    this.service.getProductreviewtList(this.subtype_jewellery_id_fk).subscribe(
      (res) => {
        console.log(res);
        this.showreviewresponse = res as showreviewresponse;
        if (this.showreviewresponse.result === 'success') {
          this.reviewlist = this.showreviewresponse.data;
         console.log('list' + this.reviewlist);
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
