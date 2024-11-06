import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './user-list.component.html',
  // styleUrl: './user-list.component.scss',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  users: any[] = [];
  newUser = { email: '', firstName: '', lastName: '' };

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    this.userService.getAllUsers().subscribe(users => this.users = users);
  }

  addUser(): void {
    if(this.newUser.email && this.newUser.firstName && this.newUser.lastName){

      this.userService.registerUser(this.newUser).subscribe(() => {
        alert('USer succesfully added!');

        this.getUsers(); 
        this.newUser = { email: '', firstName: '', lastName: '' };
      });
    }
    else{
      alert('Please enter user details')
    }

  }
}
