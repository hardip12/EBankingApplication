import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
//import { CustomMaterialModule } from './Core/material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginService } from './Service/login.service';
import { HttpClientModule } from '@angular/common/http';

import { AngularMaterialModule } from './Shared/angular-material.module';
import { CustomerdetailsComponent } from './customerdetails/customerdetails.component';
import { RegisterService } from './Service/register.service';
import { EBankingApiService } from './core/service/ebanking-api.service';
import { ConfirmEqualValidatorDirective } from './Shared/confirm-equal-validator.directive';
//import { ExistingEmailValidatorDirective } from './Shared/Existing-email-validator.directive';
// import {CustomAsyncValidatorDirective} from './Shared/AsyncValidator.directive';
// import {  ExistingEmailValidatorDirective } from './Shared/CustomAsyncEmail.directive';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    CustomerdetailsComponent,
    ConfirmEqualValidatorDirective
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AngularMaterialModule,
    HttpClientModule,
    FlexLayoutModule,
    FormsModule, ReactiveFormsModule, BrowserAnimationsModule
  ],
  providers: [LoginService,RegisterService,EBankingApiService],
  bootstrap: [AppComponent]
  ,
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
