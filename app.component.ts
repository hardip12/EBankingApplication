import { Component } from '@angular/core';
import { LoginService } from './Service/login.service';
import { RegisterService } from './Service/register.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'EBanking';
  constructor(private _loginService: LoginService, private _registerService: RegisterService) { }
}
