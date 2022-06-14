import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { HubConnection } from '@microsoft/signalr';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChatHubService {
  public connected: boolean = false;
  
  constructor(private connection: HubConnection) {
    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(environment.hub)
      .build();
  }

  public connect() {
    this.connection.start()
      .then(() => console.log('Connected'))
      .catch(err => console.error(err));
  }
}
