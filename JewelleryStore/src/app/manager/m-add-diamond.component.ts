
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { showcertiresponse } from './../model/showcertidata';
import { insertresponse } from './../model/insertresponse';
import { getdiamondresponse } from './../model/getdiamondresponse';
import { certidata } from './../model/certidata';
import { getcertiresponse } from './../model/getcertificateresponse';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { diamonddata } from '../model/diamonddata';

import { mrestapi } from '../services/RestApiServiceManager';


@Component({
  selector: 'app-m-add-diamond',
  templateUrl: './m-add-diamond.component.html',
  styles: [],
  encapsulation : ViewEncapsulation.None,
})
export class MAddDiamondComponent implements OnInit {

  certiResponce!:getcertiresponse;
  certiData!:certidata[];
  diamondResponce!:getdiamondresponse;
  insertResponce!:insertresponse;
  diamondData:diamonddata={
  diamond_id_pk : 0,
  diamond_color:  "",
  diamond_cut: "",
  polish: "",
  clarity: "",
  certi_id_fk : 0,
  shape:  "",
  stone_weight : "",
  selling_cost : "",
  buying_cost :"",
  certi_no :"",
  image:"",
  is_active : 1,
  };
  diamond_id_pk=0;
  showcertiresponce: showcertiresponse | undefined;
  constructor(private utils:Utils,public service:mrestapi,private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.diamond_id_pk=params['id'];
    });
    this.getCerti();
    if(this.diamond_id_pk==0 || this.diamond_id_pk == undefined){
      this.diamondData=new diamonddata();
    }else{
      console.log();
      this.getDiamondData();
    }
  }
  getDiamondData() {
    console.log("DIAMOND ID:"+this.diamond_id_pk);
    this.service.getDiamondData(this.diamond_id_pk).subscribe(res=>{
      console.log(res);
      this.diamondResponce=res as getdiamondresponse;
      this.diamondData=this.diamondResponce.data;
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
      this.showcertiresponce=res as showcertiresponse;
      this.certiData=this.showcertiresponce.data;
    },err=>{
      console.log(err);
    });
  }

  onSubmit(form:NgForm){
    console.log("DIAMONd ID:"+this.diamond_id_pk);
    if(this.diamond_id_pk==0||this.diamond_id_pk==undefined){
      this.insertDetails(form);
    }else{
      this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    this.service.InsertDiamond(this.diamondData).subscribe(res=>{
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/manager/m_show_diamond']).then(() => {
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
    this.service.UpdateDiamond(this.diamondData).subscribe(res=>{
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/manager/m_show_diamond']).then(() => {
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
    this.diamondData=new diamonddata();
  }

}
