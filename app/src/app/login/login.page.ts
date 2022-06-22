import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../core/services/user.service'
import { SessionService } from '../core/services/session.service'


@Component({
  selector: 'app-login',
  templateUrl: './login.page.html',
  styleUrls: ['./login.page.scss'],
})
export class LoginPage implements OnInit {

  constructor(
    private router: Router,
    private userService: UserService,
    private sessionServcie: SessionService
  ) { }

  loginForm : FormGroup;

  ngOnInit() {
    this.loginForm = new FormGroup({
      username: new FormControl('', Validators.required),
    });
  }

  sendLoginForm(){
    const user = {
      name: this.loginForm.get('username').value
    }
    this.userService.login(user)
    .subscribe(result => {
      this.sessionServcie.set(result['data']);
      this.router.navigate(['../home'])   
    })
  }

}
