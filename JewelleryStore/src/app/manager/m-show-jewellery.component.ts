import { showjewelleryresponse } from './../model/showjewelleryresponse';
import { jewellerydata } from './../model/jewellerydata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { mrestapi } from '../services/RestApiServiceManager';

@Component({
  selector: 'app-m-show-jewellery',
  templateUrl: './m-show-jewellery.component.html',
  styles: [
  ]
})
export class MShowJewelleryComponent implements OnInit {

  jewellerydata: jewellerydata[] | undefined;
  showjewelleryresponse:showjewelleryresponse | undefined;
  insertresponse:insertresponse | undefined;

  baseUrl =''

  constructor(private utils:Utils,public service:mrestapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.baseUrl=this.utils.baseUrl
    this.showjewelleryList();

  }
  showjewelleryList()
  {
    this.service.getJewelleryList().subscribe(res=>{
    console.log(res);
      this.showjewelleryresponse= res as showjewelleryresponse;
      this.jewellerydata=this.showjewelleryresponse.data;
    },err=>{
      console.log(err);
    });
  }

  deletejewellery(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteJewellery(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showjewelleryList();
      },err=>{
        console.log(err);
      });
    }
  }
}
