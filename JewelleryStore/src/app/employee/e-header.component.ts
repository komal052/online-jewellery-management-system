import { ordercount } from './../model/ordercount';
import { contactuscount } from './../model/contactuscount';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { contactusdata } from '../model/contactusdata';
import { getuserresponse } from '../model/getuserresponse';
import { orderdata } from '../model/orderdata';
import { showcontactusresponse } from '../model/showcontactusresponse';
import { showorderresponse } from '../model/showorderresponse';
import { userdata } from '../model/userdata';
import { restapi } from '../services/RestApiService';
import { showorderproductresponse } from '../model/showorderproductresponse';
import { orderproductdata } from '../model/orderproductdata';

@Component({
  selector: 'app-e-header',
  templateUrl: './e-header.component.html',
  styles: [
  ]
})
export class EHeaderComponent implements OnInit {

  userResponce! :getuserresponse   ;

  contactusdata: contactusdata[] | undefined;
  showcontactusresponse:showcontactusresponse | undefined;

  orderdata: orderdata[] | undefined;
  showorderresponse:showorderresponse | undefined;

  contactuscount!:contactuscount;
  ordercount!:ordercount;

  orderproductdata:orderproductdata[] | undefined;
  showorderproductresponse:showorderproductresponse| undefined;

  data1=0;
  data2=0;

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
  constructor(public service : restapi, private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.user_id_pk = Number(sessionStorage.getItem("user_id")?.toString());
    this.getUserData();

    this.showcontactusList();
    this.showorderList();
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

  showcontactusList()
  {
    this.service.getContactusList().subscribe(res=>{
    console.log(res);
      this.showcontactusresponse= res as showcontactusresponse;
      this.contactusdata=this.showcontactusresponse.data;
    },err=>{
      console.log(err);
    });

    this.service.ContactusListCount()
    .subscribe(res=>{
      this.contactuscount = res as  contactuscount;
      this.data1  =  this.contactuscount.data
      console.log(this.data1)
    },err=>{
      console.log(err);
    })
  }

  showorderList()
  {
    this.service.ProductOrderLastList().subscribe(res=>{
    console.log(res);
      this.showorderproductresponse= res as showorderproductresponse;
      this.orderproductdata=this.showorderproductresponse.data;
    },err=>{
      console.log(err);
    });

    //ordercount
    this.service.ProductOrderListCount()
    .subscribe(res=>{
      this.ordercount = res as  ordercount;
      this.data2  =  this.ordercount.data
      console.log(this.data2)
    },err=>{
      console.log(err);
    })
 }

  logout(){
    sessionStorage.setItem('isLoggedIn',"false");
    sessionStorage.setItem('user_id',"0");
    sessionStorage.setItem('user_type',"0");
    sessionStorage.clear();
    this.router.navigate(['/'],{relativeTo:this.route});
  }

}
