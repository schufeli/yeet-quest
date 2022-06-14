import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService} from '../_services/auth.service';

import { User } from '../_types/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  constructor(
    private router: Router,
    private authService: AuthService
  ) { }

  loginForm : FormGroup;

  ngOnInit() {
    this.loginForm = new FormGroup({
      // name: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.email, Validators.required]),
      password: new FormControl('', Validators.required),
    });
  }

  sendLoginForm(){
    const user : User = {
      name: this.loginForm.value.name,
    }
    // this.authService.loginWithEmailAndPassword(user, '/home');  
  }

  navigateToRegister(){
    this.router.navigate(['register'])
  }

}
