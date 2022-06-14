import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { AuthService} from '../_services/auth.service';
import { User } from '../_types/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {

  constructor(
    private router: Router,
    private authService: AuthService
  ) { }

  registerForm : FormGroup;

  ngOnInit() {
    this.registerForm = new FormGroup({
      name: new FormControl('', Validators.required),
      mail: new FormControl('', [Validators.email, Validators.required]),
      password: new FormControl('', Validators.required),
    });
  }

  sendRegisterForm(){
     const user : User = {
      name: this.registerForm.value.name,
    }
    // this.authService.createUserWithEmailAndPassword(user, '/home');
  }

  navigateToLogin(){
    this.router.navigate(['login'])
  }

}
