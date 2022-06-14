import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  /**
   * Get all users
   * @returns List of users
   */
  public get() {
    return this.http.get(`${environment.api}/users`);
  }

  /**
   * Get user
   * @param id User id
   * @returns Single user
   */
  public getById(id: string) {
    return this.http.get(`${environment.api}/users/${id}`);
  }

  /**
   * Get user with chats
   * @param id User id
   * @returns Single user with all chats
   */
  public getWithChats(id: string) {
    return this.http.get(`${environment.api}/users/${id}/chats`);
  }
  
  /**
   * Log user in or "create new one"
   * @param user User object *name must be set!* (see api doc)
   * @returns Single user 
   */
  public login(user: object) {
    return this.http.post(`${environment.api}/users`, user);
  }
}
