import { showpaymentresponse } from './../model/showpaymentresponse';
import { paymentdata } from './../model/paymentdata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { erestapi } from '../services/RestApiServiceEmployee';

@Component({
  selector: 'app-e-show-payment',
  templateUrl: './e-show-payment.component.html',
  styles: [
  ]
})
export class EShowPaymentComponent implements OnInit {

  paymentdata: paymentdata[] | undefined;
  showpaymentresponse:showpaymentresponse | undefined;
  insertresponse:insertresponse | undefined;



  constructor(private utils:Utils,public service:erestapi) {
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
