import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HubConnection } from '@aspnet/signalr';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChatHubService {
  public connected: boolean = false;
  private connection: HubConnection
  
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
}
