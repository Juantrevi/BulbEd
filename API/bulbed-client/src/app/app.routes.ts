import { Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {UserDashComponent} from "./user-dash/user-dash.component";

export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'user-dash', component: UserDashComponent},
];
