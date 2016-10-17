import { Component, OnInit } from '@angular/core';

import {FrontService, EarnModel} from '../shared/front.service';

import { Observable }       from 'rxjs/Observable';
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
        this.model.id = 0;
        this.model.amount = 0;
        this.model.content = '';
    }

    addEarn(model: EarnModel) {
        //this.frontService.addEarn(model)
        //    .subscribe(
        //    hero => {
        //        alert('success');
        //    },
        //    error => {
        //        alert(error);
        //    });

        this.frontService.getEarn(1)
            .subscribe(
            hero => {
                alert('success');
            },
            error => {
                alert(error);
            });
    }

}