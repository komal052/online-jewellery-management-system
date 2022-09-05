import { insertresponse } from './../model/insertresponse';
import { showsubjewelleryresponse } from './../model/showsubjewelleryresponse';

import { subjewelleryData } from './../model/subjewellerydata';

import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { restapi } from '../services/RestApiService';
import { erestapi } from '../services/RestApiServiceEmployee';

@Component({
  selector: 'app-e-show-subtypejewellery',
  templateUrl: './e-show-subtypejewellery.component.html',
  styles: [
  ]
})
export class EShowSubtypejewelleryComponent implements OnInit {

  subjewellryData: subjewelleryData[] | undefined;
  showsubjewelleryresponse:showsubjewelleryresponse | undefined;
  insertresponse:insertresponse | undefined;

  baseUrl =''  
 
 constructor(private utils:Utils, public service:erestapi) {
   new Promise((resolve)=>{
     utils.loadTablesScript();
     resolve(true);
   });
  }

 ngOnInit(): void {
  this.baseUrl=this.utils.baseUrl
   this.showsubjewelleryList();
 }
 
 showsubjewelleryList()
 {
   this.service.getSubJewelleryList().subscribe(res=>{
   console.log(res);
     this.showsubjewelleryresponse= res as showsubjewelleryresponse;
     this.subjewellryData=this.showsubjewelleryresponse.data;
   },err=>{
     console.log(err);
   });
 }
 
 deletesubjewellery(id:number)
 {
   if(confirm('are u sure to delete this record'))
   {
     this.service.DeleteSubJewellery(id).subscribe(res=>{
       console.log(res);
       this.insertresponse= res as insertresponse;
       this.showsubjewelleryList();
     },err=>{
       console.log(err);
     });
   }
 }

}
