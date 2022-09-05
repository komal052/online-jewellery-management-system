
import { showsilverresponse } from './../model/showsilverdata';
import { silverdata } from './../model/silverdata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { mrestapi } from '../services/RestApiServiceManager';

@Component({
  selector: 'app-m-show-silver',
  templateUrl: './m-show-silver.component.html',
  styles: [
  ]
})
export class MShowSilverComponent implements OnInit {

  silverdata: silverdata[] | undefined;
  showsilverresponse:showsilverresponse | undefined;
   insertresponse:insertresponse | undefined;


  constructor(private utils:Utils,public service:mrestapi) {

    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showsilverList();
  }
showsilverList()
  {
    this.service.getSilverList().subscribe(res=>{
    console.log(res);
      this.showsilverresponse= res as showsilverresponse;
      this.silverdata=this.showsilverresponse.data;
    },err=>{
      console.log(err);
    });
  }

  deletesilver(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteSilver(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showsilverList();
      },err=>{
        console.log(err);
      });
    }
  }

}
