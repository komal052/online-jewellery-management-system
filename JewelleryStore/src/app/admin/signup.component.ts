import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { citydata } from '../model/citydata';
import { getuserresponse } from '../model/getuserresponse';
import { insertresponse } from '../model/insertresponse';
import { showcityresponse } from '../model/showcityresponse';
import { showstateresponse } from '../model/showstateresponse';
import { statedata } from '../model/statedata';
import { userdata } from '../model/userdata';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styles: [
  ]
})
export class SignupComponent implements OnInit {

  userResponce! :getuserresponse   ;
  stateList!:statedata[];
  cityList!:citydata[];
  insertResponce!:insertresponse;
  userData : userdata={
    user_id_pk : 0,
    f_name: "",
    l_name : "",
    gender : "",
    birthdate : "",
    status : "",
    anniversary_date : "",
    state_id_fk : 0,
    state_name : "",
    city_id_fk : 0,
    city_name : "",
    address : "",
    pincode:"",
    email : "",
    password : "",
    contact : "",
    u_type : "",
    profile:"",
    is_active : 1
  };
  user_id_pk = 0;
  showstateresponse!: showstateresponse;
  showcityresponse!:showcityresponse;
  constructor(private utils:Utils,public service : restapi, private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

   filesToUpload : FileList | undefined;

   ngOnInit(): void {

    this.getState();
    //this.getCity();
    this.route.params.subscribe((params:Params)=>{
      this.user_id_pk=params['id'];
    });
    if(this.user_id_pk==0 || this.user_id_pk == undefined){
      this.userData=new userdata();
    }else{
      console.log();
      this.getUserData();
    }
  }
  getUserData() {
    console.log("User ID:"+this.user_id_pk);
    this.service.getUserdata(this.user_id_pk).subscribe(res=>{
      console.log(res);
      this.userResponce=res as getuserresponse;
      this.userData=this.userResponce.data;
    },err=>{
      console.log(err);
    });
  }

  compareFn(c1:any ,c2:any):boolean{
    return c1 && c2 ? c1.id === c2.id :c1 === c2;
  }

  compareFn1(c1:any ,c2:any):boolean{
    return c1 && c2 ? c1.id === c2.id :c1 === c2;
  }

  getState() {
    this.service.getStateList().subscribe(res=>{
      console.log(res);
      this.showstateresponse=res as showstateresponse;
      this.stateList=this.showstateresponse.data;
    },err=>{
      console.log(err);
    });
  }

  getCity(stateId:number) {
    this.service.getCitydata(stateId).subscribe(res=>{
      console.log(res);
      this.showcityresponse=res as showcityresponse;
      this.cityList=this.showcityresponse.data;
    },err=>{
      console.log(err);
    });
  }



  onSubmit(form:NgForm){
    console.log("USER ID:"+this.user_id_pk);
    if(this.user_id_pk==0||this.user_id_pk==undefined)
    {
      this.insertDetails(form);
    }
  }

  insertDetails(form:NgForm){

    const formData = new FormData();
    formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
    formData.append('state_id_fk',this.userData.state_id_fk.toString())
    formData.append('city_id_fk',this.userData.city_id_fk.toString())
    formData.append('f_name',this.userData.f_name)
    formData.append('l_name',this.userData.l_name)
    formData.append('f_name',this.userData.f_name)
    formData.append('gender',this.userData.gender)
    formData.append('birthdate',this.userData.birthdate)
    formData.append('status',this.userData.status)
    formData.append('anniversary_date',this.userData.anniversary_date)
    formData.append('address',this.userData.address)
    formData.append('pincode',this.userData.pincode)
    formData.append('email',this.userData.email)
    formData.append('password',this.userData.password)
    formData.append('contact',this.userData.contact)
    formData.append('u_type',this.userData.u_type)

    this.userData.password = this.userData.contact;
    this.service.InsertUser(formData).subscribe(res=>{
      console.log(res);
      this.insertResponce= res as insertresponse;
      if(this.insertResponce.result === "success"){
        this.resetForm(form);


         if(this.userData.u_type == "Employee")
        {
          console.log("success");
          this.router.navigate(['/employee'],{relativeTo:this.route});
        }
        else if(this.userData.u_type == "Manager")
        {
          console.log("success");
          this.router.navigate(['/manager'],{relativeTo:this.route});
        }


        //  this.router.navigate(['/admin/showregistration'],{relativeTo:this.route})
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
  }

  // insertDetails(form:NgForm){
  //   this.userData.password = this.userData.contact;
  //   this.service.InsertUser(this.userData).subscribe(res=>{
  //     console.log(res);
  //     this.insertResponce= res as insertresponse;
  //     if(this.insertResponce.result === "success"){
  //       this.resetForm(form);
  //       this.router.navigate(['/admin/showregistration'],{relativeTo:this.route})
  //     }else{
  //       console.log(res);
  //     }
  //   },err=>{
  //     console.log(err);
  //   });
  // }


  OnChange(stateID:any){
    console.log(stateID.target.value);
    this.getCity(stateID.target.value);
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.userData=new userdata();
  }

}
