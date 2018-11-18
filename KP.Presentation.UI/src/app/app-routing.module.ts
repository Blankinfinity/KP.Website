import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WelcomeComponent } from './welcome/welcome.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './modules/home/home.component';
import { NotFoundComponent } from './modules/error-pages/not-found/not-found.component';
import { InternalServerComponent } from './modules/error-pages/internal-server/internal-server.component';

const routes: Routes = [
  { path: '', component: WelcomeComponent },
  { path: 'owner', loadChildren: './modules/owner/owner.module#OwnerModule' },
  { path: '404', component: NotFoundComponent },
  { path: '500', component: InternalServerComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'home', component: HomeComponent },
  { path: '**', redirectTo: '/404', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
