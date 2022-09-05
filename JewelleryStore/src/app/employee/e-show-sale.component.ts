import { showsaleresponse } from './../model/showsaleresponse';
import { saledata } from './../model/saledata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { erestapi } from '../services/RestApiServiceEmployee';

@Component({
  selector: 'app-e-show-sale',
  templateUrl: './e-show-sale.component.html',
  styles: [
  ]
})
export class EShowSaleComponent implements OnInit {

  saledata: saledata[] | undefined;
  showsaleresponse:showsaleresponse | undefined;
   insertresponse:insertresponse | undefined;


  constructor(private utils:Utils, public service:erestapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showsaleList();
  }

  showsaleList()
  {
    this.service.getSaleList().subscribe(res=>{
    console.log(res);
      this.showsaleresponse= res as showsaleresponse;
      this.saledata=this.showsaleresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletesale(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteSale(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showsaleList();
      },err=>{
        console.log(err);
      });
    }
  }

}
