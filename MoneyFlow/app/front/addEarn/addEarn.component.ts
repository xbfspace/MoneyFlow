import { Component, OnInit } from '@angular/core';

import {FrontService, EarnModel} from '../shared/front.service';

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
        alert('id:' + model.id + ' content:' + model.content + ' amount:' + model.amount);
        //this.frontService.addEarn(model);
    }

}