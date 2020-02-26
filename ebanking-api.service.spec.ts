import { TestBed } from '@angular/core/testing';

import { EBankingApiService } from './ebanking-api.service';

describe('CanApiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: EBankingApiService = TestBed.get(EBankingApiService);
    expect(service).toBeTruthy();
  });
});
