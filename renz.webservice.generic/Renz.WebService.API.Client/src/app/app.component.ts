import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ItemDTO, Service } from 'src/api.weight.generated';
import { BaseComponent } from './shared/base-component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent extends BaseComponent implements OnInit {

  title = 'Weight Calculator';
  
  editField: string;
  itemList: Array<any>;
  itemDTO: ItemDTO;
  // = [
  //   { id: 1, name: 'Item 1', weight: 30, totalCost: 450 },
  //   { id: 2, name: 'Item 2', weight: 40, totalCost: 400 },
  //   { id: 3, name: 'Item 3', weight: 25, totalCost: 375 },
  // ];

  awaitingPersonList: Array<any> = [
    { id: 4, name: 'Item 4', weight: 30, totalCost: 450 },
    { id: 5, name: 'Item 5', weight: 40, totalCost: 400 },
    { id: 6, name: 'Item 6', weight: 25, totalCost: 375 },
  ];

  constructor(private genericService: Service) { 
      super();
  }
  ngOnInit() {
    let x = this.genericService.itemAll().subscribe((res)=>{
      this.itemList = res;
    });
  }
    
    updateList(id: number, itemId: number, property: string, event: any) {
      console.log("Changing");
      const editField = event.target.textContent;
      this.itemList[id][property] = editField;
      let item = JSON.parse(JSON.stringify(this.itemList.filter(x => x.id === itemId)));
      this.genericService.item3(itemId, item[0]).subscribe();
    }

    remove(id: any) {
      this.genericService.item4(id).subscribe();
      this.awaitingPersonList.push(this.itemList[id]);
      this.itemList.splice(id, 1);
    }

    add() {
      if (this.awaitingPersonList.length > 0) {
        const person = this.awaitingPersonList[0];
        this.itemList.push(person);
        this.awaitingPersonList.splice(0, 1);
      }
    }

    changeValue(id: number, itemId: number, property: string, event: any) {
      this.editField = event.target.textContent;
    }
}
