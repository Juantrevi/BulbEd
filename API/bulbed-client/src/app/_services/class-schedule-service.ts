// src/app/class-schedule.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {environment} from "../../enviroments/enviroment";

@Injectable({
  providedIn: 'root'
})
export class ClassScheduleService {
  private apiUrl = environment.apiUrl + 'class-schedule';

  constructor(private http: HttpClient) { }

  getClassSchedules(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
