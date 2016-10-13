import { NgModule }     from '@angular/core';
import { RouterModule } from '@angular/router';
import { RecentComponent }    from './component/recent.component';
import { AddPayComponent }  from './component/addPay.component';
import { AddEarnComponent }  from './component/addEarn.component';
@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', component: RecentComponent },
            { path: 'recent', component: RecentComponent },
            { path: 'addPay', component: AddPayComponent },
            { path: 'addEarn', component: AddEarnComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class FrontRoutingModule { }