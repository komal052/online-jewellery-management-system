import { getcartresponse } from './../model/getcartresponse';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { getuserresponse } from '../model/getuserresponse';
import { userdata } from '../model/userdata';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { cartdata } from '../model/cartdata';
import { insertresponse } from '../model/insertresponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {

  insertresponse: insertresponse | undefined;

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

  cartData: cartdata = {
    cart_id_pk : 0,
    user_id_fk : 0,
    f_name : "",
    l_name : "",
    total_amount : "",

  };

  getuserresponse!:getuserresponse;

  getcartresponse!:getcartresponse;

  isvalid=false;
  user_id_pk = 0;

  constructor(private utils:Utils,
    public service : restapi, private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.userData=new userdata();
  }
  onSubmit(form:NgForm)
  {

   // console.log(this.userData);
    this.service.LoginUser(this.userData).subscribe(res=>{
     // console.log(res);
      this.getuserresponse=res as getuserresponse;

      if(this.getuserresponse.result==="success")
      {
        this.userData = this.getuserresponse.data;
        console.log(this.userData);

        sessionStorage.setItem('isLoggedIn',"true");
        sessionStorage.setItem('user_id', this.userData.user_id_pk.toString());
        sessionStorage.setItem('user_type',this.userData.u_type);

        this.service.getCartList(this.userData.user_id_pk).subscribe(res=>{
          console.log(res);
          this.getcartresponse=res as getcartresponse;
          if(this.getcartresponse.result=== "success" ){
            this.cartData=this.getcartresponse.data;
            console.log('cartresponse');
            sessionStorage.setItem('cart_id',this.cartData.cart_id_pk.toString());
            console.log('cartid:',this.cartData.cart_id_pk);
          }
          else{
            this.insertcart(this.userData.user_id_pk);
            //console.log('imsert cart');
          }
          });

        if(this.userData.u_type === "Client")
        {
          console.log("success");

          console.log("USER ID:"+this.user_id_pk);

          this.router.navigate(['/client']).then(() => {
            window.location.reload();
          });
        }
      }
      else{
        console.log("failed");
      }
    });

  }
  insertcart(userId:number){

    this.cartData.user_id_fk = userId;
    this.cartData.total_amount = "0";
    console.log('unsert cart1');
    this.service.InsertCart(this.cartData).subscribe(res=>{
      console.log(res);
      this.insertresponse= res as insertresponse;
      if(this.insertresponse.result === "success"){
        sessionStorage.setItem('cart_id',this.insertresponse.data.toString());
        console.log("insert cart");
        //this.resetForm(form);
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }
}
