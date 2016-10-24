import { NgModule }       from '@angular/core';
import { CommonModule }   from '@angular/common';
import { FormsModule }    from '@angular/forms';
import { HttpModule } from '@angular/http';



import { IndexComponent} from './index/index.component';
import { AddPayComponent }  from './addPay/addPay.component';
import { AddEarnComponent }  from './addEarn/addEarn.component';
import { QueryComponent }    from './query/query.component';
import { QueryResultComponent }    from './queryResult/query-result.component';
//import { HeroService } from './hero.service';
import { FrontRoutingModule } from './front-routing.module';

import { UxDatePickerDirective } from '../shared/uxDatePicker.directive';
@NgModule({
    imports: [
        CommonModule, 
        FormsModule,
        HttpModule,
        FrontRoutingModule
    ],
    declarations: [
        IndexComponent,
        AddPayComponent,
        AddEarnComponent,
        QueryComponent,
        QueryResultComponent,
        UxDatePickerDirective
    ],
    providers: [
        //HeroService
    ]
})
export class FrontModule { }