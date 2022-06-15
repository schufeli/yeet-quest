import { Component, OnInit, ViewChild, ElementRef  } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-chat-detail',
  templateUrl: './chat-detail.page.html',
  styleUrls: ['./chat-detail.page.scss'],
})
export class ChatDetailPage implements OnInit {

  @ViewChild('inputField', {static: false}) messageInput;
  @ViewChild('scrollMe', {static: false}) private myScrollContainer: ElementRef;

  constructor(
    private router: Router,
  ) { }

  ngOnInit() {
    this.scrollToBottom();
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
    this.router.navigate([''])
  }

  mockNavSettings(){
    this.router.navigate(['/settings'])
  }

}
