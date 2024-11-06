import { Component } from '@angular/core';
import { SubscriptionService } from '../../services/subscription.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-user-subscription',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './user-subscription.component.html',
  // styleUrl: './user-subscription.component.scss',
  styleUrls: ['./user-subscription.component.scss']
})

export class UserSubscriptionComponent {
  userId: number = 0;
  bookId: number = 0;
  subscriptions: any[] = [];

  constructor(private subscriptionService: SubscriptionService) {}

  getUserSubscriptions(): void {
    if (this.userId){
      this.subscriptionService.getUserSubscriptions(this.userId).subscribe(subs => this.subscriptions = subs);
    }
    else{
      alert('Enter user id to view user subscriptions!');
    }
    
  }

  subscribe(): void {
    if (this.userId && this.bookId){
      this.subscriptionService._subscribe(this.userId, this.bookId).subscribe(() => this.getUserSubscriptions());
      
      alert('Succesfully unsubscribed user '+ this.userId+ ' from book '+ this.bookId)

    }
    else{
      alert('Enter user id and book id to subscribe!');
    }
   }

  unsubscribe(): void {
    if (this.userId && this.bookId){
    this.subscriptionService.unsubscribe(this.userId, this.bookId).subscribe(() => this.getUserSubscriptions());

    alert('Succesfully unsubscribed user '+ this.userId+ ' from book '+ this.bookId)
    }
    else{
      alert('Enter user id and book id to unsubscribe!');
    }
  }
}
