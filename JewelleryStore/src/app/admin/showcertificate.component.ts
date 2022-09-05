import { showcertiresponse } from './../model/showcertidata';

import { certidata } from './../model/certidata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { restapi } from '../services/RestApiService';

@Component({
  selector: 'app-showcertificate',
  templateUrl: './showcertificate.component.html',
  styles: [
  ]
})
export class ShowcertificateComponent implements OnInit {

  certidata: certidata[] | undefined;
  showcertiresponse:showcertiresponse | undefined;
  insertresponse:insertresponse | undefined;

  baseUrl ='' 
  


  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.baseUrl=this.utils.baseUrl
    this.showcertiList();
  }
  showcertiList()
  {
    this.service.getCertiList().subscribe(res=>{
    console.log(res);
      this.showcertiresponse= res as showcertiresponse;
      this.certidata=this.showcertiresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletecerti(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteCerti(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showcertiList();
      },err=>{
        console.log(err);
      });
    }
  }

}
