import { diamonddata } from './../model/diamonddata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { showdiamondsponse } from '../model/showdiamondresponse';
import { insertresponse } from '../model/insertresponse';
import { restapi } from '../services/RestApiService';


@Component({
  selector: 'app-showdiamond',
  templateUrl: './showdiamond.component.html',
  styles: [
  ]
})
export class ShowdiamondComponent implements OnInit {

  diamonddata: diamonddata[] | undefined;
  showdiamondsponse:showdiamondsponse | undefined;
  insertresponse:insertresponse | undefined;

  baseUrl=''

  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.baseUrl=this.utils.baseUrl
    this.showdiamondList();

  }
  showdiamondList()
  {
    this.service.getDiamondList().subscribe(res=>{
    console.log(res);
      this.showdiamondsponse= res as showdiamondsponse;
      this.diamonddata=this.showdiamondsponse.data;
    },err=>{
      console.log(err);
    });
  }

  deletediamond(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteDiamond(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showdiamondList();
      },err=>{
        console.log(err);
      });
    }
  }

}
