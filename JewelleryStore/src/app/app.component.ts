import { Component ,HostListener,ViewEncapsulation} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  encapsulation : ViewEncapsulation.None,
})
export class AppComponent {
  isLoggedIn=false;
  user_type:string|undefined;
  title = 'JewelleryStore';
  
  constructor()
  {

  }
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.user_type=sessionStorage.getItem("user_type")?.toString();
    if(sessionStorage.getItem("isLoggedIn")=="true"){
      this.isLoggedIn=true;
    }
    
  }
}
