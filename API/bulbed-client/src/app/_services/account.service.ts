import { Injectable } from '@angular/core';
import {environment} from "../../enviroments/enviroment";
import {BehaviorSubject, catchError, map, tap, throwError} from "rxjs";
import {User} from "../_models/user";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = 'https://localhost:5001/api/';
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          this.setCurrentUser(user);
        }
      })
    );
  }

  setCurrentUser(user: User){
    user.roles = [];
    const roles = this.getDecodedToken(user.token).role;
    user.firstName = this.getDecodedToken(user.token).firstName;
    Array.isArray(roles) ? user.roles = roles : user.roles.push(roles);
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  getDecodedToken(token: string) {
    return JSON.parse(atob(token.split('.')[1]));
  }

logout() {
  return this.http.post(this.baseUrl + 'logout', {}).pipe(
    tap(() => {
      localStorage.removeItem('user');
      this.currentUserSource.next(null);
    }),
    catchError(error => {
      console.log(error);
      return throwError(error);
    })
  );
}

}
