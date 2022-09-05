import { EShowSaleComponent } from './employee/e-show-sale.component';
import { SignupComponent } from './admin/signup.component';
import { CheckpasswordComponent } from './admin/checkpassword.component';
import { EIndexComponent } from './employee/e-index.component';
import { EShowReturnjewelleryComponent } from './employee/e-show-returnjewellery.component';
import { EShowPurchaseComponent } from './employee/e-show-purchase.component';
import { EShowPaymentComponent } from './employee/e-show-payment.component';
import { EShowOrderComponent } from './employee/e-show-order.component';
import { EShowFeedbackComponent } from './employee/e-show-feedback.component';
import { EShowContactusComponent } from './employee/e-show-contactus.component';
import { EShowBillComponent } from './employee/e-show-bill.component';
import { EShowSupplierComponent } from './employee/e-show-supplier.component';
import { EAddSupplierComponent } from './employee/e-add-supplier.component';
import { EShowSubtypejewelleryComponent } from './employee/e-show-subtypejewellery.component';
import { EAddSubtypejewelleryComponent } from './employee/e-add-subtypejewellery.component';
import { EAddSaleComponent } from './employee/e-add-sale.component';
import { EShowDiscountComponent } from './employee/e-show-discount.component';
import { EAddDiscountComponent } from './employee/e-add-discount.component';
import { EShowEmployeeComponent } from './employee/e-show-employee.component';
import { EAddEmployeeComponent } from './employee/e-add-employee.component';
import { EShowJewelleryComponent } from './employee/e-show-jewellery.component';
import { EAddJewelleryComponent } from './employee/e-add-jewellery.component';
import { MShowSilverComponent } from './manager/m-show-silver.component';
import { MShowGoldComponent } from './manager/m-show-gold.component';
import { MShowDiamondComponent } from './manager/m-show-diamond.component';
import { MShowCertificateComponent } from './manager/m-show-certificate.component';
import { MAddSilverComponent } from './manager/m-add-silver.component';
import { MAddGoldComponent } from './manager/m-add-gold.component';
import { MAddDiamondComponent } from './manager/m-add-diamond.component';
import { MAddCertificateComponent } from './manager/m-add-certificate.component';
import { ManagerComponent } from './manager/manager.component';
import { ForgotpasswordComponent } from './admin/forgotpassword.component';
import { LoginComponent } from './login.component';

import { AdduserComponent } from './admin/adduser.component';
import { ShowreturnjewelleryComponent } from './admin/showreturnjewellery.component';
import { ShowsupplierComponent } from './admin/showsupplier.component';
import { ShowsubtypejewelleryComponent } from './admin/showsubtypejewellery.component';
import { ShowsilverComponent } from './admin/showsilver.component';
import { ShowsaleComponent } from './admin/showsale.component';
import { ShowregistrationComponent } from './admin/showregistration.component';
import { ShowpurchasedComponent } from './admin/showpurchased.component';
import { ShowpaymentComponent } from './admin/showpayment.component';
import { ShoworderComponent } from './admin/showorder.component';
import { ShowjewelleryComponent } from './admin/showjewellery.component';
import { ShowgoldComponent } from './admin/showgold.component';
import { ShowfeedbackComponent } from './admin/showfeedback.component';
import { ShowemployeeComponent } from './admin/showemployee.component';
import { ShowdiscountComponent } from './admin/showdiscount.component';
import { ShowdiamondComponent } from './admin/showdiamond.component';
import { ShowcontactComponent } from './admin/showcontact.component';
import { ShowcertificateComponent } from './admin/showcertificate.component';
import { ShowcartComponent } from './admin/showcart.component';
import { ShowbillComponent } from './admin/showbill.component';
import { AddsupplierComponent } from './admin/addsupplier.component';
import { AddsubtypejewelleryComponent } from './admin/addsubtypejewellery.component';
import { AddsilverComponent } from './admin/addsilver.component';
import { AddsaleComponent } from './admin/addsale.component';
import { AddgoldComponent } from './admin/addgold.component';
import { AdddiscountComponent } from './admin/adddiscount.component';
import { AdddiamondComponent } from './admin/adddiamond.component';
import { AddcertificateComponent } from './admin/addcertificate.component';
import { AddemployeeComponent } from './admin/addemployee.component';
import { AddjewelleryComponent } from './admin/addjewellery.component';

import { IndexComponent } from './admin/index.component';
import { AdminComponent } from './admin/admin.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MIndexComponent } from './manager/m-index.component';
import { EShowUserComponent } from './employee/e-show-user.component';
import { AuthGuard } from './services/auth.guard';
import { MAddJewelleryComponent } from './manager/m-add-jewellery.component';
import { MShowJewelleryComponent } from './manager/m-show-jewellery.component';
import { MAddSubtypejewelleryComponent } from './manager/m-add-subtypejewellery.component';
import { MShowSubtypejewelleryComponent } from './manager/m-show-subtypejewellery.component';
import { MAddSupplierComponent } from './manager/m-add-supplier.component';
import { MShowSupplierComponent } from './manager/m-show-supplier.component';
import { MShowUserComponent } from './manager/m-show-user.component';
import { MAddUserComponent } from './manager/m-add-user.component';

