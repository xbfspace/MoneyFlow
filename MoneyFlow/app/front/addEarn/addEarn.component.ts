import { Component, OnInit } from '@angular/core';

import {FrontService, EarnModel} from '../shared/front.service';

import { Observable }       from 'rxjs/Observable';
//引用jquery
//declare var $: any;
//var $ = require('jQuery');
//require('/app/testcssloader.css');
@Component({
    moduleId: module.id,
    templateUrl: 'addEarn.component.html',
    styleUrls: ['addEarn.component.css'],
    providers: [FrontService]
})

export class AddEarnComponent implements OnInit {
    model: EarnModel;
    constructor(private frontService: FrontService) {

    }

    ngOnInit() {
        this.model = new EarnModel();
    }
    
    onsubmit(model: EarnModel) {
        this.frontService.addEarn(this.model)
            .subscribe(
            data => {
                console.log('data:',data);
                alert('success');
            },
            error => {
                alert(error);
            });
    }

}