import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RegisterSave } from '../register/register.interface';
import { EBankingApiService } from '../core/service/ebanking-api.service';
import { Observable, of } from 'rxjs';
import { delay, map } from 'rxjs/operators';
import { AsyncValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';


@Injectable()
export class RegisterService {
  constructor(private http: HttpClient,private ebankingApi: EBankingApiService) {}

  emailValidator(): AsyncValidatorFn {
    return (control: AbstractControl): Observable<ValidationErrors | null> => {
      return this.ValidateEnterpriseId(control.value).pipe(
        map(res => {
          // if res is true, username exists, return true
          return res ? { emailExists: true } : null;
          // NB: Return null if there is no error
        })
      );
    };
  }
  ValidateEnterpriseId(emailId:string) {
     return  this.ebankingApi.get('/CustomerDetails/ValidateEmailId/'+ emailId);
   }
  Submit(data:RegisterSave) {
    return this.ebankingApi.post('/CustomerDetails/SaveCustomerDetails', data);
  }
  
}
