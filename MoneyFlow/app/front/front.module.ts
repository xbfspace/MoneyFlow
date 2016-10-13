import { NgModule }       from '@angular/core';
import { CommonModule }   from '@angular/common';
import { FormsModule }    from '@angular/forms';

import { RecentComponent }    from './component/recent.component';
import { AddPayComponent }  from './component/addPay.component';
import { AddEarnComponent }  from './component/addEarn.component';
//import { HeroService } from './hero.service';
import { FrontRoutingModule } from './front-routing.module';
@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        FrontRoutingModule
    ],
    declarations: [
        RecentComponent,
        AddPayComponent,
        AddEarnComponent
    ],
    providers: [
        //HeroService
    ]
})
export class FrontModule { }