
import { Component, OnInit ,ViewEncapsulation} from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { employeedata } from '../model/employeedata';
import { getemployeeresponse } from '../model/getemployeeresponse';
import { insertresponse } from '../model/insertresponse';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-addemployee',
  templateUrl: './addemployee.component.html',
  styles: [],
  encapsulation : ViewEncapsulation.None,
})
export class AddemployeeComponent implements OnInit {
  empResponce!:getemployeeresponse;
  insertResponce!:insertresponse;
  empData:employeedata={
    emp_id_pk: 0,
    emp_name: '',
    emp_address: '',
    emp_contact: '',
    is_active: 0
  };
  emp_id=0;

  constructor(private utils:Utils,public service:restapi,private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }
   

  ngOnInit(): void {
    this.route.params.subscribe((params:Params)=>{
      this.emp_id=params['id'];
    });
    if(this.emp_id==0 || this.emp_id == undefined){
      this.empData=new employeedata();
    }else{
      console.log();
      this.getEmpData();
    }
  }
   
  getEmpData(){
    this.service.getEmployeeData(this.emp_id).subscribe(res=>{
      console.log(res);
      this.empResponce=res as getemployeeresponse;
      this.empData=this.empResponce.data;
    },err=>{
      console.log(err);
    });
  }

  onSubmit(form:NgForm){
    console.log("Emp ID:"+this.emp_id);
    if(this.emp_id==0||this.emp_id==undefined){
      this.insertDetails(form);
    }else{
      this.updateDetails(form);
    }
  }

  insertDetails(form:NgForm){
    this.service.InsertEmployee(this.empData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showemployee']).then(() => {
          window.location.reload();
        });
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

   updateDetails(form:NgForm){
    this.service.UpdateEmployee(this.empData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);
        this.router.navigate(['/admin/showemployee']).then(() => {
          window.location.reload();
        });
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.empData=new employeedata();
  }
}
