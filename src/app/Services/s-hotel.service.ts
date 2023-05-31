import { Injectable } from '@angular/core';
import { IMenuItems } from '../Models/ihotel';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';


@Injectable({

  providedIn: 'root',

})
export class SFriendsService {

  url = 'http://localhost:3000/Hotel';

  constructor(private http: HttpClient) {}
  getAllItems(): Observable<IMenuItems[]> {
    return this.http.get<IMenuItems[]>(this.url);

  }
  public getItem(id: number): Observable<IMenuItems> {
    const tempUrl = this.url + '/' + id;
    return this.http.get<IMenuItems>(tempUrl);

  }

}


@Injectable({
  providedIn: 'root'
})
export class SHotelService {

  url = 'http://localhost:3000/Hotel';
  constructor(private http: HttpClient) {}
  getAllItems(): Observable<IMenuItems[]> {
    return this.http.get<IMenuItems[]>(this.url);
  }

  public getItem(id: number): Observable<IMenuItems> {
    const tempUrl = this.url + '/' + id;
    return this.http.get<IMenuItems>(tempUrl);

  }
}
