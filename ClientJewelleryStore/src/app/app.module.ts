import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './client/header.component';
import { IndexComponent } from './client/index.component';
import { ClientComponent } from './client/client.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { LoginComponent } from './client/login.component';
import { ContactusComponent } from './client/contactus.component';

import { ShowJewelleryComponent } from './client/show-jewellery.component';
import { ShowSubtypejewelleryComponent } from './client/show-subtypejewellery.component';
import { CartComponent } from './client/cart.component';
import { WishlistComponent } from './client/wishlist.component';
import { UserAccountComponent } from './client/user-account.component';
import { ProductDetailsComponent } from './client/product-details.component';
import { RegistrationComponent } from './client/registration.component';
import { AboutusComponent } from './client/aboutus.component';
import { FaqsComponent } from './client/faqs.component';
import { PrivacyPolicyComponent } from './client/privacy-policy.component';
import { ThankupageComponent } from './client/thankupage.component';






@NgModule({
  declarations: [
    AppComponent,
    ClientComponent,
    HeaderComponent,
    IndexComponent,
    LoginComponent,
    ContactusComponent,
    ShowJewelleryComponent,
    ShowSubtypejewelleryComponent,
    CartComponent,
    WishlistComponent,
    UserAccountComponent,
    ProductDetailsComponent,
    RegistrationComponent,
    AboutusComponent,
    FaqsComponent,
    PrivacyPolicyComponent,
    ThankupageComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
