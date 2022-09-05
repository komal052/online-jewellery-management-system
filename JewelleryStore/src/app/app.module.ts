import { AddemployeeComponent } from './admin/addemployee.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './admin/index.component';
import { HeaderComponent } from './admin/header.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { AdminComponent } from './admin/admin.component';
import { AddjewelleryComponent } from './admin/addjewellery.component';
import {AdddiamondComponent} from './admin/adddiamond.component';
import { AddsilverComponent } from './admin/addsilver.component';
import { AddgoldComponent } from './admin/addgold.component';
import { AddcertificateComponent } from './admin/addcertificate.component';
import { ShowcertificateComponent } from './admin/showcertificate.component';
import { ShowgoldComponent } from './admin/showgold.component';
import { ShowsilverComponent } from './admin/showsilver.component';
import { ShowdiamondComponent } from './admin/showdiamond.component';
import { ShowemployeeComponent } from './admin/showemployee.component';
import { ShowjewelleryComponent } from './admin/showjewellery.component';
import { ShowregistrationComponent } from './admin/showregistration.component';
import { AddsubtypejewelleryComponent } from './admin/addsubtypejewellery.component';
import { ShowsubtypejewelleryComponent } from './admin/showsubtypejewellery.component';
import { AddsaleComponent } from './admin/addsale.component';
import { ShowsaleComponent } from './admin/showsale.component';
import { ShowsupplierComponent } from './admin/showsupplier.component';
import { AddsupplierComponent } from './admin/addsupplier.component';
import { AdddiscountComponent } from './admin/adddiscount.component';
import { ShowdiscountComponent } from './admin/showdiscount.component';
import { ShoworderComponent } from './admin/showorder.component';
import { ShowpurchasedComponent } from './admin/showpurchased.component';
import { ShowcartComponent } from './admin/showcart.component';
import { ShowbillComponent } from './admin/showbill.component';
import { ShowpaymentComponent } from './admin/showpayment.component';
import { ShowcontactComponent } from './admin/showcontact.component';
import { ShowfeedbackComponent } from './admin/showfeedback.component';
import { ShowreturnjewelleryComponent } from './admin/showreturnjewellery.component';
import { AdduserComponent } from './admin/adduser.component';
import { LoginComponent } from './login.component';
import { ForgotpasswordComponent } from './admin/forgotpassword.component';
import { MHeaderComponent } from './manager/m-header.component';
import { MIndexComponent } from './manager/m-index.component';
import { ManagerComponent } from './manager/manager.component';
import { MAddCertificateComponent } from './manager/m-add-certificate.component';
import { MAddDiamondComponent } from './manager/m-add-diamond.component';
import { MAddGoldComponent } from './manager/m-add-gold.component';
import { MAddSilverComponent } from './manager/m-add-silver.component';
import { MShowSilverComponent } from './manager/m-show-silver.component';
import { MShowGoldComponent } from './manager/m-show-gold.component';
import { MShowDiamondComponent } from './manager/m-show-diamond.component';
import { MShowCertificateComponent } from './manager/m-show-certificate.component';
import { EmployeeComponent } from './employee/employee.component';
import { EHeaderComponent } from './employee/e-header.component';
import { EIndexComponent } from './employee/e-index.component';
import { EAddJewelleryComponent } from './employee/e-add-jewellery.component';
import { EShowJewelleryComponent } from './employee/e-show-jewellery.component';
import { EShowDiscountComponent } from './employee/e-show-discount.component';
import { EAddDiscountComponent } from './employee/e-add-discount.component';
import { EAddEmployeeComponent } from './employee/e-add-employee.component';
import { EShowEmployeeComponent } from './employee/e-show-employee.component';
import { EAddSaleComponent } from './employee/e-add-sale.component';
import { EShowSaleComponent } from './employee/e-show-sale.component';
import { EShowSubtypejewelleryComponent } from './employee/e-show-subtypejewellery.component';
import { EAddSubtypejewelleryComponent } from './employee/e-add-subtypejewellery.component';
import { EShowBillComponent } from './employee/e-show-bill.component';
import { EShowContactusComponent } from './employee/e-show-contactus.component';
import { EShowFeedbackComponent } from './employee/e-show-feedback.component';
import { EShowOrderComponent } from './employee/e-show-order.component';
import { EShowPaymentComponent } from './employee/e-show-payment.component';
import { EShowPurchaseComponent } from './employee/e-show-purchase.component';
import { EShowUserComponent } from './employee/e-show-user.component';
import { EShowReturnjewelleryComponent } from './employee/e-show-returnjewellery.component';
import { EShowSupplierComponent } from './employee/e-show-supplier.component';
import { EAddSupplierComponent } from './employee/e-add-supplier.component';
import { CheckpasswordComponent } from './admin/checkpassword.component';
import { SignupComponent } from './admin/signup.component';
import { EAddReturnjewelleryComponent } from './employee/e-add-returnjewellery.component';
import { MAddJewelleryComponent } from './manager/m-add-jewellery.component';
import { MShowJewelleryComponent } from './manager/m-show-jewellery.component';
import { MAddSubtypejewelleryComponent } from './manager/m-add-subtypejewellery.component';
import { MShowSubtypejewelleryComponent } from './manager/m-show-subtypejewellery.component';
import { MAddUserComponent } from './manager/m-add-user.component';
import { MShowUserComponent } from './manager/m-show-user.component';
import { MShowSupplierComponent } from './manager/m-show-supplier.component';
import { MAddSupplierComponent } from './manager/m-add-supplier.component';






