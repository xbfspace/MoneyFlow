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
            { path: '', redirectTo: 'index', pathMatch: 'full' },
            { path: 'index', component: IndexComponent },
            { path: 'addPay', component: AddPayComponent },
            { path: 'addEarn', component: AddEarnComponent },
            { path: 'query', component: QueryComponent },
            { path: 'query-result', component: QueryResultComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class FrontRoutingModule { }