const routes: Routes = [
  {path:'',redirectTo:'/login',pathMatch:'full'},
    {path:'login',component:LoginComponent},
  {path:'admin',component:AdminComponent,children:[
      {path:'',component:IndexComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'addjewellery',component:AddjewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editjewellery/:id',component:AddjewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showjewellery',component:ShowjewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},


      {path:'addemployee',component:AddemployeeComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editemployee/:id',component:AddemployeeComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showemployee',component:ShowemployeeComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'addcertificate',component:AddcertificateComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editcertificate/:id',component:AddcertificateComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showcertificate',component:ShowcertificateComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'adddiamond',component:AdddiamondComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editdiamond/:id',component:AdddiamondComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showdiamond',component:ShowdiamondComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'adddiscount',component:AdddiscountComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editdiscount/:id',component:AdddiscountComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showdiscount',component:ShowdiscountComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'addgold',component:AddgoldComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editgold/:id',component:AddgoldComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showgold',component:ShowgoldComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'addsale',component:AddsaleComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editsale/:id',component:AddsaleComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showsale',component:ShowsaleComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'addsilver',component:AddsilverComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editsilver/:id',component:AddsilverComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showsilver',component:ShowsilverComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'addsubtypejewellery',component:AddsubtypejewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editsubtypejewellery/:id',component:AddsubtypejewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showsubtypejewellery',component:ShowsubtypejewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'addsupplier',component:AddsupplierComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'editsupplier/:id',component:AddsupplierComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showsupplier',component:ShowsupplierComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'showbill',component:ShowbillComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showcart',component:ShowcartComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showcontact',component:ShowcontactComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showfeedback',component:ShowfeedbackComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'showorder',component:ShoworderComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showpayment',component:ShowpaymentComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showpurchase',component:ShowpurchasedComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'adduser',component:AdduserComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'edituser/:id',component:AdduserComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'showregistration',component:ShowregistrationComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'showreturnjewellery',component:ShowreturnjewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

     
      {path:'forgotpassword',component:ForgotpasswordComponent},
      {path:'checkpassword',component:CheckpasswordComponent},
      {path:'signup',component:SignupComponent}
    ]
    
  },
  {
    path:'',redirectTo:'/manager',pathMatch:'full'},
  {
    path:'manager',component:ManagerComponent,children:[
      {path:'',component:MIndexComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'m_add_certificate',component:MAddCertificateComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_edit_certificate/:id',component:MAddCertificateComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_show_certificate',component:MShowCertificateComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'m_add_diamond',component:MAddDiamondComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_edit_diamond/:id',component:MAddDiamondComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_show_diamond',component:MShowDiamondComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

    

      {path:'m_add_gold',component:MAddGoldComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_edit_gold/:id',component:MAddGoldComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_show_gold',component:MShowGoldComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'m_add_silver',component:MAddSilverComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_edit_silver/:id',component:MAddSilverComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_show_silver',component:MShowSilverComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'m_add_jewellery',component:MAddJewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_edit_jewellery/:id',component:MAddJewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_show_jewellery',component:MShowJewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'m_add_subtypejewellery',component:MAddSubtypejewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_edit_subtypejewellery/:id',component:MAddSubtypejewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_show_subtypejewellery',component:MShowSubtypejewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'m_add_supplier',component:MAddSupplierComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_edit_supplier/:id',component:MAddSupplierComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_show_supplier',component:MShowSupplierComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
     
      {path:'m_show_user',component:MShowUserComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'m_add_user',component:MAddUserComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
    ]
    
  },
  {
    path:'',redirectTo:'/employee',pathMatch:'full'},
  {
    path:'employee',component:AdminComponent,children:[
      {path:'',component:EIndexComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'e_add_jewellery',component:EAddJewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_edit_jewellery/:id',component:EAddJewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_show_jewellery',component:EShowJewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},


      {path:'e_add_employee',component:EAddEmployeeComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_edit_employee/:id',component:EAddEmployeeComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_show_employee',component:EShowEmployeeComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

     

      {path:'e_add_discount',component:EAddDiscountComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_edit_discount/:id',component:EAddDiscountComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_show_discount',component:EShowDiscountComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},


      {path:'e_add_sale',component:EAddSaleComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_edit_sale/:id',component:EAddSaleComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_show_sale',component:EShowSaleComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},


      {path:'e_add_subtypejewellery',component:EAddSubtypejewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_edit_subtypejewellery/:id',component:EAddSubtypejewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_show_subtypejewellery',component:EShowSubtypejewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'e_add_supplier',component:EAddSupplierComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_edit_supplier/:id',component:EAddSupplierComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_show_supplier',component:EShowSupplierComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'e_show_bill',component:EShowBillComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      // {path:'showcart',component:ShowcartComponent},
      {path:'e_show_contact',component:EShowContactusComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_show_feedback',component:EShowFeedbackComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'e_show_order',component:EShowOrderComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_show_payment',component:EShowPaymentComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      {path:'e_show_purchase',component:EShowPurchaseComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

     
      {path:'e_show_registration',component:EShowUserComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},

      {path:'e_show_returnjewellery',component:EShowReturnjewelleryComponent,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
      // {path:'e_edit_returnjewellery/:id',component:Eadd,canActivate:[AuthGuard],runGuardsAndResolvers: "always",},
     ]
    
  }
  
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
