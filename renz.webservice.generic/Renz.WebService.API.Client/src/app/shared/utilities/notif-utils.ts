import { Injectable } from "@angular/core";
import swal, { SweetAlertOptions } from 'sweetalert2';

@Injectable()
export default class NotifUtils{
    static showNotice(
        options: string | SweetAlertOptions,
        defaults: SweetAlertOptions,
        callback: () => any = null,
        cancelCallBack: () => any = null): void {

        let opts: any = {};
        if (options && typeof options === "string") {
            opts.html = options as string;
        }

        Object.assign(opts, defaults, options || {});

        swal.fire(opts).then((result) => {
            if (callback && result.value) {
                setTimeout(callback);
            }
            else if (cancelCallBack && !result.value) {
                setTimeout(cancelCallBack);
            }
        });
    }

    static showConfirmMessage(options: string | SweetAlertOptions, callback: () => any = null, cancelCallback: () => any = null): void {
        let defaults: any = {
            title: 'Confirmation',
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes',
            cancelButtonText: 'No',
        };
        this.showNotice(options, defaults, callback, cancelCallback);
    }

    static showSuccess(options: string | SweetAlertOptions, callback: () => any = null): void {
        let defaults: any = {
            icon: "success"
        };
        this.showNotice(options, defaults, callback);
    }

    static showError(options: string | SweetAlertOptions, callback: () => any = null): void {
        let defaults: any = {
            title: 'Oops...',
            icon: "error"
        };
        this.showNotice(options, defaults, callback);
    }

    static showWarning(options: string | SweetAlertOptions, callback: () => any = null): void {
        let defaults: any = {
            icon: "warning"
        };
        this.showNotice(options, defaults, callback);
    }

    static showInfo(options: string | SweetAlertOptions, callback: () => any = null): void {
        let defaults: any = {
            icon: "info"
        };
        this.showNotice(options, defaults, callback);
    }
}