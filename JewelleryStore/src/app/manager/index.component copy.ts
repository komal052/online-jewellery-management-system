
import { Utils } from './../services/utils.service';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  encapsulation : ViewEncapsulation.None,
})
export class IndexComponent implements OnInit {

  constructor(private utils:Utils) {
    new Promise((resolve)=>{
      utils.loadIndexScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
  }

}
