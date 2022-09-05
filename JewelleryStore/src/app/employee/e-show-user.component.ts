import { restapi } from './../services/RestApiService';
import { showuserresponse } from './../model/showuserresponse';
import { userdata } from './../model/userdata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { erestapi } from '../services/RestApiServiceEmployee';

@Component({
  selector: 'app-e-show-user',
  templateUrl: './e-show-user.component.html',
  styles: [
  ]
})
export class EShowUserComponent implements OnInit {

  userdata:userdata[] | undefined;
  showuserresponse:showuserresponse | undefined;
  insertresponse:insertresponse | undefined;

  baseUrl =''

  constructor(private utils:Utils,public service:erestapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.baseUrl=this.utils.baseUrl
    this.showuserList();
  }
  showuserList()
  {
    this.service.getUserList().subscribe(res=>{
    console.log(res);
      this.showuserresponse= res as showuserresponse;
      this.userdata=this.showuserresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  // deleteuser(id:number)
  // {
  //   if(confirm('are u sure to delete this record'))
  //   {
  //     this.service.DeleteUser(id).subscribe(res=>{
  //       console.log(res);
  //       this.insertresponse= res as insertresponse;
  //       this.showuserList();
  //     },err=>{
  //       console.log(err);
  //     });
  //   }
  // }

}
