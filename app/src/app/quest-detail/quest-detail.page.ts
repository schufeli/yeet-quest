import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertController } from '@ionic/angular';
import { ChannelService } from '../core/services/channel.service';
import { ChatHubService } from '../core/services/chat-hub.service';
import { QuestService } from '../core/services/quest.service';
import { SessionService } from '../core/services/session.service';

@Component({
  selector: 'app-quest-detail',
  templateUrl: './quest-detail.page.html',
  styleUrls: ['./quest-detail.page.scss'],
})
export class QuestDetailPage implements OnInit {
  quests: Object[] = [];
  users: Object[] = [];
  user: Object = null;

  constructor(
    private router: Router,
    public alertController: AlertController,
    private chatService: ChannelService,
    private chatHubService: ChatHubService,
    private questService: QuestService,
    private sessionService: SessionService
  ) { }

  ngOnInit() {
    this.chatService.getWithUsers(this.chatHubService.activeChatId)
    .subscribe(result => {
      this.users = result['data']['users'];
      this.chatService.getWithQuests(this.chatHubService.activeChatId)
      .subscribe(result => {
        result['data']['quests'].forEach(element => {
          const user = this.users.find(u => u['id'] === element['assigneId']);
          if (user) {
            element['assigneName'] = user['name'];
            this.quests.push(element)
          }
        });
       this.user = this.sessionService.get();
      })
    })
  }

  mockNavigateToSettings(){
    this.router.navigate(['/settings'])
  }

  async deleteQuestItem(quest: Object){
    const alert = await this.alertController.create({
      header: 'Item löschen?',
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
            if (quest['id'] !== "") {
              this.questService.remove(quest['id'])
                .subscribe(() => {
                  this.quests.splice(this.quests.indexOf(quest), 1);
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

  async openAddQuestTaskModal(){
    const alert = await this.alertController.create({
      header: 'Task hinzufügen',
      inputs: [
        {
          name: 'content',
          type: 'text',
          placeholder: 'Task eingeben'
        },
      ],
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          cssClass: 'secondary',
        }, {
          text: 'Ok',
          handler: (data) => {
            if (data.content !== null) {
              const quest = { 
                content: data.content, 
                chatId: this.chatHubService.activeChatId, 
                assigneId: this.user['id']
              }
              this.questService.create(quest)
              // this.users.find(u => u['id'] === element['assigneId'])['name']
                .subscribe(response => {
                  response['data']['assigneName'] = this.users.find(u => u['id'] === response['data']['assigneId'])['name'];
                  this.quests.push(response['data']);
                })
            }
          }
        }
      ]
    });

    await alert.present();
  }

  shuffleTasks() {

  }

}
