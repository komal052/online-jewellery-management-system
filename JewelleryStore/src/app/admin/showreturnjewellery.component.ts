import { showreturnjewelleryresponse } from './../model/showreturnjewelleryresponse';
import { returnjewellerydata } from './../model/returnjewellerydata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';

@Component({
  selector: 'app-showreturnjewellery',
  templateUrl: './showreturnjewellery.component.html',
  styles: [
  ]
})
export class ShowreturnjewelleryComponent implements OnInit {

  returnjewellerydata: returnjewellerydata[] | undefined;
  showreturnjewelleryresponse:showreturnjewelleryresponse | undefined;
  insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showreturnjewelleryList();
  }
  showreturnjewelleryList()
  {
    this.service.getReturnJewelleryList().subscribe(res=>{
    console.log(res);
      this.showreturnjewelleryresponse= res as showreturnjewelleryresponse;
      this.returnjewellerydata=this.showreturnjewelleryresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletereturnjewellery(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteReturnJewellery(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showreturnjewelleryList();
      },err=>{
        console.log(err);
      });
    }
  }
   
}
