import { FormGroup, FormControl, FormGroupDirective, NgForm, ValidatorFn } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core/typings';

export class CustomValidators {
}


export const errorMessages: { [key: string]: string } = {

    required: 'Field is Mandatory',
    email: 'Email must be a valid email address (username@domain)',
    password: 'Password should contain at least one number ,one special character ,atleast 3 small characters and atleast 3 Capital letters',
    confirmpassword: 'Passwords must match',
    minlength: "It should be 3 characters long",
    maxlength: "It should not be more than 15 characters",
    emailExists: "Email is already taken"
};
