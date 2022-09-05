import { showpurchaseresponse } from './../model/showpurchaseresponse';
import { purchasedata } from './../model/purchasedata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';

@Component({
  selector: 'app-showpurchased',
  templateUrl: './showpurchased.component.html',
  styles: [
  ]
})
export class ShowpurchasedComponent implements OnInit {
  purchasedata: purchasedata[] | undefined;
  showpurchaseresponse:showpurchaseresponse | undefined;
  insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showpurchaseList();
  }
  showpurchaseList()
  {
    this.service.getPurchaseList().subscribe(res=>{
    console.log(res);
      this.showpurchaseresponse= res as showpurchaseresponse;
      this.purchasedata=this.showpurchaseresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletepurchase(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeletePurchase(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showpurchaseList();
      },err=>{
        console.log(err);
      });
    }
  }
}
