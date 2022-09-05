
import { diamonddata } from './../model/diamonddata';
import { certidata } from './../model/certidata';
import { golddata } from './../model/golddata';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { silverdata } from '../model/silverdata';
import { supplierdata } from '../model/supplierdata';

@Injectable({
    providedIn:'root'
  })
export class mrestapi{
  

    constructor(private http:HttpClient){}
    readonly baseUrl='http://localhost:18250/api/Manager/';
    
  //certificate
  getCertiList() :Observable<any>{
    return this.http.get(this.baseUrl+"CertiList");
  }

  getCertidata(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"Certidata/"+id);
  }

  InsertCerti(formData:FormData):Observable<any>{
    return this.http.post(this.baseUrl+"InsertCerti",formData);
  }

  UpdateCerti(formData:FormData):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateCerti",formData);
  }

  DeleteCerti(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteCerti/"+id);
  }
  certiListCount():Observable<any>{
    return this.http.get(this.baseUrl+"certiListCount");
  }



  //gold
  getGoldList() :Observable<any>{
    return this.http.get(this.baseUrl+"GoldList");
  }

  getGolddata(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"GoldData/"+id);
  }

  InsertGold(gold:golddata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertGold",gold);
  }

  UpdateGold(gold:golddata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateGold",gold);
  }

  DeleteGold(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteGold/"+id);
  }
  goldListCount():Observable<any>{
    return this.http.get(this.baseUrl+"goldListCount");
  }

  //diamond
  getDiamondList() :Observable<any>{
    return this.http.get(this.baseUrl+"DiamondList");
  }

  getDiamondData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"DiamondData/"+id);
  }

  InsertDiamond(diamond:diamonddata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertDiamond",diamond);
  }

  UpdateDiamond(diamond:diamonddata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateDiamond",diamond);
  }

  DeleteDiamond(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteDiamond/"+id);
  }
  diamondListCount():Observable<any>{
    return this.http.get(this.baseUrl+"diamondListCount");
  }

  //Silver

  getSilverList() :Observable<any>{
    return this.http.get(this.baseUrl+"SilverList");
  }

  getSilverData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"SilverData/"+id);
  }

  InsertSilver(Silver:silverdata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertSilver",Silver);
  }

  UpdateSilver(Silver:silverdata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateSilver",Silver);
  }

  DeleteSilver(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteSilver/"+id);
  }
  silverListCount():Observable<any>{
    return this.http.get(this.baseUrl+"silverListCount");
  }

  getSubJewelleryList():Observable<any>
  {
    return this.http.get(this.baseUrl+"SubJewelleryList")
  }
  getsubjewellerydata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"SubjewelleryData/"+id);
  }
  InsertSubJewellery(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"InsertSubJewellery",formData);
  }
  UpdateSubJewellery(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"UpdateSubJewellery",formData);
  }
  DeleteSubJewellery(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"DeleteSubJewellery/"+id);
  }
  SubJewelleryListCount():Observable<any>{
    return this.http.get(this.baseUrl+"SubJewelleryListCount");
  }

  getJewelleryList():Observable<any>
  {
    return this.http.get(this.baseUrl+"JewelleryList")
  }
  getJewellerydata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"JewelleryData/"+id);
  }
  InsertJewellery(formData :FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"InsertJewellery",formData);
  }
  UpdateJewellery(formData :FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"UpdateJewellery",formData);
  }
  DeleteJewellery(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"DeleteJewellery/"+id);
  }
  JewelleryListCount():Observable<any>{
    return this.http.get(this.baseUrl+"JewelleryListCount");
  }

  getUserList():Observable<any>
  {
    return this.http.get(this.baseUrl+"UserList")
  }
  getUserdata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"UserData/"+id);
  }
  InsertUser(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"InsertUser",formData);
  }
  UpdateUser(formData:FormData):Observable<any>
  {
    return this.http.post(this.baseUrl+"UpdateUser",formData);
  }
  DeleteUser(id:number):Observable<any>
  {
    return this.http.delete(this.baseUrl+"DeleteUser/"+id);
  }

  UserListCount():Observable<any>{
    return this.http.get(this.baseUrl+"UserListCount");
  }

  getSupplierList() :Observable<any>{
    return this.http.get(this.baseUrl+"SupplierList");
  }

  getSupplierData(id:number):Observable<any>{
    return this.http.get(this.baseUrl+"SupplierData/"+id);
  }

  InsertSupplier(supplier:supplierdata):Observable<any>{
    return this.http.post(this.baseUrl+"InsertSupplier",supplier);
  }

  UpdateSupplier(supplier:supplierdata):Observable<any>{
    return this.http.post(this.baseUrl+"UpdateSupplier",supplier);
  }

  DeleteSupplier(id:number):Observable<any>{
    return this.http.delete(this.baseUrl+"DeleteSupplier/"+id);
  }
  SupplierListCount():Observable<any>{
    return this.http.get(this.baseUrl+"SupplierListCount");
  }

  getStateList():Observable<any>
  {
    return this.http.get(this.baseUrl+"StateList")
  }
  //city
  getCityList():Observable<any>
  {
    return this.http.get(this.baseUrl+"CityList")
  }
  getCitydata(id:number):Observable<any>
  {
    return this.http.get(this.baseUrl+"cityData/"+id);
  }

}
