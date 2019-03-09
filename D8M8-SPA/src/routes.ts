import { Routes } from '@angular/router';
import { MemberListComponent } from './app/members/member-list/member-list.component';
import { HomeComponent } from './app/home/home.component';
import { MessagesComponent } from './app/messages/messages.component';
import { ListsComponent } from './app/lists/lists.component';
import { AuthGuard } from './app/_guards/auth.guard';
import { MemberDetailComponent } from './app/members/member-detail/member-detail.component';
import { MemberDetailResolver } from './app/_resolvers/member-detail.resolver';
import { MemberListResolver } from './app/_resolvers/member-list.resolver';
import { MemberEditComponent } from './app/members/member-edit/member-edit.component';
import { MemberEditResolver } from './app/_resolvers/member-edit.resolver';
import { PreventUnsavedChanges } from './app/_guards/prevent-unsaved-changes.guard';

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
            { path: 'members', component: MemberListComponent
                , resolve: {users: MemberListResolver} },
            { path: 'members/:id', component: MemberDetailComponent
                , resolve: {user: MemberDetailResolver} },
            { path: 'member/edit', component: MemberEditComponent
                , resolve: {user: MemberEditResolver}, canDeactivate: [PreventUnsavedChanges] },
            { path: 'messages', component: MessagesComponent },
            { path: 'lists', component: ListsComponent },
        ]
    },
    // { path: 'members', component: MemberListComponent, canActivate: [AuthGuard] }, // single page with single guard (pointless)
    { path: '**', redirectTo: '', pathMatch: 'full' },  // wildcard
];
