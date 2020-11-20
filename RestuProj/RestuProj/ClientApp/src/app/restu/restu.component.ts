import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GetlistsService } from '../services/getlists.service';


@Component({
  selector: 'app-restu',
  templateUrl: './restu.component.html',
  styleUrls: ['./restu.component.css']
})
export class RestuComponent implements OnInit {

  customers: any[];
  paymentMethods: any[];
  FoodTypes: any[];
  Order: any = {};
  OrderDetail: any = {};
  TotalPrice = 0;
  OrderDetails: any[] = [];
  mydata: any = {};

  people = [true, 'Two', 3];


  constructor(private getservice: GetlistsService, private http: HttpClient) { }

  ngOnInit() {

    this.Order.TotalPrice = 0;

    this.getservice.getAllCustomers().subscribe((data: any[]) => {
      this.customers = data;

      this.getservice.getPamentTypes().subscribe((data: any[]) => {
        this.paymentMethods = data;

        this.getservice.getFoodTypes().subscribe((data: any[]) => {
          this.FoodTypes = data;
        });

      });
    });
  }

  getFoodPrice(event) {
    this.OrderDetail.FoodName = event.target.options[event.target.options.selectedIndex].text;
    this.getservice.getFoodPrice(this.OrderDetail.FoodID).subscribe((data: any) => {
      this.OrderDetail.Price = data.unitPrice;
    });
  }


  AddOrderDetails() {
    this.OrderDetail.TotalPrice = this.OrderDetail.Price * this.OrderDetail.Quantity;
    this.Order.TotalPrice += this.OrderDetail.TotalPrice;
    this.OrderDetails.push(this.OrderDetail);
    this.OrderDetail = { TotalPrice: 0 };
  }

  deleteItem(id) {
    this.Order.TotalPrice -= this.OrderDetails[this.OrderDetails.findIndex(g => g.FoodID == id)].TotalPrice;
    this.OrderDetails.splice(this.OrderDetails.findIndex(g => g.FoodID == id), 1);
  }


  SaveOrder() {

    console.log(this.Order);
    this.http.post("/api/Orders", this.Order).subscribe(res => { console.log('sjnj') });


  }



}
