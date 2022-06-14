import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  private user: Object;
  
  public get() {
    return this.user;
  }

  public set(user: Object) {
    this.user = user;
  }

  public loggedIn() {
    if (this.user.toString.length > 0) {
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
