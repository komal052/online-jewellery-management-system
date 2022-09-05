import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { billcount } from '../model/billcount';
import { employeecount } from '../model/employeecount';
import { jewellerycount } from '../model/jewellerycount';
import { ordercount } from '../model/ordercount';
import { paymentcount } from '../model/paymentcount';
import { returnjewellerycount } from '../model/returnjewellerycount';
import { subjewellerycount } from '../model/subjewellerycount';
import { usercount } from '../model/usercount';
import { erestapi } from '../services/RestApiServiceEmployee';




@Component({
  selector: 'app-e-index',
  templateUrl: './e-index.component.html',
  styles: [
  ]
})
export class EIndexComponent implements OnInit {
  jewellerycount!:jewellerycount;
  subjewellerycount!:subjewellerycount;
  employeecount!:employeecount;
  billcount!:billcount;
  ordercount!:ordercount;
  paymentcount!:paymentcount;
  usercount!:usercount;
  returnjewellerycount!:returnjewellerycount;

  data1=0;
  data2=0;
  data3=0;
  data4=0;
  data5=0;
  data6=0;
  data7=0;
  data8=0;

  

  constructor(private service:erestapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.service.JewelleryListCount()
    .subscribe(res=>{
      this.jewellerycount = res as  jewellerycount;
      this.data1  =  this.jewellerycount.data
      console.log(this.data1)
    },err=>{
      console.log(err);
    })

    this.service.SubtypeJewelleryListCount()
    .subscribe(res=>{
      this.subjewellerycount = res as  subjewellerycount;
      this.data2  =  this.subjewellerycount.data
      console.log(this.data2)
    },err=>{
      console.log(err);
    })
    
    this.service.EmployeeListCount()
    .subscribe(res=>{
      this.employeecount = res as  employeecount;
      this.data3  =  this.employeecount.data
      console.log(this.data3)
    },err=>{
      console.log(err);
    })

    this.service.PaymentListCount()
    .subscribe(res=>{
      this.paymentcount = res as  paymentcount;
      this.data4  =  this.paymentcount.data
      console.log(this.data4)
    },err=>{
      console.log(err);
    })

    this.service.UserListCount()
    .subscribe(res=>{
      this.usercount = res as usercount;
      this.data5  =  this.usercount.data
      console.log(this.data5)
    },err=>{
      console.log(err);
    })

    this.service.ProductOrderListCount()
    .subscribe(res=>{
      this.ordercount = res as ordercount;
      this.data6  =  this.ordercount.data
      console.log(this.data6)
    },err=>{
      console.log(err);
    })


    this.service.ReturnJewelleryListCount()
    .subscribe(res=>{
      this.returnjewellerycount = res as returnjewellerycount;
      this.data7  =  this.returnjewellerycount.data
      console.log(this.data7)
    },err=>{
      console.log(err);
    })

    this.service.BillListCount()
    .subscribe(res=>{
      this.billcount = res as billcount;
      this.data8  =  this.billcount.data
      console.log(this.data8)
    },err=>{
      console.log(err);
    })

  }

}
