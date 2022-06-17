import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertController } from '@ionic/angular';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.page.html',
  styleUrls: ['./settings.page.scss'],
})
export class SettingsPage implements OnInit {

  constructor(
    public alertController: AlertController,
    private router: Router,
  ) { }

  ngOnInit() {
  }

  mockNavigateToChat(){
    this.router.navigate(['/chat-detail'])
  }

  mockNavigateToQuests(){
    this.router.navigate(['/quest-detail'])
  }

  async deleteUserFromChat(){
    const alert = await this.alertController.create({
      header: 'Benutzer ausschliessen?',
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

  async leaveChat(){
    const alert = await this.alertController.create({
      header: 'Chat verlassen?',
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

}
