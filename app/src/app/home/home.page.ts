import { Component } from '@angular/core';
import { ChatHubService } from '../core/services/chat-hub.service';
import { SessionService } from '../core/services/session.service';
import { AlertController } from '@ionic/angular';
import { Router } from '@angular/router';
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
    public alertController: AlertController,
    private router: Router,
  ) { }

  ngOnInit() {
    this.sessionService.set({ id: "e3db95b1-4574-4259-9a1f-afcc2f8ffb48", name: "JoeMama" }); // TODO: Remove after development (when better session handling is implemented)
    this.chatHubService.connect();

  }
  async openAddChatModal(){
    // let defaultDate = new Date();
    // let defaultDateFormated = this.datepipe.transform(defaultDate, 'yyyy-MM-dd');
    const user = await this.sessionService.get();
    const alert = await this.alertController.create({
      header: 'Chatname eingeben',
      inputs: [
        {
          name: 'chatName',
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
            if (data.chatName !== "") {
              console.log('this');
            } else {
                return false;
            }
          }
        }
      ]
    });
    await alert.present();
  }

  async deleteChat(data){
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
          handler: (data) => {
            if (data.chatName !== "") {
              console.log('this');
            } else {
                return false;
            }
          }
        }
      ]
    });
    await alert.present();
  }

  getDetailChat(){

  }

  mockDetailNav(){
    this.router.navigate(['/chat-detail'])
  }
}
