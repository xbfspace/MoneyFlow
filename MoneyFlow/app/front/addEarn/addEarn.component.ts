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
        this.model.Id = 1;
        this.model.Amount = 100.01;
        this.model.Content = "胡说八道";
        this.model.EarnDate = '2016-09-10';
    }

    addEarn(model: EarnModel) {
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