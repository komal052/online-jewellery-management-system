import { showpaymentresponse } from './../model/showpaymentresponse';
import { paymentdata } from './../model/paymentdata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';

@Component({
  selector: 'app-showpayment',
  templateUrl: './showpayment.component.html',
  styles: [
  ]
})
export class ShowpaymentComponent implements OnInit {

  paymentdata: paymentdata[] | undefined;
  showpaymentresponse:showpaymentresponse | undefined;
  insertresponse:insertresponse | undefined;



  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showpaymentList();
  }
  showpaymentList()
  {
    this.service.getPaymentList().subscribe(res=>{
    console.log(res);
      this.showpaymentresponse= res as showpaymentresponse;
      this.paymentdata=this.showpaymentresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletepayment(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeletePayment(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showpaymentList();
      },err=>{
        console.log(err);
      });
    }
  }

}
