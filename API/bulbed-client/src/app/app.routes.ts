import { Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {UserDashComponent} from "./user-dash/user-dash.component";
import {authGuard} from "./_guards/auth.guard";
import {AdminPanelComponent} from "./admin/admin-panel/admin-panel.component";
import {adminGuard} from "./_guards/admin.guard";

export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [authGuard],
    children: [
      {path: 'user-dash', component: UserDashComponent},
      {path: 'admin', component: AdminPanelComponent, canActivate: [adminGuard]},
    ]},
];
