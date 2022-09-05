import { contactusdata } from './../model/contactusdata';
import { getcontactusresponse } from './../model/getcontactusresponse';
import { Component, OnInit } from '@angular/core';
import { insertresponse } from '../model/insertresponse';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-contactus',
  templateUrl: './contactus.component.html',
  styles: [
  ]
})
export class ContactusComponent implements OnInit {
  contactResponce!:getcontactusresponse;
  insertResponce!:insertresponse;
  contactData:contactusdata={
  contactus_id_pk: 0,
  name: "",
  email_id: "",
  subject: "",
  message: "",
  is_active: 0
  };
  contact_id=0;

  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }


  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.contact_id=params['id'];
    });
    if(this.contact_id==0 || this.contact_id == undefined){
      this.contactData=new contactusdata();
    }else{
      console.log();
      this.getContactData();
    }
  }

  getContactData(){
    this.service.getContactusdata(this.contact_id).subscribe(res=>{
      console.log(res);
      this.contactResponce=res as getcontactusresponse;
      this.contactData=this.contactResponce.data;
    },err=>{
      console.log(err);
    });
  }

  onSubmit(form:NgForm){
    console.log("Contact ID:"+this.contact_id);
    if(this.contact_id==0||this.contact_id==undefined){
      this.insertDetails(form);
    }else{
      console.log("error in insert");
      //this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    this.service.InsertContact(this.contactData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        //this.router.navigate(['/client/contactus'],{relativeTo:this.route})
        alert("your message sent successfully");
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.contactData=new contactusdata();
  }
}
