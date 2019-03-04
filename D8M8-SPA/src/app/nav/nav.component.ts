import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  // This function is called when Angular form in nav is submitted
  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log(error);
    });
  }

  loggedIn() {
    // Get token from local storage
    const token = localStorage.getItem('token');

    // Return true if token has a value, and false if not.
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
    console.log('Logged out');
  }

}
