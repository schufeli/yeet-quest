import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  constructor(
    private router: Router,
  ) { }

  loginForm : FormGroup;

  ngOnInit() {
    this.loginForm = new FormGroup({
      name: new FormControl('', Validators.required),
    });
  }

  sendLoginForm(){
    console.log('implement me');
    
  }

}
