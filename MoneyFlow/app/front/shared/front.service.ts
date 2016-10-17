import {Injectable} from '@angular/core';
import { Http, Response } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';
import { Observable }       from 'rxjs/Observable';


@Injectable()
export class FrontService {
    private payApiUrl = 'http://null:8030/api/pay';

    constructor(private http: Http) {

    }

    addEarn(model: EarnModel): Observable<string> {
        let body = JSON.stringify(model);
        let headers = new Headers({
            'Content-type':'application/json'
        });
        let options = new RequestOptions({
            headers: headers
        });
        return this.http.post(this.payApiUrl, body, options)
            .map(this.extractData)
            .catch(this.handleError);
            
    }

    getEarn(id: number) {
        //let body = JSON.stringify({ id: id });
        //let options = new RequestOptions({
        //    body: body,
             
           
        //});
        return this.http.get(this.payApiUrl)
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
    id: number;
    amount: number;
    content: string;
    payDate: string;

    constructor() {

    }
}

