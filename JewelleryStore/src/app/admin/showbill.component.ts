import { showbillresponse } from './../model/showbillresponse';
import { billdata } from './../model/billdata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';

@Component({
  selector: 'app-showbill',
  templateUrl: './showbill.component.html',
  styles: [
  ]
})
export class ShowbillComponent implements OnInit {
  billdata: billdata[] | undefined;
  showbillresponse:showbillresponse | undefined;
  insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showbillList();
  }
  showbillList()
  {
    this.service.getBillList().subscribe(res=>{
    console.log(res);
      this.showbillresponse= res as showbillresponse;
      this.billdata=this.showbillresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletebill(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteBill(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showbillList();
      },err=>{
        console.log(err);
      });
    }
  }
}
