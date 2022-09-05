import { showcartresponse } from './../model/showcartresponse';
import { cartdata } from './../model/cartdata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';

@Component({
  selector: 'app-showcart',
  templateUrl: './showcart.component.html',
  styles: [
  ]
})
export class ShowcartComponent implements OnInit {
  cartdata: cartdata[] | undefined;
  showcartresponse:showcartresponse | undefined;
   insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:restapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showcartList();
  }
  showcartList()
  {
    this.service.getCartList().subscribe(res=>{
    console.log(res);
      this.showcartresponse= res as showcartresponse;
      this.cartdata=this.showcartresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletecart(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteCart(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showcartList();
      },err=>{
        console.log(err);
      });
    }
  }
}
