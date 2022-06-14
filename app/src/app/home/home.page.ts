import { Component } from '@angular/core';
import { ChatHubService } from '../core/services/chat-hub.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {

  constructor(private chatHubService: ChatHubService) {}

  ngOnInit() {
    this.chatHubService.connect();
  }
}
