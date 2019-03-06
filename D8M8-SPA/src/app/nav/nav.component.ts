import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  // This function is called when Angular form in nav is submitted
  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Logged in successfully');
    }, error => {
      this.alertify.error(error);
    });
  }

  loggedIn() {

    return this.authService.loggedIn();

    /*
    Previous login function
    // Get token from local storage
    const token = localStorage.getItem('token');

    // Return true if token has a value, and false if not.
    return !!token;
    */
  }

  logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
  }

}
