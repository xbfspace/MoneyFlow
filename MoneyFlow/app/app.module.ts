import { NgModule }       from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule }    from '@angular/forms';


import { AppComponent }      from './app.component';
import { AppRoutingModule }  from './app-routing.module';
import { FrontModule }         from './front/front.module';



@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        FrontModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent

    ],
    bootstrap: [AppComponent]
})
export class AppModule {
}