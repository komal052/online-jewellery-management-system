import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { discountdata } from '../model/discountdata';
import { getdiscountresponse } from '../model/getdiscountresponse';
import { getjewelleryresponse } from '../model/getjewelleryresponse';
import { insertresponse } from '../model/insertresponse';
import { jewellerydata } from '../model/jewellerydata';
import { showjewelleryresponse } from '../model/showjewelleryresponse';
import { erestapi } from '../services/RestApiServiceEmployee';
import { Utils } from '../services/utils.service';

@Component({
  selector: 'app-e-add-discount',
  templateUrl: './e-add-discount.component.html',
  styles: [],
  encapsulation : ViewEncapsulation.None,
})
export class EAddDiscountComponent implements OnInit {

  discountResponce! :getdiscountresponse ;
  jewelleryResponce!:getjewelleryresponse;
  jewelleryData!:jewellerydata[];
  insertResponce!:insertresponse;
  discountData : discountdata={
  discount_id_pk: 0,
  discount : "",
  jewellery_id_fk : 0,
  jewellery_name :"",
  is_active : 0
  };
  discount_id_pk = 0;
  showjewelleryresponse: any;
  constructor(private utils:Utils,public service : erestapi, private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

   ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.discount_id_pk=params['id'];
    });
    this.getJewellery();
    if(this.discount_id_pk==0 || this.discount_id_pk == undefined){
      this.discountData=new discountdata();
    }else{
      console.log();
      this.getDiscountData();
    }
  }
  getDiscountData() {
    console.log("DISCOUNT ID:"+this.discount_id_pk);
    this.service.getDiscountData(this.discount_id_pk).subscribe(res=>{
      console.log(res);
      this.discountResponce=res as getdiscountresponse;
      this.discountData=this.discountResponce.data;
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
    console.log("DISCOUNT ID:"+this.discount_id_pk);
    if(this.discount_id_pk==0||this.discount_id_pk==undefined){
      this.insertDetails(form);
    }else{
      this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    this.service.InsertDiscount(this.discountData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/employee/e_show_discount']).then(() => {
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
    this.service.UpdateDiscount(this.discountData).subscribe(res=>{
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/employee/e_show_discount']).then(() => {
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
    this.discountData=new discountdata();
  }

}
