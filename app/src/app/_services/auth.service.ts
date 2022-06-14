import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { MenuController, ToastController } from '@ionic/angular';

import { User } from '../_types/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private router: Router,
    private toast: ToastController,
    private menuCtrl: MenuController
  ) { }

  //List of Service functions goes here
}
