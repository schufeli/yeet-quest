import { Component } from '@angular/core';
import { ChatHubService } from '../core/services/chat-hub.service';
import { SessionService } from '../core/services/session.service';
import { UserService } from '../core/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  constructor(
    private sessionService: SessionService,
    private chatHubService: ChatHubService,
    ) { }

  ngOnInit() {
    this.sessionService.set({ id: "e3db95b1-4574-4259-9a1f-afcc2f8ffb48", name: "JoeMama" }); // TODO: Remove after development (when better session handling is implemented)
    this.chatHubService.connect();
  }
}
