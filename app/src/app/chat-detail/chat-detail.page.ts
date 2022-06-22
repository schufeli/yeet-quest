import { Component, OnInit, ViewChild, ElementRef  } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ChannelService } from '../core/services/channel.service';
import { ChatHubService } from '../core/services/chat-hub.service';
import { SessionService } from '../core/services/session.service';

@Component({
  selector: 'app-chat-detail',
  templateUrl: './chat-detail.page.html',
  styleUrls: ['./chat-detail.page.scss'],
})
export class ChatDetailPage implements OnInit {
  @ViewChild('inputField', {static: false}) messageInput;
  @ViewChild('scrollMe', {static: false}) private myScrollContainer: ElementRef;

  chat: Object = null;
  messages: Object[];
  user: Object = null;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private chatService: ChannelService,
    private chatHubService: ChatHubService,
    private sessionService: SessionService
  ) { }

  ngOnInit() {
    this.scrollToBottom();

    this.chatService.getWithMessages(this.chatHubService.activeChatId)
    .subscribe(response => {
      this.chat = response['data']
      this.messages = response['data']['messages']

      this.chatHubService.receiveMessage()
        .subscribe(message => {
          this.messages.push(message);
        })
    });

    this.user = this.sessionService.get();

    this
  }

  ngAfterViewChecked() {
    this.scrollToBottom();
  }

  scrollToBottom(): void {
    try {
      this.myScrollContainer.nativeElement.scrollTop = this.myScrollContainer.nativeElement.scrollHeight;
    } catch (err) { }
  }

  navigateToHome(){
    this.router.navigate(['']);
    this.chatHubService.leave(this.chatHubService.activeChatId);
  }

  mockNavSettings(){
    this.router.navigate(['/settings'])
  }

  sendMessage(message) {
    const body = {
      content: message,
      authorId: this.user['id'],
      chatId: this.chat['id']
    }

    this.chatHubService.sendMessage(this.chat['id'], body)
  }

}
