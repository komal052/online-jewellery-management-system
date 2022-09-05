import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { getuserresponse } from '../model/getuserresponse';
import { userdata } from '../model/userdata';
import { restapi } from '../services/RestApiService';

@Component({
  selector: 'app-m-header',
  templateUrl: './m-header.component.html',
  styles: [
  ]
})
export class MHeaderComponent implements OnInit {

  userResponce! :getuserresponse   ;
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
  constructor(public service : restapi, private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {
    this.user_id_pk = Number(sessionStorage.getItem("user_id")?.toString());
    this.getUserData();
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

  logout(){
    sessionStorage.setItem('isLoggedIn',"false");
    sessionStorage.setItem('user_id',"0");
    sessionStorage.setItem('user_type',"0");
    sessionStorage.clear();
    this.router.navigate(['/'],{relativeTo:this.route});
  }

}
