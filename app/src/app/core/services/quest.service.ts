import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuestService {

  constructor(private http: HttpClient) { }

  /**
   * Create new quest
   * @param quest Quest object (see api doc)
   * @returns Single quest
   */
  public create(quest: object) {
    return this.http.post(`${environment.api}/quests`, quest);
  }

  /**
   * Update existing quest
   * @param quest Quest object (see api doc)
   * @returns Single quest
   */
  public update(quest: object) {
    return this.http.put(`${environment.api}/quests`, quest);
  }
}
