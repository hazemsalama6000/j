import { TestBed } from '@angular/core/testing';

import { GetlistsService } from './getlists.service';

describe('GetlistsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: GetlistsService = TestBed.get(GetlistsService);
    expect(service).toBeTruthy();
  });
});
