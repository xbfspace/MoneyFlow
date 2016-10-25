import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

import {FrontService, EarnModel} from '../shared/front.service';
import { Observable }       from 'rxjs/Observable';
//引用jquery
declare var $: any;
//css
require('webroot/Content/plugins/datepicker/css/datePicker.css');
//js
require('webroot/Content/plugins/datepicker/js/require/iscroll.js');
require('webroot/Content/plugins/datepicker/js/datepicker.js');
@Component({
    moduleId: module.id,
    templateUrl: 'addEarn.component.html',
    styleUrls: ['addEarn.component.css'],
    providers: [FrontService]
})

export class AddEarnComponent implements OnInit {
    addEarnForm: FormGroup;
    model:EarnModel;
    constructor(private frontService: FrontService, private fb: FormBuilder) {

    }

    ngOnInit(): void {
        let that = this;
        $('#date').datePicker({
            theme: 'date',
            callBack: function (val) {
                that.onSelected(val);
            }
        });
        this.model = new EarnModel();
        this.buildForm();
    }

    onSubmit() {
        this.model = this.addEarnForm.value;
        this.frontService.addEarn(this.model)
            .subscribe(
            data => {
                console.log('data:', data);
                alert('success');
            },
            error => {
                alert(error);
            });
    }

    buildForm(): void {
        this.addEarnForm = this.fb.group({
            'Amount': [this.model.Amount, [
                Validators.required,
                Validators.maxLength(10)
            ]],
            'Content': [this.model.Content, [
                Validators.required
            ]],
            'EarnDate': [this.model.EarnDate, [
                Validators.required
            ]]
        });

        this.addEarnForm.valueChanges.subscribe(data => {
            this.onValueChanged(data);
        });

        this.onValueChanged(); // (re)set validation messages now
    }

    onValueChanged(data?: any) {
        if (!this.addEarnForm) { return; }
        const form = this.addEarnForm;
        for (const field in this.formErrors) {
            // clear previous error message (if any)
            this.formErrors[field] = '';
            const control = form.get(field); 
            if (control && control.dirty && !control.valid) {
                const messages = this.validationMessages[field];
                for (const key in control.errors) {
                    this.formErrors[field] += messages[key] + '';
                }
            }
        }
    }

    formErrors = {
        'Content': '',
        'Amount': '',
        'EarnDate':''
    }

    validationMessages = {
        'Content': {
            'required':'备注不能为空'
        },
        'Amount': {
            'required': '金额不能为空',
            'maxlength':'金额长度不能超过10位'
        },
        'EarnDate': {
            'required':'日期不能为空'
        }
    };

    datePickerOptions = {
        theme: 'date'
    };

    onSelected(val) {
        this.addEarnForm.get('EarnDate').setValue(val);
    }
}