@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    HeaderComponent,
    AdminComponent,
    AddjewelleryComponent,
    AddemployeeComponent,
    AdddiamondComponent,
    AddsilverComponent,
    AddgoldComponent,
    AddcertificateComponent,
    ShowcertificateComponent,
    ShowgoldComponent,
    ShowsilverComponent,
    ShowdiamondComponent,
    ShowemployeeComponent,
    ShowjewelleryComponent,
    ShowregistrationComponent,
    AddsubtypejewelleryComponent,
    ShowsubtypejewelleryComponent,
    AddsaleComponent,
    ShowsaleComponent,
    ShowsupplierComponent,
    AddsupplierComponent,
    AdddiscountComponent,
    ShowdiscountComponent,
    ShoworderComponent,
    ShowpurchasedComponent,
    ShowcartComponent,
    ShowbillComponent,
    ShowpaymentComponent,
    ShowcontactComponent,
    ShowfeedbackComponent,
    ShowreturnjewelleryComponent,
    AdduserComponent,
    LoginComponent,
    ForgotpasswordComponent,
    MHeaderComponent,
    MIndexComponent,
    ManagerComponent,
    MAddCertificateComponent,
    MAddDiamondComponent,
    MAddGoldComponent,
    MAddSilverComponent,
    MShowSilverComponent,
    MShowGoldComponent,
    MShowDiamondComponent,
    MShowCertificateComponent,
    EmployeeComponent,
    EHeaderComponent,
    EIndexComponent,
    EAddJewelleryComponent,
    EShowJewelleryComponent,
    EShowDiscountComponent,
    EAddDiscountComponent,
    EAddEmployeeComponent,
    EShowEmployeeComponent,
    EAddSaleComponent,
    EShowSaleComponent,
    EShowSubtypejewelleryComponent,
    EAddSubtypejewelleryComponent,
    EShowBillComponent,
    EShowContactusComponent,
    EShowFeedbackComponent,
    EShowOrderComponent,
    EShowPaymentComponent,
    EShowPurchaseComponent,
    EShowUserComponent,
    EShowReturnjewelleryComponent,
    EShowSupplierComponent,
    EAddSupplierComponent,
    CheckpasswordComponent,
    SignupComponent,
    EAddReturnjewelleryComponent,
    MAddJewelleryComponent,
    MShowJewelleryComponent,
    MAddSubtypejewelleryComponent,
    MShowSubtypejewelleryComponent,
    MAddUserComponent,
    MShowUserComponent,
    MShowSupplierComponent,
    MAddSupplierComponent,
   
   

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
