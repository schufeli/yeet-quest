import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChatHubService {
  public connected: boolean = false;
  private connection: HubConnection

  public activeChatId: string = "6cd112bd-e094-424e-94d0-8318ff56a02b"; // TODO: Remove after development
  
  constructor() {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.hub)
      .build();
  }

  public connect() {
    this.connection.start()
      .then(() => this.connected = true)
      .catch(err => {
        console.error(err);
        this.connected = false;
      });
  }

  public join(id: string) {
    console.log(`Joined: ${id}`)
    this.connection.invoke("Join", id);
    this.activeChatId = id;
  }

  public leave(id: string) {
    console.log(`Left: ${id}`)
    this.connection.invoke("Leave", id);
    this.activeChatId = null;
  }

  public sendMessage(id: string, message: Object) {
    this.connection.invoke("SendMessage", id, message);
  }

  public receiveMessage() {
    return new Observable(subscriber => {
      this.connection.on("ReceiveMessage", message => {
        subscriber.next(message);
      });
    })
    
  }
}
