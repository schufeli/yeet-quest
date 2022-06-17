import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ChannelService {

  constructor(private http: HttpClient) { }

  /**
   * Get all chats
   * @returns List of chats
   */
  public get() {
    return this.http.get(`${environment.api}/chats`);
  }

  /**
   * Get chat
   * @param id Chat id
   * @returns Single chat
   */
  public getById(id: string) {
    return this.http.get(`${environment.api}/chats/${id}`);
  }

  /**
   * Get chat with messages
   * @param id Chat id
   * @returns Single chat with all messages
   */
  public getWithMessages(id: string) {
    return this.http.get(`${environment.api}/chats/${id}/messages`);
  }

  /**
   * Get chat with quests
   * @param id Chat id
   * @returns Single chat with all quests
   */
  public getWithQuests(id: string) {
    return this.http.get(`${environment.api}/chats/${id}/quests`);
  }

  /**
   * Get chat with users
   * @param id Chat id
   * @returns Single chat with all users
   */
  public getWithUsers(id: string) {
    return this.http.get(`${environment.api}/chats/${id}/users`);
  }

  /**
   * Create new chat
   * @param chat Chat as object (see api doc)
   * @returns 
   */
  public create(chat: object) {
    return this.http.post(`${environment.api}/chats`, chat);
  }

  /**
   * Add user to chat
   * @param id Chat id
   * @param user User object (see api doc)
   * @returns Http 200 (Ok Result)
   */
  public addUsers(id: string, users: object[]) {
    return this.http.put(`${environment.api}/chats/${id}/add`, users);
  }

  /**
   * Remove user from chat
   * @param id Chat id
   * @param user User object (see api doc)
   * @returns HTTP 200 (Ok Result)
   */
  public removeUsers(id: string, users: object[]) {
    return this.http.put(`${environment.api}/chats/${id}/remove`, users);
  }
}
