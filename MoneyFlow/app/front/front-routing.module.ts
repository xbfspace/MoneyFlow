import { NgModule }     from '@angular/core';
import { RouterModule } from '@angular/router';



import {IndexComponent} from './index/index.component';
import { AddPayComponent }  from './addPay/addPay.component';
import { AddEarnComponent }  from './addEarn/addEarn.component';
import { QueryComponent }    from './query/query.component';
import { QueryResultComponent }    from './queryResult/query-result.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', redirectTo: 'home/index', pathMatch: 'full' },
            { path: 'home', redirectTo: 'home/index', pathMatch:'full' },
            { path: 'home/index', component: IndexComponent },
            { path: 'home/addPay', component: AddPayComponent },
            { path: 'home/addEarn', component: AddEarnComponent },
            { path: 'home/query', component: QueryComponent },
            { path: 'home/query-result', component: QueryResultComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class FrontRoutingModule { }