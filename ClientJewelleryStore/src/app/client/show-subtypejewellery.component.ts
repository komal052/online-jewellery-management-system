import { cartproductdata } from './../model/cartproductdata';
import { Component, OnInit } from '@angular/core';
import { getjewelleryresponse } from '../model/getjewelleryresponse';
import { getsubjewelleryresponse } from '../model/getsubjewelleryresponse';
import { insertresponse } from '../model/insertresponse';
import { jewellerydata } from '../model/jewellerydata';
import { showjewelleryresponse } from '../model/showjewelleryresponse';
import { showsubjewelleryresponse } from '../model/showsubjewelleryresponse';
import { subjewelleryData } from '../model/subjewellerydata';
import { ActivatedRoute, Params, Router } from '@angular/router';

import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { cartdata } from '../model/cartdata';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-show-subtypejewellery',
  templateUrl: './show-subtypejewellery.component.html',
  styles: [],
})
export class ShowSubtypejewelleryComponent implements OnInit {
  subjewelleryData: subjewelleryData[] | undefined;
  filteredSubJewelleryData: subjewelleryData[] | undefined;
  cartdata!: cartdata[];
  insertresponse: insertresponse | undefined;

  showsubjewelleryresponse: showsubjewelleryresponse | undefined;

  type = "";

  baseUrl = '';

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

  subtype_jewellery_id_pk = 0;

  constructor(
    private utils: Utils,
    public service: restapi,
    private route: ActivatedRoute,
    private router: Router  )
     {
    new Promise((resolve) => {
      utils.loadIndexScript();
      resolve(true);
    });
  }

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = function() {
      return false;
  };
    this.baseUrl = this.utils.baseUrl;
    this.showsubjewelleryList();
    this.route.params.subscribe((params: Params) => {
      this.type = params['id'];
      // this.cartData.subtype_jewellery_id_fk = params['id'];
      this.cartProduct.subtype_jewellery_id_fk=params['id'];
    });
    console.log(this.type);


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

  showsubjewelleryList() {
    this.service.getSubJewelleryList().subscribe(
      (res) => {
        console.log(res);
        this.showsubjewelleryresponse = res as showsubjewelleryresponse;
        this.subjewelleryData = this.filteredSubJewelleryData = this.showsubjewelleryresponse.data;

        if (this.type !== "all") {
          console.log("In");
          this.filteredSubJewelleryData = this.subjewelleryData!.filter(subjewel => subjewel.subtype === this.type);
        }
      },
      (err) => {
        console.log(err);
      }
    );
  }

}
