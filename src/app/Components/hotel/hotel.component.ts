import { Component, OnInit } from '@angular/core';

import { IMenuItems } from 'src/app/Models/ihotel;

import { SFriendsService } from 'src/app/Services/s-hotel.service';

@Component({

  selector: 'app-main',

  templateUrl: './main.component.html',

  styleUrls: ['./main.component.css'],

})

export class MainComponent implements OnInit {

  menuItemsDetails: IMenuItems[] = []; //empty array of type contact model

  selectedItem : IMenuItems ={} as IMenuItems;

  title = 'Menu Items';

  constructor(private service: SFriendsService) {}

  ngOnInit(): void {

    this.getDataFromServer();

  }
  getDataFromServer() {

    let observable = this.service.getAllItems();

    observable.subscribe((data) => {

      this.menuItemsDetails = data;

    });

  }
  getItemById(id:number){

    this.service.getItem(id).subscribe((data:IMenuItems)=>{

      this.selectedItem = data;

    });

  }




 

}


