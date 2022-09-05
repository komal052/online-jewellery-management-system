import { showpurchaseresponse } from './../model/showpurchaseresponse';
import { purchasedata } from './../model/purchasedata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { erestapi } from '../services/RestApiServiceEmployee';

@Component({
  selector: 'app-e-show-purchase',
  templateUrl: './e-show-purchase.component.html',
  styles: [
  ]
})
export class EShowPurchaseComponent implements OnInit {

  purchasedata: purchasedata[] | undefined;
  showpurchaseresponse:showpurchaseresponse | undefined;
  insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:erestapi) {
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
