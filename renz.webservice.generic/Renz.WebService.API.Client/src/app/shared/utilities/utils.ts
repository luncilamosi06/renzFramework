import { Injectable } from '@angular/core';
import swal, { SweetAlertOptions } from 'sweetalert2';

@Injectable()
export default class Utils {
    static blockUI(): void {
        swal.fire({
            title: "Please wait",
            allowOutsideClick: false,
            allowEscapeKey: false,
            showConfirmButton: false
        });
        swal.showLoading();
    }

    static unblockUI(): void {
        swal.close();
    }
}