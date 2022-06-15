import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-quest-detail',
  templateUrl: './quest-detail.page.html',
  styleUrls: ['./quest-detail.page.scss'],
})
export class QuestDetailPage implements OnInit {

  constructor(
    private router: Router,
    public alertController: AlertController,
  ) { }

  ngOnInit() {
  }
  mockNavigateToSettings(){
    this.router.navigate(['/settings'])
  }

  async deleteQuestItem(){
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

  async openAddQuestTaskModal(){
    // const user = await this.authService.getCurrentUser();
    const alert = await this.alertController.create({
      header: 'Task hinzufügen',
      inputs: [
        {
          name: 'taskName',
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

          }
        }
      ]
    });

    await alert.present();
  }

}
