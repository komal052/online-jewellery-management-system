import { showwishlistresponse } from './../model/showwishlistresponse';
import { wishlistdata } from './../model/wishlistdata';
import { Component, OnInit } from '@angular/core';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { cartdata } from '../model/cartdata';
import { NgForm } from '@angular/forms';
import { subjewelleryData } from '../model/subjewellerydata';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { getsubjewelleryresponse } from '../model/getsubjewelleryresponse';
import { getuserresponse } from '../model/getuserresponse';
import { cartproductdata } from '../model/cartproductdata';

@Component({
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styles: [
  ]
})
export class WishlistComponent implements OnInit {

  wishlistdata:wishlistdata[] |undefined;
  showwishlistresponse:showwishlistresponse|undefined;
  insertresponse:insertresponse | undefined;

  wishlistData:wishlistdata={

    wishlist_id_pk: 0,
    subtype_jewellery_id_fk : 0,
    user_id_fk : 0,
    f_name : '',
    l_name : '',
    jewellery_name : '',
    price : '',
    images : ''
  }

  getsubjewelleryresponse!: getsubjewelleryresponse;
  getuserresponse!: getuserresponse;

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

  cartData: cartdata = {
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
  user_id!: number;

  constructor(private utils:Utils,public service:restapi,private route: ActivatedRoute,
    private router: Router) { }
  baseUrl =''

  ngOnInit(): void {
    this.user_id = Number(sessionStorage.getItem("user_id")?.toString());
    console.log("ID ::"+this.user_id);
    this.baseUrl=this.utils.baseUrl
    this.showWishList();

  }

  showWishList()
  {
    this.service.getWishlistList(this.user_id).subscribe(res=>{
    console.log(res);
      this.showwishlistresponse= res as showwishlistresponse;
      this.wishlistdata=this.showwishlistresponse.data;
    },err=>{
      console.log(err);
    });
  }

  deletewishlist(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteWishlist(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showWishList();
      },err=>{
        console.log(err);
      });
    }
  }

  onCartsubmit(form: NgForm) {
      this.insertAddtocartproduct(form);
  }

  insertAddtocartproduct(form: NgForm) {
      console.log('IN');
      this.cartProducts.cart_id_fk = Number(
        sessionStorage.getItem('cart_id')?.toString()
      );
      console.log('cartid:'+sessionStorage.getItem('cart_id')?.toString());

        this.service.InsertCartProduct(this.cartProducts).subscribe(
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
