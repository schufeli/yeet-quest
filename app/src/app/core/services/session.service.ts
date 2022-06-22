import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  private user: Object;
  
  public get() {
    return JSON.parse(window.localStorage.getItem('user'));
  }

  public set(user: Object) {
    window.localStorage.setItem('user', JSON.stringify(user))
  }

  public loggedIn() {
    if (window.localStorage.getItem('user')) {
      return true;
    } 
    else {
      return false;
    }
  }

  public logout() {
    this.user = null;
  }
}
