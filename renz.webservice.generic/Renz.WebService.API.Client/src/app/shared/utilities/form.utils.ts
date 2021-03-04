import { Injectable } from "@angular/core";
import { FormGroup, ValidationErrors, AbstractControl } from '@angular/forms';

@Injectable()
export default class FormUtils {
    constructor() { }

    static formsAreDirty(jsonForms: any): boolean {
        if (!jsonForms) return false;

        for (let key in jsonForms) {
            if (jsonForms.hasOwnProperty(key) && jsonForms[key] instanceof FormGroup) {
                let isDirty: boolean = (jsonForms[key] as FormGroup).dirty;

                if (isDirty) return true;
            }
        }

        return false;
    }

    public static matchValues(
        matchTo: string // name of the control to match to
    ): (AbstractControl) => ValidationErrors | null {
        return (control: AbstractControl): ValidationErrors | null => {
            return !!control.parent &&
                !!control.parent.value &&
                control.value === control.parent.controls[matchTo].value
                ? null
                : { isMatching: false };
        };
    }
}
