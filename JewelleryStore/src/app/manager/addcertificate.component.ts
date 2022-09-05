import { certidata } from './../model/certidata';
import { insertresponse } from './../model/insertresponse';
import { getcertiresponse } from './../model/getcertificateresponse';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-addcertificate',
  templateUrl: './addcertificate.component.html',
  styles: [],
  encapsulation : ViewEncapsulation.None,
})
export class AddcertificateComponent implements OnInit {
    certiResponce!:getcertiresponse;
    insertResponce!:insertresponse;
    certiData:certidata={
      certi_id_pk: 0,
      certi_no: 0,
      image: '',
      is_active: 0
    }
    certi_id=0;

  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.certi_id=params['id'];
    });
    if(this.certi_id==0 || this.certi_id == undefined){
      this.certiData=new certidata();
    }else{
      console.log();
      this.getCertiData();
    }
  }

  getCertiData(){
    this.service.getCertidata(this.certi_id).subscribe(res=>{
      console.log(res);
      this.certiResponce=res as getcertiresponse;
      this.certiData=this.certiResponce.data;
    },err=>{
      console.log(err);
    });
  }

  onSubmit(form:NgForm){
    console.log("Certi ID:"+this.certi_id);
    if(this.certi_id==0||this.certi_id==undefined){
      this.insertDetails(form);
    }else{
      this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    this.service.InsertCerti(this.certiData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showcertificate'],{relativeTo:this.route})
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

   updateDetails(form:NgForm){
    this.service.UpdateCerti(this.certiData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showcertificate'],{relativeTo:this.route})
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.certiData=new certidata();
  }

}
