import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { discountdata } from '../model/discountdata';
import { getdiscountresponse } from '../model/getdiscountresponse';
import { getjewelleryresponse } from '../model/getjewelleryresponse';
import { insertresponse } from '../model/insertresponse';
import { jewellerydata } from '../model/jewellerydata';
import { showjewelleryresponse } from '../model/showjewelleryresponse';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';

@Component({
  selector: 'app-adddiscount', 
  templateUrl: './adddiscount.component.html',
  styles: [],
  encapsulation : ViewEncapsulation.None,
})
export class AdddiscountComponent implements OnInit {
 
  discountResponse! :getdiscountresponse ;
  jewelleryResponse!:getjewelleryresponse;
  jewelleryData!:jewellerydata[];
  insertResponse!:insertresponse;
  showjewelleryresponse!:showjewelleryresponse;
  
  discountData : discountdata={
  discount_id_pk: 0,
  discount : "",
  jewellery_id_fk : 0,
  jewellery_name :"",
  is_active : 0
  };
  discount_id_pk = 0;
  
  constructor(private utils:Utils,public service : restapi, private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

   ngOnInit(): void {
    this.getJewellery();
    this.route.params.subscribe((params:Params)=>{
      this.discount_id_pk=params['id'];
    });
   
    if(this.discount_id_pk==0 || this.discount_id_pk == undefined){
      this.discountData=new discountdata();
    }else{
      console.log();
      this.getDiscountData();
    }
  }
  getDiscountData() {
    console.log("discount_id_pk:"+ this.discount_id_pk);
    this.service.getDiscountData(this.discount_id_pk).subscribe(res=>{
      // console.log(res);
      this.discountResponse=res as getdiscountresponse;
      this.discountData=this.discountResponse.data;
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
    console.log("discount_id_pk:"+this.discount_id_pk);
    if(this.discount_id_pk==0||this.discount_id_pk==undefined)
    {
      this.insertDetails(form);
    }else{
      this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    this.service.InsertDiscount(this.discountData).subscribe(res=>{
      console.log(res);
      this.insertResponse= res as insertresponse;
      if(this.insertResponse.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showdiscount']).then(() => {
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
      this.insertResponse= res as insertresponse;
      if(this.insertResponse.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showdiscount']).then(() => {
          window.location.reload();
        });
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  resetForm(form:NgForm)
  {
    form.form.reset();
    this.discountData=new discountdata();
  }
}
