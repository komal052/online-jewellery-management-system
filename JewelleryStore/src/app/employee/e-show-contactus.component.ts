import { showcontactusresponse } from './../model/showcontactusresponse';
import { contactusdata } from './../model/contactusdata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { erestapi } from '../services/RestApiServiceEmployee';

@Component({
  selector: 'app-e-show-contactus',
  templateUrl: './e-show-contactus.component.html',
  styles: [
  ]
})
export class EShowContactusComponent implements OnInit {

  contactusdata: contactusdata[] | undefined;
  showcontactusresponse:showcontactusresponse | undefined;
  insertresponse:insertresponse | undefined;
  

  constructor(private utils:Utils,public service:erestapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
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
        console.log(id);
        this.insertresponse= res as insertresponse;
        this.showcontactusList();
      },err=>{
        console.log(err);
      });
    }
  }

}
