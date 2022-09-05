import { showreturnjewelleryresponse } from './../model/showreturnjewelleryresponse';
import { returnjewellerydata } from './../model/returnjewellerydata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { erestapi } from '../services/RestApiServiceEmployee';

@Component({
  selector: 'app-e-show-returnjewellery',
  templateUrl: './e-show-returnjewellery.component.html',
  styles: [
  ]
})
export class EShowReturnjewelleryComponent implements OnInit {

  returnjewellerydata: returnjewellerydata[] | undefined;
  showreturnjewelleryresponse:showreturnjewelleryresponse | undefined;
  insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:erestapi) {
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
