import { Directive, Output, Input, ElementRef, EventEmitter } from '@angular/core';

//css
require('webroot/Content/plugins/datepicker/css/datePicker.css');
//js
//another require is global jquery
require('webroot/Content/plugins/datepicker/js/require/iscroll.js');
require('webroot/Content/plugins/datepicker/js/datepicker.js');

declare var $: any;

@Directive({
    selector:'[uxDatePicker]'
})
export class UxDatePickerDirective {
    @Input("uxDatePicker") options: Object
    constructor(private el: ElementRef) {
        if (!this.options) {
            this.options = {theme:'date'};
        }
        if (!this.options['theme']) {
            this.options['theme'] = 'date';
        }
        $(el.nativeElement).datePicker(this.options);
    }
}