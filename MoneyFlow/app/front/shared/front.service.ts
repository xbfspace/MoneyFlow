import {Injectable} from '@angular/core';

@Injectable()
export class FrontService {
    addEarn(model: EarnModel) {
        alert('添加收入成功');
    }
}

export class EarnModel {
    id: number;
    amount: number;
    content: string;
    payDate: string;

    constructor() {

    }
}

