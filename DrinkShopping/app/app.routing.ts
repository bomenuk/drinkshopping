import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DrinkComponent } from './components/drink.component';
import { HomeComponent } from './components/home.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'drink', component: DrinkComponent }
];

export const routing: ModuleWithProviders =
    RouterModule.forRoot(appRoutes);