import { Component } from '@angular/core';
import { ChatHubService } from '../core/services/chat-hub.service';
import { SessionService } from '../core/services/session.service';
import { AlertController } from '@ionic/angular';
import { Router } from '@angular/router';
import { UserService } from '../core/services/user.service';
import { ChannelService } from '../core/services/channel.service';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage {
  constructor(
    private sessionService: SessionService,
    private chatHubService: ChatHubService,
    private userService: UserService,
    private channelService: ChannelService,
    public alertController: AlertController,
    private router: Router,
  ) { }

  chats: Object[];
  user: Object;

  ngOnInit() {
    this.sessionService.set({ id: "e3db95b1-4574-4259-9a1f-afcc2f8ffb48", name: "JoeMama" }); // TODO: Remove after development (when better session handling is implemented)
    this.user = this.sessionService.get();
    this.chatHubService.connect();

    this.userService.getWithChats(this.user['id'])
      .subscribe(response => this.chats = response['data']['chats'])
  }
  async openAddChatModal(){
    const alert = await this.alertController.create({
      header: 'Chatname eingeben',
      inputs: [
        {
          name: 'name',
          type: 'text',
          placeholder: 'Name des Chats eingeben'
        },
      ],
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          cssClass: 'secondary',
        }, 
        {
          text: 'Ok',
          cssClass: 'primary',
          handler: (data) => {
            if (data.name !== "") {
              data.description = "...";
              this.channelService.create(data)
              .subscribe(response => {
                this.channelService.addUsers(response['data']['id'], [this.user])
                .subscribe(() => {
                  this.chats.push(response['data']);
                });
              })
            } else {
                return false;
            }
          }
        }
      ]
    });
    await alert.present();
  }

  async deleteChat(chat){
    const alert = await this.alertController.create({
      header: 'Wirklich löschen?',
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          cssClass: 'secondary',
        }, 
        {
          text: 'Ja',
          cssClass: 'alertCancel',
          handler: () => {
            if (chat.name !== "") {
              this.chats.splice(this.chats.indexOf(chat), 1);
              this.channelService.removeUsers(chat.id, [this.user])
              .subscribe(() => {console.log('test')});
            } else {
                return false;
            }
          }
        }
      ]
    });
    await alert.present();
  }

  join(chatId) {
    this.chatHubService.join(chatId);
  }
}
