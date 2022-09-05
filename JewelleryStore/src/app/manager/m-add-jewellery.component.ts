import { ActivatedRoute, Router,Params } from '@angular/router';
import { restapi } from './../services/RestApiService';
import { showgoldresponse } from './../model/showgoldresponse';
import { showdiamondsponse } from './../model/showdiamondresponse';
import { diamonddata } from './../model/diamonddata';
import { golddata } from './../model/golddata';
import { getsilverresponse } from './../model/getsilverResponse';
import { getdiamondresponse } from './../model/getdiamondresponse';
import { getgoldresponse } from './../model/getgoldresponse';
import { insertresponse } from './../model/insertresponse';
import { jewellerydata } from './../model/jewellerydata';
import { getjewelleryresponse } from './../model/getjewelleryresponse';
import { Component, OnInit ,ViewEncapsulation} from '@angular/core';
import { Utils } from '../services/utils.service';
import { NgForm } from '@angular/forms';
import { mrestapi } from '../services/RestApiServiceManager';


@Component({
  selector: 'app-m-add-jewellery',
  templateUrl: './m-add-jewellery.component.html',
  styles: [
  ]
})
export class MAddJewelleryComponent implements OnInit {

  getgoldresponse!:getgoldresponse;
  getdiamondresponse!:getdiamondresponse;
  getsilverresponse!:getsilverresponse;

  golddata!:golddata[];
  
  diamonddata!:diamonddata[];

  getjewelleryresponse!:getjewelleryresponse;
  showdiamondsponse!:showdiamondsponse;
 
  showgoldresponse!:showgoldresponse;

  insertresponse!:insertresponse;

  jewellerydata:jewellerydata={
    jewellery_id_pk: 0,
    jewellery_name: '',
    diamond_id_fk: '',
    gold_id_fk: 0,
    images: '',
    is_active: 1,
    diamond_color: '',
    shape: '',
    gold_type: '',

  }
  jewellery_id_pk=0;

  filesToUpload : FileList | undefined;

  constructor(private utils:Utils,public service:mrestapi,private route:ActivatedRoute,private Router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

   public uploadFile = (files: FileList | null) =>{
    if(files!.length === 0){
      return;
    }
    this.filesToUpload = files!
  }

  ngOnInit(): void {
    this.getdiamond();
    this.getgold();
    this.route.params.subscribe((Params:Params)=>{
      this.jewellery_id_pk=Params['id'];
    });
   
    if(this.jewellery_id_pk==0|| this.jewellery_id_pk==undefined)
    {
      this.jewellerydata =new jewellerydata();
    }else{
      console.log();
      this.getjewellery();
    }

  }
  getjewellery()
  {
    console.log("jewellery_id_pk:"+this.jewellery_id_pk);
    this.service.getJewellerydata(this.jewellery_id_pk).subscribe(res=>{
      this.getjewelleryresponse=res as getjewelleryresponse;
      this.jewellerydata = this.getjewelleryresponse.data;
    },err=>{
      console.log(err);
    })
  }
  getdiamond()
  {

    this.service.getDiamondList().subscribe(res=>{
      console.log(res);
    this.showdiamondsponse=res as showdiamondsponse;
    this.diamonddata=this.showdiamondsponse.data;
    },err=>{
      console.log(err);
    })
  }
 
  getgold()
  {
    this.service.getGoldList().subscribe(res=>{
      console.log(res);
    this.showgoldresponse=res as showgoldresponse;
    this.golddata=this.showgoldresponse.data;
    },err=>{
      console.log(err);
    })
  }

  comaprefun(c1:any,c2:any):boolean
 {
  return c1 && c2?c1.id===c2.id:c1===c2;
 }
 comaprefun1(c1:any,c2:any):boolean
  {
   return c1 && c2?c1.id===c2.id:c1===c2;
  }
 
 onsubmit(form:NgForm)
 {
   console.log("jewellery_id_pk:"+this.jewellery_id_pk);
   if(this.jewellery_id_pk==0 || this.jewellery_id_pk==undefined)
   {
     this.insertdetails(form);
   }
   else{
     this.updatedetails(form);
   }
 }
 insertdetails(form:NgForm)
 {

  const formData = new FormData();
  formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
  formData.append('diamond_id_fk',this.jewellerydata.diamond_id_fk.toString())
  formData.append('gold_id_fk',this.jewellerydata.gold_id_fk.toString())
  formData.append('jewellery_name',this.jewellerydata.jewellery_name)

    this.service.InsertJewellery(formData).subscribe(res=>{
      console.log(res);
      this.insertresponse=res as insertresponse;
      if(this.insertresponse.result==="success")
      {
        this.restform(form);
        this.Router.navigate(['/manager/m_show_jewellery']).then(() => {
          window.location.reload();
        });
      }else{
        console.log(res);
      }
    },err=>{
      console.log(err);
    });
 }
 updatedetails(form:NgForm)
 {
  const formData = new FormData();
    if(this.filesToUpload != null || this.filesToUpload != undefined){
      formData.append('file',this.filesToUpload![0],this.filesToUpload![0].name)
    }else{
      formData.append('images',this.jewellerydata.images)
    }
    
    formData.append('jewellery_id_pk',this.jewellerydata.jewellery_id_pk.toString())
    formData.append('diamond_id_fk',this.jewellerydata.diamond_id_fk.toString())
    formData.append('gold_id_fk',this.jewellerydata.gold_id_fk.toString())
    formData.append('jewellery_name',this.jewellerydata.jewellery_name)

   this.service.UpdateJewellery(formData).subscribe(res=>{
     this.insertresponse=res as insertresponse;
     if(this.insertresponse.result==="success")
     {
       this.restform(form);
       this.Router.navigate(['/manager/m_show_jewellery']).then(() => {
        window.location.reload();
      });
     }else{
       console.log(res);
     }
   },err=>{
     console.log(err);
   });
 }


 restform(form:NgForm)
 {
   form.form.reset();
   this.jewellerydata=new jewellerydata();
 }

}
