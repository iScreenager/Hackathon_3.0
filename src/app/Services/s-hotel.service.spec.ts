import { TestBed } from '@angular/core/testing';

import { SHotelService } from './s-hotel.service';

describe('SHotelService', () => {
  let service: SHotelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SHotelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
