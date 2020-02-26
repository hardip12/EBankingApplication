import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { LoginService } from '../Service/login.service';
import { errorMessages } from '../Shared/CustomValidation.module';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userLoginForm: FormGroup;
  isSubmitted: boolean;
  EnterpriseId: any;
  constructor(private router: Router,private _loginService: LoginService) { 
    this.userLoginForm = new FormGroup({
      email: new FormControl('', Validators.compose([
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(15),
        Validators.email
       
      ])),
      password: new FormControl('', Validators.compose([
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15)
         
      ]))
    
      
    })
  }
  
  errors = errorMessages;
  
  ngOnInit(): void {
    //this.getEnterpriseId();
  }
   login() : void {
    console.log(this.userLoginForm.value);
   
    if(this.userLoginForm.invalid){
      
      return;
    }
    
    //this.authService.login(this.userLoginForm.value);
    //this.router.navigateByUrl('/admin');
     this.router.navigateByUrl('/customerdetails');
   }
  //  getEnterpriseId() {
  //     this._loginService.getEnterpriseId().subscribe(
  //         data => { this.EnterpriseId = data},
  //         err => console.error(err),
  //         () => console.log('done loading emailIds')
  //       );
  //    }
   get email()
   {
     return this.userLoginForm.get('email')
   }
   get password()
   {
     return this.userLoginForm.get('password')
   }
   
}
