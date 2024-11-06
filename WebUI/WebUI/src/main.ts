import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { UserService } from './app/services/user.service';
import { CatalogService } from './app/services/catalog.service';
import { SubscriptionService } from './app/services/subscription.service';
import { provideRouter, Routes } from '@angular/router';
import { UserListComponent } from './app/components/user-list/user-list.component';
import { BookCatalogComponent } from './app/components/book-catalog/book-catalog.component';
import { UserSubscriptionComponent } from './app/components/user-subscription/user-subscription.component';

const routes: Routes = [
  { path: 'users', component: UserListComponent },
  { path: 'books', component: BookCatalogComponent },
  { path: 'subscriptions', component: UserSubscriptionComponent },
  { path: '', redirectTo: '/users', pathMatch: 'full' },
];


bootstrapApplication(AppComponent, {
  providers: [
    provideHttpClient(),
    provideRouter(routes),
    UserService,
    CatalogService,
    SubscriptionService,
  ]
}).catch(err => console.error(err));
