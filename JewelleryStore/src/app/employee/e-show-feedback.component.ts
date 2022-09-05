import { showfeedbackresponse } from './../model/showfeedbackresponse';
import { feedbackdata } from './../model/feedbackdata';
import { restapi } from './../services/RestApiService';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { erestapi } from '../services/RestApiServiceEmployee';

@Component({
  selector: 'app-e-show-feedback',
  templateUrl: './e-show-feedback.component.html',
  styles: [
  ]
})
export class EShowFeedbackComponent implements OnInit {

  feedbackdata: feedbackdata[] | undefined;
  showfeedbackresponse:showfeedbackresponse | undefined;
  insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:erestapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showfeedbackList();
  }
  showfeedbackList()
  {
    this.service.ProductreviewList().subscribe(res=>{
    console.log(res);
      this.showfeedbackresponse= res as showfeedbackresponse;
      this.feedbackdata=this.showfeedbackresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deletefeedback(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteFeedback(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showfeedbackList();
      },err=>{
        console.log(err);
      });
    }
  }

}
