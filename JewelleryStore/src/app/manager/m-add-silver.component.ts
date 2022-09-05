import { NgForm } from '@angular/forms';
import { showcertiresponse } from './../model/showcertidata';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { silverdata } from './../model/silverdata';
import { insertresponse } from './../model/insertresponse';
import { certidata } from './../model/certidata';
import { getcertiresponse } from './../model/getcertificateresponse';
import { getsilverresponse } from './../model/getsilverResponse';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';
import { mrestapi } from '../services/RestApiServiceManager';

@Component({
  selector: 'app-m-add-silver',
  templateUrl: './m-add-silver.component.html',
  styles: [
  ]
})
export class MAddSilverComponent implements OnInit {

  silverResponce! : getsilverresponse;
  certiResponce!:getcertiresponse;
  certiData!:certidata[];
  insertResponce!:insertresponse;
  silverData : silverdata={
    silver_id_pk : 0,
    weight : '',
    carat: '',
    certi_id_fk :  0,
    is_active : 1,
    certi_no : ''
  };
  silver_id_pk = 0;
  showcertiresponse: any;
  constructor(private utils:Utils,public service : mrestapi, private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

   ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.silver_id_pk=params['id'];
    });
    this.getCerti();
    if(this.silver_id_pk==0 || this.silver_id_pk == undefined){
      this.silverData=new silverdata();
    }else{
      console.log();
      this.getSilverData();
    }
  }
  getSilverData() {
    console.log("SILVER ID:"+this.silver_id_pk);
    this.service.getSilverData(this.silver_id_pk).subscribe(res=>{
      console.log(res);
      this.silverResponce=res as getsilverresponse;
      this.silverData=this.silverResponce.data;
    },err=>{
      console.log(err);
    });
  }
  
  compareFn(c1:any ,c2:any):boolean{
    return c1 && c2 ? c1.id === c2.id :c1 === c2;
  }

  getCerti() {
    this.service.getCertiList().subscribe(res=>{
      console.log(res);
      this.showcertiresponse=res as showcertiresponse;
      this.certiData=this.showcertiresponse.data;
    },err=>{
      console.log(err);
    });
  }

  onSubmit(form:NgForm){
    console.log("SILVER ID:"+this.silver_id_pk);
    if(this.silver_id_pk==0||this.silver_id_pk==undefined){
      this.insertDetails(form);
    }else{
      this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    this.service.InsertSilver(this.silverData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/manager/m_show_silver']).then(() => {
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
    this.service.UpdateSilver(this.silverData).subscribe(res=>{
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/manager/m_show_silver']).then(() => {
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
    this.silverData=new silverdata();
  }

}
