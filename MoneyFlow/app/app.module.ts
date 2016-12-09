import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule }    from '@angular/forms';


import { AppComponent }      from './app.component';
import { AppRoutingModule }  from './app-routing.module';
import { FrontModule }         from './front/front.module';
import { FavorsModule } from './favors/favors.module';



@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        ReactiveFormsModule,
        FrontModule,
        FavorsModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent

    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}