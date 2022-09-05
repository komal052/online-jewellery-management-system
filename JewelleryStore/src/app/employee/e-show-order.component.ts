import { showorderproductresponse } from './../model/showorderproductresponse';

import { showorderresponse } from './../model/showorderresponse';
import { orderdata } from './../model/orderdata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { erestapi } from '../services/RestApiServiceEmployee';
import { orderproductdata } from '../model/orderproductdata';
import { ordercount } from '../model/ordercount';

@Component({
  selector: 'app-e-show-order',
  templateUrl: './e-show-order.component.html',
  styles: [
  ]
})
export class EShowOrderComponent implements OnInit {
  //orderdata: orderdata[] | undefined;
  orderproductdata: orderproductdata[] |undefined;
 showorderresponse:showorderresponse | undefined;
  
 showorderproductresponse:showorderproductresponse| undefined;
 
 insertresponse:insertresponse | undefined;

 orderproductdata1:orderproductdata=
 {
   order_product_id_pk: 0,
   order_id_fk: 0,
   total_amount: "",
   subjewellery_id_fk: 0,
   quantity: "",
   status: 0,
   jewellery_name: '',
   images: '',
   date: '',
   is_read: 0
 }

 ordercount!:ordercount;
 data11=0;

 //btnval=this.orderdata1.status;

 


 baseUrl=''



 constructor(private utils:Utils,public service:erestapi) {
   new Promise((resolve)=>{
     utils.loadTablesScript();
     resolve(true);
   });
  }

 ngOnInit(): void {
  this.service.ProductOrderLimit()
  .subscribe(res=>{
    this.ordercount = res as  ordercount;
    this.data11  =  this.ordercount.data
    console.log(this.data11)
  },err=>{
    console.log(err);
  })
  

   this.baseUrl=this.utils.baseUrl
   this.showorderList();
  
 }
 showorderList()
 {
   this.service.ProductOrderList().subscribe(res=>{
   console.log(res);
     this.showorderproductresponse= res as showorderproductresponse;
     this.orderproductdata=this.showorderproductresponse.data;
   },err=>{
     console.log(err);
   });
 }
 
//  deleteorder(id:number)
//  {
//    if(confirm('are u sure to delete this record'))
//    {
//      this.service.DeleteOrder(id).subscribe(res=>{
//        console.log(res);
//        this.insertresponse= res as insertresponse;
//        this.showorderList();
//      },err=>{
//        console.log(err);
//      });
//    }
//  }

onStatus(id:number){
  this.service.OrderStatus(id)
  .subscribe(res=>{
    this.ordercount= res as  ordercount;
   
    this.data11  =  this.ordercount.data
     
    console.log(this.data11)
    window.location.reload();
   
  },err=>{
    console.log(err);
  })
 
}
}
