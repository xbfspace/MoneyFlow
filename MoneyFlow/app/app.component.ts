import { Component } from '@angular/core';

@Component({
    selector:'app',
    template: `<div class="position:absolute;top:0;bottom:0">
                   <nav class="navbar navbar-default navbar-static-top">
                      <ul class="nav nav-pills" role="tablist">
                          <li role="presentation" routerLinkActive="active"><a routerLink="/recent">recent</a></li>
                          <li role="presentation" routerLinkActive="active"><a routerLink="/addPay">add pay</a></li>
                          <li role="presentation" routerLinkActive="active"><a routerLink="/addEarn">AddEarn</a></li>
                      </ul>
                   </nav>  
                   <div class="container-fluid">
                       <router-outlet></router-outlet>
                   </div> 
               </div>`
})

export class AppComponent{
    
}

//template: `<div class="position:absolute;top:0;bottom:0">
//                   <nav class="navbar navbar-default navbar-static-top">
//                       <div class="container-fluid">
//                           <div class="navbar-header">
//                              <div class="collapse navbar-collapse">
//                                  <ul class="nav navbar-nav">
//                                    <li class="active"><a routerLink="/recent">recentlist</a></li>
//                                    <li><a routerLink="/addPay">add pay</a></li>
//                                    <li><a routerLink="/addEarn">add earn</a></li>
//                                  </ul>
//                           </div>
//                       </div>
//                   </nav>  
//                   <div class="container-fluid">
//                       <router-outlet></router-outlet>
//                   </div> 
//               </div>`