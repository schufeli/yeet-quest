import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { QuestDetailPage } from './quest-detail.page';

const routes: Routes = [
  {
    path: '',
    component: QuestDetailPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class QuestDetailPageRoutingModule {}
