import { HttpClient } from '@angular/common/http';
import { Component, signal,inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  imports: [],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App implements OnInit {
  private http = inject(HttpClient);
  protected readonly title = 'Dating App';
  protected members = signal<any>([]);

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/members')
      .subscribe({
        next: (response) => this.members.set(response), 
        error: (error) => console.log(error),
        complete: () => console.log('Request completed')
      });
  }
}
