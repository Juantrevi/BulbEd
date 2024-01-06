// src/app/app.component.ts
import { Component, OnInit } from '@angular/core';
import { ClassScheduleService } from './services/class-schedule-service';
import {AccountService} from "./services/account.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'bulbed-client';
  classSchedules: any[] = [];

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const userString = localStorage.getItem('user');
    if(!userString){
      return;
    }
    const user = JSON.parse(userString);
    this.accountService.setCurrentUser(user);
  }
}
