import { certidata } from './../model/certidata';
import { showgoldresponse } from './../model/showgoldresponse';

import { golddata } from './../model/golddata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { restapi } from '../services/RestApiService';

@Component({
  selector: 'app-showgold',
  templateUrl: './showgold.component.html',
  styles: [
  ]
})
export class ShowgoldComponent implements OnInit {
  golddata: golddata[] | undefined;
  showgoldresponse:showgoldresponse | undefined;
  insertresponse:insertresponse | undefined;
  certidata:certidata|undefined;

  baseUrl =''  


  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }


  ngOnInit(): void {
    this.baseUrl=this.utils.baseUrl
    this.showgoldList();
  }
  showgoldList()
  {
    this.service.getGoldList().subscribe(res=>{
    console.log(res);
      this.showgoldresponse= res as showgoldresponse;
      this.golddata=this.showgoldresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
 deletegold(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteGold(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showgoldList();
      },err=>{
        console.log(err);
      });
    }
  }

}
