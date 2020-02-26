import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable()
export class EBankingApiService extends ApiService {

  constructor(http: HttpClient) {
    super(http, environment.apiUrl);
  }
}
