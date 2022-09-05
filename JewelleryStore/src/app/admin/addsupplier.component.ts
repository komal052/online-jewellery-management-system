import { supplierdata } from './../model/supplierdata';
import { insertresponse } from './../model/insertresponse';
import { getsupplierresponse } from './../model/getsupplierresponse';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-addsupplier',
  templateUrl: './addsupplier.component.html',
  styles: [],
  encapsulation : ViewEncapsulation.None,
})
export class AddsupplierComponent implements OnInit {
  getsupplierresponse!:getsupplierresponse;
  insertresponse!:insertresponse;

  supplierdata: supplierdata={
    sup_id_pk: 0,
    sup_name: '',
    factory_name: '',
    factory_contact: '',
    sup_contact: '',
    is_active: 1
  }
  sup_id_pk=0;



  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router ) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.sup_id_pk=params['id'];
    });

    if(this.sup_id_pk==0|| this.sup_id_pk==undefined){
      this.supplierdata=new supplierdata();
    }else{
      console.log();
      this.getsupplier();
    }
  }
  getsupplier()
  {
    console.log("sup_id_pk:" +this.sup_id_pk);
    this.service.getSupplierData(this.sup_id_pk).subscribe(res=>{
    this.getsupplierresponse=res as getsupplierresponse;
    this.supplierdata=this.getsupplierresponse.data;
    },err=>{
      console.log(err);
    })
  }

  onsubmit(form:NgForm)
  {
    console.log("sup_id_pk:"+this.sup_id_pk);
    if(this.sup_id_pk==0 || this.sup_id_pk==undefined)
    {
      this.insertdetails(form);

    }else{
      this.updatedetails(form);
    }
  }
  insertdetails(form:NgForm)
  {
     this.service.InsertSupplier(this.supplierdata).subscribe(res=>{
      console.log(res);
       this.insertresponse=res as insertresponse;

       if(this.insertresponse.result==="success")
       {
        this.resetForm(form);
          this.router.navigate(['/admin/showsupplier']).then(() => {
            window.location.reload();
          });
       }else{
         console.log(res);
       }
     },err=>{
       console.log(err);
     });
  }
  updatedetails(form:NgForm)
  {
     this.service.UpdateSupplier(this.supplierdata).subscribe(res=>{
       this.insertresponse=res as insertresponse;

       if(this.insertresponse.result==="success")
       {
         this.resetForm(form);
          this.router.navigate(['/admin/showsupplier']).then(() => {
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
    this.supplierdata=new supplierdata();
  }

}
