import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { combineLatest, lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-root',
  imports: [],
  templateUrl: './app.html',
  styleUrl: './app.css'
})

export class App implements OnInit {
  private http = inject(HttpClient);
  protected title = 'App'; //name displayed in the browser
  protected members = signal<any>([]);

  async ngOnInit() {
    this.members.set(await this.getmembers()) //displays members form database
  }

  async getmembers() {
    try {
      return lastValueFrom(this.http.get('https://localhost:5001/api/members'));
    } catch (error) {
      console.log(error);
      throw error;
    }
  }
}
