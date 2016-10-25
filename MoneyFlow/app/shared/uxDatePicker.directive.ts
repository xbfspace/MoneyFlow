import { OnChanges, OnInit, Directive, Output, Input, ElementRef, EventEmitter } from '@angular/core';

//css
require('webroot/Content/plugins/datepicker/css/datePicker.css');
//js
//another require is global jquery
require('webroot/Content/plugins/datepicker/js/require/iscroll.js');
require('webroot/Content/plugins/datepicker/js/datepicker.js');

declare var $: any;

@Directive({
    selector: '[uxDatePicker]'
})
export class UxDatePickerDirective implements OnInit, OnChanges {
    @Input() value: string;
    @Input("uxDatePicker") options: Object
    @Output() onSelected = new EventEmitter <string>();
    constructor(private el: ElementRef) {

    }
    ngOnInit() {
        if (!this.options) {
            this.options = { theme: 'date' };
        }
        if (!this.options['theme']) {
            this.options['theme'] = 'date';
        }
        $(this.el.nativeElement).datePicker(this.options);
    }

    ngOnChanges() {
        if (this.value != '') {
            alert('1');
            this.onSelected.emit(this.value);
        }
        else {
            alert('2');
        }
    }
}