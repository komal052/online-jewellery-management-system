import { NgForm } from '@angular/forms';
import { certidata } from './../model/certidata';
import { getcertiresponse } from './../model/getcertificateresponse';
import { getgoldresponse } from './../model/getgoldresponse';
import { golddata } from './../model/golddata';
import { insertresponse } from './../model/insertresponse';
import { Component, OnInit } from '@angular/core';

import { Utils } from '../services/utils.service';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { restapi } from '../services/RestApiService';
import { showcertiresponse } from './../model/showcertidata';

@Component({
  selector: 'app-addgold',
  templateUrl: './addgold.component.html',
  styles: [
  ]
})
export class AddgoldComponent implements OnInit {

  goldResponce! : getgoldresponse;
  certiResponce!:getcertiresponse;
  certiData!:certidata[];
  insertResponce!:insertresponse;
  goldData : golddata={
    gold_id_pk : 0,
    gold_type :'',
    carat: '',
    weight : '',
    certi_id_fk :  0,
    is_active : 1,
    certi_no : ''
  };

  gold_id_pk = 0;
  showcertiresponse: any;

  constructor(private utils:Utils,
    public service : restapi, private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

   ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.gold_id_pk=params['id'];
    });
    this.getCerti();
    if(this.gold_id_pk==0 || this.gold_id_pk == undefined){
      this.goldData=new golddata();
    }else{
      console.log();
      this.getGoldData();
    }
  }
  getGoldData() {
    console.log("GOLD ID:"+this.gold_id_pk);
    this.service.getGolddata(this.gold_id_pk).subscribe(res=>{
      console.log(res);
      this.goldResponce=res as getgoldresponse;
      this.goldData=this.goldResponce.data;
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
    console.log("GOLD ID:"+this.gold_id_pk);
    if(this.gold_id_pk==0||this.gold_id_pk==undefined){
      this.insertDetails(form);
    }else{
      this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    this.service.InsertGold(this.goldData).subscribe(res=>{
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showgold'],{relativeTo:this.route})
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

   updateDetails(form:NgForm){
    this.service.UpdateGold(this.goldData).subscribe(res=>{
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showgold'],{relativeTo:this.route})
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.goldData=new golddata();
  }
}
