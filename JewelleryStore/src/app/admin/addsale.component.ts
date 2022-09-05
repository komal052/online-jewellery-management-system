import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { showjewelleryresponse } from './../model/showjewelleryresponse';
import { saledata } from './../model/saledata';
import { insertresponse } from './../model/insertresponse';
import { jewellerydata } from './../model/jewellerydata';
import { getjewelleryresponse } from './../model/getjewelleryresponse';
import { getsaleresponse } from './../model/getsaleresponse';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';

@Component({
  selector: 'app-addsale',
  templateUrl: './addsale.component.html',
  styles: [],
  encapsulation : ViewEncapsulation.None,
})
export class AddsaleComponent implements OnInit {

  saleResponce! : getsaleresponse;
  jewelleryResponce!:getjewelleryresponse;
  jewelleryData!:jewellerydata[];
  insertResponce!:insertresponse;
  saleData : saledata={
    sale_id_pk : 0,
    sale_date : '',
    qty: 0,
    price: '',
    jewellery_id_fk :  0,
    is_active : 1,
    jewellery_name : ''
  };
  sale_id_pk = 0;
  showjewelleryresponse: any;
  constructor(private utils:Utils,public service : restapi, private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

   ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.sale_id_pk=params['id'];
    });
    this.getJewellery();
    if(this.sale_id_pk==0 || this.sale_id_pk == undefined){
      this.saleData=new saledata();
    }else{
      console.log();
      this.getSaleData();
    }
  }
  getSaleData() {
    console.log("SALE ID:"+this.sale_id_pk);
    this.service.getSaleData(this.sale_id_pk).subscribe(res=>{
      console.log(res);
      this.saleResponce=res as getsaleresponse;
      this.saleData=this.saleResponce.data;
    },err=>{
      console.log(err);
    });
  }
  
  compareFn(c1:any ,c2:any):boolean{
    return c1 && c2 ? c1.id === c2.id :c1 === c2;
  }

  getJewellery() {
    this.service.getJewelleryList().subscribe(res=>{
      console.log(res);
      this.showjewelleryresponse=res as showjewelleryresponse;
      this.jewelleryData=this.showjewelleryresponse.data;
    },err=>{
      console.log(err);
    });
  }

  onSubmit(form:NgForm){
    console.log("Sale ID:"+this.sale_id_pk);
    if(this.sale_id_pk==0||this.sale_id_pk==undefined){
      this.insertDetails(form);
    }else{
      this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    this.service.InsertSale(this.saleData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showsale']).then(() => {
          window.location.reload();
        });
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

   updateDetails(form:NgForm){
    this.service.UpdateSale(this.saleData).subscribe(res=>{
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showsale']).then(() => {
          window.location.reload();
        });
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.saleData=new saledata();
  }

}
