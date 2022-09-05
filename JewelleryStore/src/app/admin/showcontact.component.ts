import { showcontactusresponse } from './../model/showcontactusresponse';
import { contactusdata } from './../model/contactusdata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { contactuscount } from '../model/contactuscount';

@Component({
  selector: 'app-showcontact',
  templateUrl: './showcontact.component.html',
  styles: [
  ]
})
export class ShowcontactComponent implements OnInit {
  contactusdata: contactusdata[] | undefined;
  showcontactusresponse:showcontactusresponse | undefined;
  insertresponse:insertresponse | undefined;
 
  contactuscount!: contactuscount;
  data11=0;
  
  

  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
   
    this.service.ContactusLimit()
    .subscribe(res=>{
      this.contactuscount = res as  contactuscount;
      this.data11  =  this.contactuscount.data
      console.log(this.data11)
    },err=>{
      console.log(err);
    })
    
    this.showcontactusList();
  }

  showcontactusList()
  {
    this.service.getContactusList().subscribe(res=>{
    console.log(res);
      this.showcontactusresponse= res as showcontactusresponse;
      this.contactusdata=this.showcontactusresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletecontactus(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteContactus(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showcontactusList();
      },err=>{
        console.log(err);
      });
    }
  }
}
