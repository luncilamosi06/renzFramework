import { NgModule } from '@angular/core';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { GenericAddressComponent } from './components/generic-address/generic-address.component';

@NgModule({
    declarations: [GenericAddressComponent],
    imports: [
      SweetAlert2Module
    ],
    exports: [
      SweetAlert2Module
    ]
  })
  export class SharedModule { }