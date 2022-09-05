import { getcartresponse } from './../model/getcartresponse';

import { ActivatedRoute, Params, Router } from '@angular/router';

import { Component, OnInit } from '@angular/core';

import { NgForm } from '@angular/forms';
import { citydata } from '../model/citydata';
import { getuserresponse } from '../model/getuserresponse';
import { insertresponse } from '../model/insertresponse';
import { showcityresponse } from '../model/showcityresponse';
import { showstateresponse } from '../model/showstateresponse';
import { statedata } from '../model/statedata';
import { userdata } from '../model/userdata';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { cartdata } from '../model/cartdata';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent implements OnInit {

userResponce! :getuserresponse;
cartResponse!:getcartresponse;

  stateList!:statedata[];
  cityList!:citydata[];
  insertResponce!:insertresponse;
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
    email : "",
    pincode:"",
    password : "",
    contact : "",
    u_type : "",
    profile:"",
    is_active : 1
  };
  cartDatas: cartdata = {
    cart_id_pk : 0,
    user_id_fk : 0,
    f_name : "",
    l_name : "",
    total_amount : "",

  };

  user_id_pk = 0;
  cart_id_pk=0;

  showstateresponse!: showstateresponse;
  showcityresponse!:showcityresponse;
  status:string="";
  inputDisabled:boolean=false;
  // form: any;

  filesToUpload : FileList | undefined;

  u_type='Client'

  constructor(private utils:Utils,public service : restapi, private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

   public uploadFile = (files: FileList | null) =>{
    if(files!.length === 0){
      return;
    }
    this.filesToUpload = files!
  }

OnStatusChange(value:any){
  value=this.userData.status;
  if(value==="single")
  {
    //console.log("single");
    document.getElementById('user_anniversary')?.setAttribute("disabled","false");
  }else{
    //console.log("married");
    document.getElementById("user_anniversary")?.removeAttribute("disabled");
  }
}
   ngOnInit(): void {

    this.getState();
    //this.getCity();
    this.route.params.subscribe((params:Params)=>{
      this.user_id_pk=params['id'];
      this.cartDatas.user_id_fk=params['id'];
    });
    if(this.user_id_pk==0 || this.user_id_pk == undefined){
      this.userData=new userdata();
      this.getCartdata();
    }else{
      this.cartDatas=new cartdata();
      console.log();
      this.getUserData();


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

  getCartdata(){
    this.service.getCartData(this.cart_id_pk).subscribe(res=>{
      console.log(res);
      this.cartResponse=res as getcartresponse;
      this.cartDatas=this.cartResponse.data;
    },err=>{
      console.log(err);
    });
  }



  compareFn(c1:any ,c2:any):boolean{
    return c1 && c2 ? c1.id === c2.id :c1 === c2;
  }

  compareFn1(c1:any ,c2:any):boolean{
    return c1 && c2 ? c1.id === c2.id :c1 === c2;
  }

  getState() {
    this.service.getStateList().subscribe(res=>{
      console.log(res);
      this.showstateresponse=res as showstateresponse;
      this.stateList=this.showstateresponse.data;
    },err=>{
      console.log(err);
    });
  }

  getCity(stateId:number) {
    this.service.getCitydata(stateId).subscribe(res=>{
      console.log(res);
      this.showcityresponse=res as showcityresponse;
      this.cityList=this.showcityresponse.data;
    },err=>{
      console.log(err);
    });
  }



  onSubmit(form:NgForm){
    console.log("USER ID:"+this.user_id_pk);
    if(this.user_id_pk==0||this.user_id_pk==undefined){
      this.service.getCartList(this.userData.user_id_pk).subscribe(res=>{
        console.log(res);
        this.userResponce=res as getuserresponse;

        if(this.userResponce.result=== "success" ){
          this.userData=this.userResponce.data;
          console.log("already use this email");
          // sessionStorage.setItem('user_id',this.userData.user_id_pk.toString());
          // console.log('cartdata in userid'+this.userData.user_id_pk);
        }
        else{
         // this.insertcart(this.userData.user_id_pk);
          this.insertDetails(form);
        }
        });


    }else{
      this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    //this.userData.user_id_pk=UserId;

    const formData = new FormData();
    formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
    formData.append('state_id_fk',this.userData.state_id_fk.toString())
    formData.append('city_id_fk',this.userData.city_id_fk.toString())
    formData.append('f_name',this.userData.f_name)
    formData.append('l_name',this.userData.l_name)
    formData.append('gender',this.userData.gender)
    formData.append('birthdate',this.userData.birthdate)
    formData.append('status',this.userData.status)
    formData.append('anniversary_date',this.userData.anniversary_date)
    formData.append('address',this.userData.address)
    formData.append('pincode',this.userData.pincode)
    formData.append('email',this.userData.email)
    formData.append('password',this.userData.password)
    formData.append('contact',this.userData.contact)
    formData.append('u_type',"Client")


    this.service.InsertUser(formData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/client'],{relativeTo:this.route})
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

   updateDetails(form:NgForm){
    const formData = new FormData();
    if(this.filesToUpload != null || this.filesToUpload != undefined){
      formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
    }else{
      formData.append('profile',this.userData.profile)
    }

    formData.append('user_id_pk',this.userData.user_id_pk.toString())
    formData.append('state_id_fk',this.userData.state_id_fk.toString())
    formData.append('city_id_fk',this.userData.city_id_fk.toString())
    formData.append('f_name',this.userData.f_name)
    formData.append('l_name',this.userData.l_name)
    formData.append('f_name',this.userData.f_name)
    formData.append('gender',this.userData.gender)
    formData.append('birthdate',this.userData.birthdate)
    formData.append('status',this.userData.status)
    formData.append('anniversary_date',this.userData.anniversary_date)
    formData.append('address',this.userData.address)
    formData.append('email',this.userData.email)
    formData.append('password',this.userData.password)
    formData.append('contact',this.userData.contact)
    formData.append('user_type',this.userData.u_type)

    this.service.UpdateUser(formData).subscribe(res=>{
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){

        this.resetForm(form);
        this.router.navigate(['/client/myaccount'],{relativeTo:this.route})
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  OnChange(stateID:any){
    console.log(stateID.target.value);
    this.getCity(stateID.target.value);
  }
  resetForm(form:NgForm){
    form.form.reset();
    this.userData=new userdata();
  }

  insertcart(form:NgForm){
    this.cartDatas.user_id_fk = Number(
      sessionStorage.getItem('user_id')?.toString()
    );

    this.service.InsertCart(this.cartDatas).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        //this.router.navigate(['/client'],{relativeTo:this.route})
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }
}
