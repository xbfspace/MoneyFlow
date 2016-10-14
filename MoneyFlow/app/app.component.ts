import { Component } from '@angular/core';

@Component({
    selector:'app',
    template: `<div class="container-fluid">
                       <router-outlet></router-outlet>
               </div> `
})

export class AppComponent{
    
}

//template: `<div class="position:absolute;top:0;bottom:0">
//                   <nav class="navbar navbar-default navbar-static-top">
//                      <ul class="nav nav-pills" role="tablist">
//                          <li role="presentation" routerLinkActive="active"><a routerLink="/recent">recent</a></li>
//                          <li role="presentation" routerLinkActive="active"><a routerLink="/addPay">add pay</a></li>
//                          <li role="presentation" routerLinkActive="active"><a routerLink="/addEarn">AddEarn</a></li>
//                      </ul>
//                   </nav>  
//                   <div class="container-fluid">
//                       <router-outlet></router-outlet>
//                   </div> 
//               </div>`
//})
