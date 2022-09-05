import { PrivacyPolicyComponent } from './client/privacy-policy.component';
import { FaqsComponent } from './client/faqs.component';
import { AboutusComponent } from './client/aboutus.component';
import { RegistrationComponent } from './client/registration.component';
import { UserAccountComponent } from './client/user-account.component';
import { WishlistComponent } from './client/wishlist.component';
import { CartComponent } from './client/cart.component';
import { ContactusComponent } from './client/contactus.component';
import { LoginComponent } from './client/login.component';
import { IndexComponent } from './client/index.component';
import { ClientComponent } from './client/client.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowJewelleryComponent } from './client/show-jewellery.component';
import { ShowSubtypejewelleryComponent } from './client/show-subtypejewellery.component';
import { ProductDetailsComponent } from './client/product-details.component';
import { AuthGuard } from './services/auth.guard';
import { ThankupageComponent } from './client/thankupage.component';

const routes: Routes = [
  {path:'',redirectTo:'/client',pathMatch:'full'},
  {
    path:'client' ,component:ClientComponent , children:[
      {path:'' , component:IndexComponent,runGuardsAndResolvers: "always",},

      {path:'aboutus' , component:AboutusComponent},
      {path:'login' , component:LoginComponent},
      {path:'contactus' , component:ContactusComponent},

      {path:'cart',component:CartComponent,canActivate:[AuthGuard]},

      {path:'wishlist',component:WishlistComponent,canActivate:[AuthGuard]},
      {path:'myaccount',component:UserAccountComponent},

      {path:'showjewellery',component:ShowJewelleryComponent},
      {path:'showsubjewellery/:id',component:ShowSubtypejewelleryComponent},

      {path:'productdetails/:id',component:ProductDetailsComponent},
      {path:'updatecart/:id',component:ProductDetailsComponent},

      {path:'registration' , component:RegistrationComponent},
      {path:'edituser/:id',component:RegistrationComponent},
      {path:'faqs' , component:FaqsComponent},
      {path:'privacypolicy' , component:PrivacyPolicyComponent},
      {path:'ordersucess',component:ThankupageComponent}

    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
