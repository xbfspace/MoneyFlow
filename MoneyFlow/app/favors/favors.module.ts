import { NgModule }       from '@angular/core';
import { CommonModule }   from '@angular/common';
import { FormsModule, ReactiveFormsModule }    from '@angular/forms';
import { HttpModule } from '@angular/http';



import { IndexComponent} from './index/index.component';
import { FavorsRoutingModule } from './favors-routing.module';


@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpModule,
        FavorsRoutingModule
    ],
    declarations: [
        IndexComponent
    ],
    providers: [
        //HeroService
    ]
})
export class FavorsModule { }