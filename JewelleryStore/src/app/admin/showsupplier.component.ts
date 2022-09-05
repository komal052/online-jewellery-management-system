import { showsupplierresponse } from './../model/showsupplierresponse';
import { supplierdata } from './../model/supplierdata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';

@Component({
  selector: 'app-showsupplier',
  templateUrl: './showsupplier.component.html',
  styles: [
  ]
})
export class ShowsupplierComponent implements OnInit {
  supplierdata: supplierdata[] | undefined;
  showsupplierresponse:showsupplierresponse | undefined;
  insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showsupplierList();
  }
  showsupplierList()
  {
    this.service.getSupplierList().subscribe(res=>{
    console.log(res);
      this.showsupplierresponse= res as showsupplierresponse;
      this.supplierdata=this.showsupplierresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletesupplier(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteSupplier(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showsupplierList();
      },err=>{
        console.log(err);
      });
    }
  }
}
