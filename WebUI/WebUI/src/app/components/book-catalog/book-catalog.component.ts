import { Component, OnInit } from '@angular/core';
import { CatalogService } from '../../services/catalog.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-book-catalog',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './book-catalog.component.html',
  // styleUrl: './book-catalog.component.scss',
  styleUrls: ['./book-catalog.component.scss']
})
export class BookCatalogComponent implements OnInit {
  books: any[] = [];
  newBook = { name: '', text: '', purchasePrice: 0 };

  constructor(private catalogService: CatalogService) {}

  ngOnInit(): void {
    this.getBooks();
  }

  getBooks(): void {
    this.catalogService.getAllBooks().subscribe(books => this.books = books);
  }

  addBook(): void {
    if(this.newBook.name && this.newBook.text && this.newBook.purchasePrice > 0){

      this.catalogService.addBook(this.newBook).subscribe(() => {

        alert('Book succesfully added!')
        this.getBooks(); 
        console.log(this.getBooks())
        this.newBook = { name: '', text: '', purchasePrice: 0 }; 
      });
    }
    else{
      alert('Please enter book details!')
    }   
  }
}