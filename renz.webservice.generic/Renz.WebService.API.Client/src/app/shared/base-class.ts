/// https://stackoverflow.com/a/43367791/1035039
// https://medium.com/@benlesh/rxjs-dont-unsubscribe-6753ed4fda87

import { Directive, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';


@Directive()
export abstract class BaseClass implements OnDestroy {
    protected stop$: Subject<boolean>;
    constructor() {
        this.stop$ = new Subject<boolean>();
        let f = this.ngOnDestroy;
        this.ngOnDestroy = () => {
            f.bind(this)();
            this.stop$.next(true);
            this.stop$.complete();
        };
    }
    /// placeholder of ngOnDestroy. no need to do super() call of extended class.
    ngOnDestroy() { }
}