import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, AbstractControl, ValidatorFn, ValidationErrors, AsyncValidatorFn, AbstractControlOptions } from '@angular/forms';

import { RouteConfigLoadEnd, Router } from '@angular/router';
import { errorMessages, CustomValidators } from '../Shared/CustomValidation.module';
import { RegisterService } from '../Service/register.service';
import { RegisterSave } from './register.interface';
//import { ValidateEmailNotTaken } from '../Shared/asyn-emailnottaken-validator';

import { debounceTime, map } from 'rxjs/operators';
import { Observable } from 'rxjs/internal/Observable';
//import { existingEmailValidator } from '../Shared/Existing-email-validator.directive';

// import { existingEmailValidator } from '../Shared/CustomAsyncEmail.directive';



@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userRegistrationForm: FormGroup;
  hide = true;
  apiRequest: RegisterSave;

  constructor(private router: Router, private _registerService: RegisterService) {
    this.userRegistrationForm = new FormGroup({
      email: new FormControl('', Validators.compose([
        Validators.required,
        Validators.email
        
        
        
        //  Validators.pattern("^[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}$")
        //Validators.email,ValidateEmailNotTaken.createValidator.bind(ValidateEmailNotTaken)
      ]),[this._registerService.emailValidator()]

      ),
      password: new FormControl('', Validators.compose([
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15),
        // Validators.pattern("^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$"),
        Validators.pattern("(?=(.*[A-Za-z0-9]){3})(?=(.*[A-Z]){3})(?=(.*[a-z]){3})(?=(.*[0-9]))(?=(.*[@#])).+")

      ])),
      confirmpassword: new FormControl('', Validators.compose([
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15)
        

      ])),

    })

  }
  
  //  ValidateEnterpriseId(control: AbstractControl) {
  //      return this._registerService.checkEmailNotTaken(control.value).subscribe(res => {
  //        return res ? null : { emailTaken: true };
  //      });
  //    }

  errors = errorMessages;
  Submit() {

    if (this.email.valid && this.password.valid && this.confirmpassword.valid) {
      this.apiRequest = {
        email: this.email.value,
        password: this.password.value,
        confirmpassword: this.confirmpassword.value

      };
      console.log(this.apiRequest);
      this._registerService.Submit(this.apiRequest)
        .subscribe((success) => {
          if (success) {
            this.router.navigateByUrl('/login');
          }
          else {
            alert("failed");
          }
        },
          (error) => {
            alert("error");
          }
        );
    }
  }



  get email() {
    
    return this.userRegistrationForm.get('email')
  }
  get password() {
    return this.userRegistrationForm.get('password')
  }

  get confirmpassword() {
    return this.userRegistrationForm.get('confirmpassword')
  }

  //   validateNameViaServer({value}: AbstractControl): Observable<ValidationErrors | null> {
  //     this._registerService.ValidateEnterpriseId(value)
  //     .pipe(debounceTime(500), map((nameExists: boolean) => {
  //         if (nameExists) {
  //             return {
  //                 isExists: true
  //             };
  //         }
  //         return null;
  //     }))
  // }

  ngOnInit(): void {

    //this.userRegistrationForm.controls['email'].setAsyncValidators(ValidateEmailNotTaken.createValidator(this._registerService,this.email));
  }

}
