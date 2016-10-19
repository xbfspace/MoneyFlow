import {Injectable} from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { Observable }       from 'rxjs/Observable';


@Injectable()
export class FrontService {
    constructor(private http: Http) {

    }

    addEarn(model: EarnModel): Observable<string> {
        model = new EarnModel();
        model.Id = 1;
        model.Amount = 100.01;
        model.Content = "胡说八道";
        model.EarnDate = '2016-09-10';
        let body = JSON.stringify(model);
        let headers = new Headers({
            'Content-type':'application/json'
        });
        let options = new RequestOptions({
            headers: headers
        });

        return this.http.post('/api/Earn/AddEarn', body, options)
            .map(this.extractData)
            .catch(this.handleError);
    }

    getEarn(id: number) {
        return this.http.get('/api/Earn/GetEarn?id=' + id)
            .map(this.extractData)
            .catch(this.handleError);
                 
    }

    private extractData(res: Response) {
        console.log('response:',res);
        let body = res.json();
        return body.data || {};
    }
    private handleError(error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
            error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}

export class EarnModel {
    Id: number;
    Amount: number;
    Content: string;
    EarnDate: string;

    constructor() {

    }
}

