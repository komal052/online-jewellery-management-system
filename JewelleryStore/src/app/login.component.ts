

import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, Params } from '@angular/router';
import { NgForm } from '@angular/forms';
import { userdata } from './model/userdata';
import { getuserresponse } from './model/getuserresponse';
import { Utils } from './services/utils.service';
import { restapi } from './services/RestApiService';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: [
  ]
})
export class LoginComponent implements OnInit {
  userData: userdata = {
    user_id_pk: 0,
    f_name: "",
    l_name: "",
    gender: "",
    birthdate: "",
    status: "",
    anniversary_date: "",
    state_id_fk: 0,
    state_name: "",
    city_id_fk: 0,
    city_name: "",
    address: "",
    pincode:"",
    email: "",
    password: "",
    contact: "",
    u_type: "",
    profile: "",
    is_active: 1
  };
  getuserresponse!: getuserresponse;

  isvalid = false;

  constructor(private utils: Utils,
    public service: restapi, private route: ActivatedRoute, private router: Router) {
    new Promise((resolve) => {
      utils.loadFormScript();
      resolve(true);
    });
  }

  ngOnInit(): void {
    this.userData = new userdata();
  }
  onSubmit(form: NgForm) {
    // console.log(this.userData);
    this.service.LoginUser(this.userData).subscribe(res => {
      console.log(res);
      this.getuserresponse = res as getuserresponse;


      if (this.getuserresponse.result === "success") {

        this.userData = this.getuserresponse.data;
        console.log(this.userData);

        sessionStorage.setItem('isLoggedIn', "true");
        sessionStorage.setItem('user_id', this.userData.user_id_pk.toString());
        sessionStorage.setItem('user_type', this.userData.u_type);


        if (this.userData.u_type === 'Admin') {
          console.log("success");
          this.router.navigate(['/admin']).then(() => {
            window.location.reload();
          });
        }
        else if (this.userData.u_type === "Employee") {
          console.log("success");
          this.router.navigate(['/employee']).then(() => {
            window.location.reload();
          });
        }
        else if (this.userData.u_type === "Manager") {
          console.log("success");
          this.router.navigate(['/manager']).then(() => {
            window.location.reload();
          });
        }
      }
      else {
        console.log("failed");
        // this.isvalid=true;


      }

    });

  }

  // check()
  // {
  //   this.isvalid=true;
  // }

}
