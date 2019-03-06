import { Routes } from '@angular/router';
import { MemberListComponent } from './app/member-list/member-list.component';
import { HomeComponent } from './app/home/home.component';
import { MessagesComponent } from './app/messages/messages.component';
import { ListsComponent } from './app/lists/lists.component';
import { AuthGuard } from './app/_guards/auth.guard';

// Ordering is important
export const appRoutes: Routes = [
    // Home route
    { path: '', component: HomeComponent },
    // Protect mutliple routes with single guard
    // Create a dummy route
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members', component: MemberListComponent },
            { path: 'messages', component: MessagesComponent },
            { path: 'lists', component: ListsComponent },
        ]
    },
    // { path: 'members', component: MemberListComponent, canActivate: [AuthGuard] }, // single page with single guard (pointless)
    { path: '**', redirectTo: '', pathMatch: 'full' },  // wildcard
];
