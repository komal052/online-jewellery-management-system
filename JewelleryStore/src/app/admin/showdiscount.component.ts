import { showdiscountresponse } from './../model/showdiscountresponse';
import { discountdata } from './../model/discountdata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';

@Component({
  selector: 'app-showdiscount',
  templateUrl: './showdiscount.component.html',
  styles: [
  ]
})
export class ShowdiscountComponent implements OnInit {
  discountdata: discountdata[] | undefined;
  showdiscountresponse:showdiscountresponse | undefined;
  insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
   this.showdiscountList();
  }

  showdiscountList()
  {
    this.service.getDiscountList().subscribe(res=>{
    console.log(res);
      this.showdiscountresponse= res as showdiscountresponse;
      this.discountdata=this.showdiscountresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletediscount(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteDiscount(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showdiscountList();
      },err=>{
        console.log(err);
      });
    }
  }
}
