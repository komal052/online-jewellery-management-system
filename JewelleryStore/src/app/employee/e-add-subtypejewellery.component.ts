import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute ,Params,Router} from '@angular/router';
import { getjewelleryresponse } from '../model/getjewelleryresponse';
import { getsubjewelleryresponse } from '../model/getsubjewelleryresponse';
import { insertresponse } from '../model/insertresponse';
import { jewellerydata } from '../model/jewellerydata';
import { showjewelleryresponse } from '../model/showjewelleryresponse';
import { subjewelleryData } from '../model/subjewellerydata';
import { erestapi } from '../services/RestApiServiceEmployee';
import { Utils } from '../services/utils.service';

@Component({
  selector: 'app-e-add-subtypejewellery',
  templateUrl: './e-add-subtypejewellery.component.html',
  styles: [],
  encapsulation : ViewEncapsulation.None,
})
export class EAddSubtypejewelleryComponent implements OnInit {

  getjewelleryresponse !: getjewelleryresponse;
  jewellerydata!:jewellerydata[];
  getsubjewelleryresponse!:getsubjewelleryresponse;
  showjewelleryresponse!:showjewelleryresponse;
  insertresponse!:insertresponse;

  subjewellryData:subjewelleryData={
    subtype_jewellery_id_pk: 0,
    jewellery_id_fk: 0,
    subtype: '',
    price: '',
    images: '',
    description: '',
    is_active: 0,
    jewellery_name: ''
  };
  subtype_jewellery_id_pk=0;

  filesToUpload : FileList | undefined;
  constructor(private utils:Utils, public service:erestapi,private route:ActivatedRoute,private Router:Router) {
    new Promise((resolve)=>{
      utils.loadFormScript();
      resolve(true);
    });
   }

  ngOnInit(): void {
    this.route.params.subscribe((Params:Params)=>{
      this.subtype_jewellery_id_pk=Params['id'];
    });
     this.getjewellery();
    if(this.subtype_jewellery_id_pk==0|| this.subtype_jewellery_id_pk==undefined)
    {
      this.subjewellryData =new subjewelleryData();
    }else{
      console.log();
      this.getsubjewellery();
    }

  }
  getsubjewellery()
  {
    console.log("subtype_jewellery_id_pk:"+this.subtype_jewellery_id_pk);
    this.service.getsubjewellerydata(this.subtype_jewellery_id_pk).subscribe(res=>{
      this.getsubjewelleryresponse=res as getsubjewelleryresponse;
      this.subjewellryData = this.getsubjewelleryresponse.data;
    },err=>{
      console.log(err);
    })
  }
  getjewellery()
  {
    this.service.getJewelleryList().subscribe(res=>{
      console.log(res);
    this.showjewelleryresponse=res as showjewelleryresponse;
    this.jewellerydata=this.showjewelleryresponse.data;
    },err=>{
      console.log(err);
    })
  }
  comaprefun(c1:any,c2:any):boolean
  {
   return c1 && c2?c1.id===c2.id:c1===c2;
  }
  onsubmit(form:NgForm)
  {
    console.log("subtype_jewellery_id_pk:"+this.subtype_jewellery_id_pk);
    if(this.subtype_jewellery_id_pk==0 || this.subtype_jewellery_id_pk==undefined)
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
  formData.append('jewellery_id_fk',this.subjewellryData.jewellery_id_fk.toString())
  formData.append('subtype',this.subjewellryData.subtype)
  formData.append('price',this.subjewellryData.price)
  formData.append('descriprtion',this.subjewellryData.description)


    this.service.InsertSubJewellery(formData).subscribe(res=>{
      console.log(res);
      this.insertresponse=res as insertresponse;
      if(this.insertresponse.result==="success")
      {
        this.restform(form);
        this.Router.navigate(['/employee/e_show_subtypejewellery']).then(() => {
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
      formData.append('images',this.subjewellryData.images)
    }

    formData.append('subtype_jewellery_id_pk',this.subjewellryData.subtype_jewellery_id_pk.toString())
    formData.append('jewellery_id_fk',this.subjewellryData.jewellery_id_fk.toString())
    formData.append('subtype',this.subjewellryData.subtype)
    formData.append('price',this.subjewellryData.price)
    formData.append('descriprtion',this.subjewellryData.description)

   this.service.UpdateSubJewellery(formData).subscribe(res=>{
     this.insertresponse=res as insertresponse;
     if(this.insertresponse.result==="success")
     {
       this.restform(form);
       this.Router.navigate(['/employee/e_show_subtypejewellery']).then(() => {
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

    this.subjewellryData=new subjewelleryData();
  }

}
