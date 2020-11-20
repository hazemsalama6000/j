import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GetlistsService {

  constructor(private httpclient: HttpClient) { }


  getAllCustomers() {
    return this.httpclient.get("api/Customers");
  }

  getPamentTypes() {
    return this.httpclient.get("api/PaymentTpes");
  }

  getFoodTypes() {
    return this.httpclient.get("api/Food");
  }

  getFoodPrice(ID) {
    return this.httpclient.get("api/Food/" + ID);
  }

}
