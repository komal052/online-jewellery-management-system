import { showorderproductresponse } from './../model/showorderproductresponse';
import { orderproductdata } from './../model/orderproductdata';

import { showorderresponse } from './../model/showorderresponse';

import { showuserresponse } from './../model/showuserresponse';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { citydata } from '../model/citydata';
import { getuserresponse } from '../model/getuserresponse';
import { insertresponse } from '../model/insertresponse';
import { showcityresponse } from '../model/showcityresponse';
import { showstateresponse } from '../model/showstateresponse';
import { statedata } from '../model/statedata';
import { userdata } from '../model/userdata';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { orderdata } from '../model/orderdata';
import { getorderresponse } from '../model/getorderresponse';


@Component({
  selector: 'app-user-account',
  templateUrl: './user-account.component.html',
  styles: [
  ]
})
export class UserAccountComponent implements OnInit {

  userResponce! :getuserresponse;
  stateList!:statedata[];
  cityList!:citydata[];
  insertResponce!:insertresponse;
  showusertresponse: showuserresponse|undefined;
  userdata:userdata[]|undefined;

  orderproductdata:orderproductdata[]|undefined;

  orderdata!:orderdata[];
  showorderresponse!:showorderresponse;
  getorderresponse!: getorderresponse;

  showorderproductresponse!:showorderproductresponse;

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
  OrderData: orderdata = {
    order_id_pk: 0,
    user_id_fk: 0,
    f_name: '',
    l_name: '',
    address: '',
    total_amount: '',
    date: '',
  };
  user_id_pk = 0;

  showstateresponse!: showstateresponse;
  showcityresponse!:showcityresponse;
  status:string="";
  inputDisabled:boolean=false;
  form: any;

  baseUrl = '';
  filesToUpload : FileList | undefined;
  user_id!: number;
  order_id!:number;

  isshow=false;

  constructor(private utils:Utils,public service : restapi, private route:ActivatedRoute,private router:Router) {

   }

   public uploadFile = (files: FileList | null) =>{
    if(files!.length === 0){
      return;
    }
    this.filesToUpload = files!
  }


   ngOnInit(): void {
    this.baseUrl=this.utils.baseUrl
    // this.route.params.subscribe((params: Params) => {
    //   this.userResponce=params['id'];
    //   this.userData.user_id_pk=params['id'];
    // });
    // this.getState();
    //this.getCity();
      //  this.getUserData();
       this.user_id = Number(sessionStorage.getItem("user_id")?.toString());
      console.log("ID ::::"+this.user_id);
      this.getUserData();
      this.showorder();






  }
  logout(){
    sessionStorage.clear();
    this.router.navigate(['/client'], {
      relativeTo: this.route,
    });
  }
  getUserData() {
    console.log("User ID:"+this.user_id);
    this.service.getUserdata(this.user_id).subscribe(res=>{
      console.log('uid'+this.user_id);
      this.userResponce=res as getuserresponse;

      if (this.userResponce.result === 'success') {
        this.user_id_pk=this.userData.user_id_pk;

        this.userData=this.userResponce.data;
      } else {
        console.log(res);
    }},err=>{
      console.log(err);
    });
  }



  // showuser(){
  //   this.service.getUserList().subscribe(res=>{
  //     console.log(res);
  //     this.showusertresponse=res as showuserresponse;
  //     this.userdata=this.showusertresponse.data;
  //   },err=>{
  //     console.log(err);
  //   });
  // }
  showorderproduct(id:number){
    this.isshow=true;
    console.log('op');
    this.service.getOrderProduct(id).subscribe(
      (res) => {
        console.log('opid:' + id);
        this.showorderproductresponse = res as showorderproductresponse;
        this.orderproductdata = this.showorderproductresponse.data;
      },
      (err) => {
        console.log(err);
      }
    );
  }
  showorder(){
    console.log('order');
    this.service.getOrderList(this.user_id).subscribe(
      (res) => {
        console.log('cart data:' + res);
        this.showorderresponse = res as showorderresponse;
        this.orderdata = this.showorderresponse.data;
      },
      (err) => {
        console.log(err);
      }
    );
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
        this.router.navigate(['/client'],{relativeTo:this.route})
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  // OnChange(stateID:any){
  //   console.log(stateID.target.value);
  //   this.getCity(stateID.target.value);
  // }
  resetForm(form:NgForm){
    form.form.reset();
    this.userData=new userdata();
  }

}
