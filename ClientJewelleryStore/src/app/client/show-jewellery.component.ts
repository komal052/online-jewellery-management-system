import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { insertresponse } from '../model/insertresponse';
import { jewellerydata } from '../model/jewellerydata';
import { showjewelleryresponse } from '../model/showjewelleryresponse';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';

@Component({
  selector: 'app-show-jewellery',
  templateUrl: './show-jewellery.component.html',
  styles: [
  ]
})
export class ShowJewelleryComponent implements OnInit {
  jewellerydata: jewellerydata[] | undefined;
  showjewelleryresponse:showjewelleryresponse | undefined;
  insertresponse:insertresponse | undefined;

  baseUrl =''

  constructor(private utils:Utils,public service:restapi,private router: Router) {
    new Promise((resolve)=>{
      utils.loadIndexScript();
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

}
