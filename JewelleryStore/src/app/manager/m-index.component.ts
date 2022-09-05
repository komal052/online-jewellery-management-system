import { suppliercount } from './../model/suppliercount';
import { usercount } from './../model/usercount';
import { subjewellerycount } from './../model/subjewellerycount';
import { jewellerycount } from './../model/jewellerycount';
import { silvercount } from './../model/silver';
import { goldcount } from './../model/goldcount';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { mrestapi } from '../services/RestApiServiceManager';
import { diamondcount } from '../model/diamondcount';
import { certicount } from '../model/certicount';

@Component({
  selector: 'app-m-index',
  templateUrl: './m-index.component.html',
  styles: [
  ]
})
export class MIndexComponent implements OnInit {
  goldcount : goldcount| undefined;
    diamondcount : diamondcount | undefined;
   silvercount : silvercount | undefined;
   certicount : certicount | undefined;
   
   jewellerycount!:jewellerycount;
   subjewellerycount!:subjewellerycount;
   usercount!:usercount;
   suppliercount!:suppliercount;


    data1=0;
    data2=0;
    data3=0;
    data4=0;
    data5=0;
    data6=0;
    data7=0;
    data8=0;


  constructor(private service:mrestapi,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void 
  {
    this.service.goldListCount()
    .subscribe(res=>{
      this.goldcount = res as  goldcount;
      this.data1  =  this.goldcount.data
      console.log(this.data1)
    },err=>{
      console.log(err);
    })

    this.service.silverListCount()
    .subscribe(res=>{
      this.silvercount = res as  silvercount;
     this.data2  =  this.silvercount.data
      console.log(this.data2)
    },err=>{
      console.log(err);
    })


    this.service.certiListCount()
    .subscribe(res=>{
      this.certicount = res as  certicount;
      this.data3  =  this.certicount.data
      console.log(this.data3)
    },err=>{
      console.log(err);
    })

    this.service.diamondListCount()
    .subscribe(res=>{
      this.diamondcount = res as  diamondcount;
      this.data4  =  this.diamondcount.data
      console.log(this.data4)
    },err=>{
      console.log(err);
    })

    this.service.JewelleryListCount()
    .subscribe(res=>{
      this.jewellerycount = res as  jewellerycount;
      this.data5  =  this.jewellerycount.data
      console.log(this.data5)
    },err=>{
      console.log(err);
    })
    this.service.SubJewelleryListCount()
    .subscribe(res=>{
      this.subjewellerycount = res as  subjewellerycount;
      this.data6  =  this.subjewellerycount.data
      console.log(this.data6)
    },err=>{
      console.log(err);
    })

    this.service.UserListCount()
    .subscribe(res=>{
      this.usercount = res as usercount;
      this.data7  =  this.usercount.data
      console.log(this.data7)
    },err=>{
      console.log(err);
    })
    this.service.SupplierListCount()
    .subscribe(res=>{
      this.suppliercount= res as suppliercount;
      this.data8  =  this.suppliercount.data
      console.log(this.data8)
    },err=>{
      console.log(err);
    })


  }
  
}