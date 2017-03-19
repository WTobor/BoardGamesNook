"use strict";
const http_1 = require('@angular/http');
const Observable_1 = require('rxjs/Observable');
require('rxjs/Rx');
class HttpHelpers {
    constructor(_http) {
        this._http = _http;
    }
    get haserror() {
        return this.errormsg != null;
    }
    getaction(path) {
        return this._http.get(path)
            .map(res => {
            return res.json();
        })
            .catch(this._handleError);
    }
    postaction(param, path) {
        this.errormsg = null;
        let body = JSON.stringify(param);
        let headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        let options = new http_1.RequestOptions({ headers: headers });
        return this._http.post(path, body, options)
            .map(m => {
            var jsonresult = m.json();
            if (jsonresult.haserror) {
                this.errormsg = jsonresult.errormessage;
            }
            return jsonresult;
        })
            .catch(this._handleError);
    }
    _handleError(error) {
        return Observable_1.Observable.throw(error.text() || 'Server error');
    }
}
exports.HttpHelpers = HttpHelpers;
//# sourceMappingURL=http-helpers.js.map