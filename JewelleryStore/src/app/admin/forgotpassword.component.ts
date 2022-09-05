import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { getuserresponse } from '../model/getuserresponse';
import { userdata } from '../model/userdata';
import { restapi } from '../services/RestApiService';
import { Utils } from '../services/utils.service';

@Component({
  selector: 'app-forgotpassword',
  templateUrl: './forgotpassword.component.html',
  styles: [
  ]
})
export class ForgotpasswordComponent implements OnInit {
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
  getuserresponse!:getuserresponse;


  constructor(private utils:Utils,
    public service : restapi, private route:ActivatedRoute,private router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.userData=new userdata();
  }
  onSubmit(form:NgForm)
  {
   // console.log(this.userData);
   this.service.CheckEmail(this.userData).subscribe(res=>{
    // console.log(res);
     this.getuserresponse=res as getuserresponse;


     if(this.getuserresponse.result==="success")
     {

       this.userData = this.getuserresponse.data;
       console.log(this.userData);

         localStorage.setItem('isLoggedIn',"true");
       localStorage.setItem('user_id', this.userData.user_id_pk.toString());
      //  localStorage.setItem('user_type',this.userData.u_type);
      //  localStorage.setItem('user_email',this.userData.email);


       if((this.userData.email !=null))
       {
         console.log("success");
         this.router.navigate(['/admin/checkpassword'],{relativeTo:this.route});
       }
       else{
        console.log("failed");
       }
     }
     else{
       console.log("failed");
     }

   });

 }

  // check()
  // {
  //   this.isvalid=true;
  // }


}
