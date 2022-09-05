
import { showemployeeresponse } from './../model/showemployeeresponse';
import { employeedata } from './../model/employeedata';
import { Component, OnInit } from '@angular/core';
import { Utils } from '../services/utils.service';
import { insertresponse } from '../model/insertresponse';
import { erestapi } from '../services/RestApiServiceEmployee';

@Component({
  selector: 'app-e-show-employee',
  templateUrl: './e-show-employee.component.html',
  styles: [
  ]
})
export class EShowEmployeeComponent implements OnInit {
  employeedata: employeedata[] | undefined;
  showemployeeresponse:showemployeeresponse | undefined;
  insertresponse:insertresponse | undefined;

  constructor(private utils:Utils,public service:erestapi) {
    new Promise((resolve)=>{
      utils.loadTablesScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.showemployeeList();
  }
  showemployeeList()
  {
    this.service.getEmployeeList().subscribe(res=>{
    console.log(res);
      this.showemployeeresponse= res as showemployeeresponse;
      this.employeedata=this.showemployeeresponse.data;
    },err=>{
      console.log(err);
    });
  }
  
  deleteemployee(id:number)
  {
    if(confirm('are u sure to delete this record'))
    {
      this.service.DeleteEmployee(id).subscribe(res=>{
        console.log(res);
        this.insertresponse= res as insertresponse;
        this.showemployeeList();
      },err=>{
        console.log(err);
      });
    }
  }

}
