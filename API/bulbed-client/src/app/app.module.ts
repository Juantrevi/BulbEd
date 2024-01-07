import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { routes } from './app.routes';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import {JwtInterceptor} from "./_interceptors/jwt.interceptor";
import {ErrorInterceptor} from "./_interceptors/error.interceptor";
import {HomeComponent} from "./home/home.component";
import {NavComponent} from "./nav/nav.component";
import {FormsModule} from "@angular/forms";
import {ToastrModule} from "ngx-toastr";
import { UserDashComponent } from './user-dash/user-dash.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent,
    UserDashComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot(
      {
        positionClass: 'toast-bottom-right'
      }
    )
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
