import { suppliercount } from './../model/suppliercount';
import { supplierdata } from './../model/supplierdata';
import { diamondcount } from './../model/diamondcount';
import { goldcount } from './../model/goldcount';
import { returnjewellerycount } from './../model/returnjewellerycount';
import { usercount } from './../model/usercount';
import { paymentcount } from './../model/paymentcount';
import { ordercount } from './../model/ordercount';
import { billcount } from './../model/billcount';
import { employeecount } from './../model/employeecount';
import { subjewellerycount } from './../model/subjewellerycount';
import { jewellerycount } from './../model/jewellerycount';

import { Utils } from './../services/utils.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { restapi } from '../services/RestApiService';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  encapsulation : ViewEncapsulation.None,
})
export class IndexComponent implements OnInit {

  jewellerycount!:jewellerycount;
  subjewellerycount!:subjewellerycount;
  employeecount!:employeecount;
  billcount!:billcount;
  ordercount!:ordercount;
  paymentcount!:paymentcount;
  usercount!:usercount;
  returnjewellerycount!:returnjewellerycount;
  goldcount!:goldcount;
  diamondcount!:diamondcount;
  suppliercount!:suppliercount;

  data1=0;
  data2=0;
  data3=0;
  data4=0;
  data5=0;
  data6=0;
  data7=0;
  data8=0;
  data9=0;
  data10=0;
  data11=0;

  constructor(private utils:Utils,private service:restapi,private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadIndexScript();
      resolve(true);
    });
   }
   
  ngOnInit(): void {

    this.service.JewelleryListCount()
    .subscribe(res=>{
      this.jewellerycount = res as  jewellerycount;
      this.data1  =  this.jewellerycount.data
      console.log(this.data1)
    },err=>{
      console.log(err);
    })
    this.service.SubJewelleryListCount()
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

    this.service.goldListCount()
    .subscribe(res=>{
      this.goldcount = res as goldcount;
      this.data9  =  this.goldcount.data
      console.log(this.data9)
    },err=>{
      console.log(err);
    })

    this.service.diamondListCount()
    .subscribe(res=>{
      this.diamondcount= res as diamondcount;
      this.data10  =  this.diamondcount.data
      console.log(this.data10)
    },err=>{
      console.log(err);
    })

    this.service.SupplierListCount()
    .subscribe(res=>{
      this.suppliercount= res as suppliercount;
      this.data11  =  this.suppliercount.data
      console.log(this.data11)
    },err=>{
      console.log(err);
    })


    
  }

}
