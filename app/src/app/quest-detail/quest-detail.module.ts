import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { QuestDetailPageRoutingModule } from './quest-detail-routing.module';

import { QuestDetailPage } from './quest-detail.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    QuestDetailPageRoutingModule
  ],
  declarations: [QuestDetailPage]
})
export class QuestDetailPageModule {}
