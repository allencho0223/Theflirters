import { Injectable } from '@angular/core';

// As long as we use declare keyword, we don't need to import because it is already done in angular.js file (scripts)
// But we do need to make use of it inside our service
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

  confirm(message: string, okaCallback: () => any) {
    alertify.confirm(message, function(e) {
      // The e parameter represents a client's click
      if (e) {
        okaCallback();
      } else {

      }
    });
  }

  success(message: string) {
    alertify.success(message);
  }

  error(message: string) {
    alertify.error(message);
  }

  warning(message: string) {
    alertify.warning(message);
  }

  message(message: string) {
    alertify.message(message);
  }

}
