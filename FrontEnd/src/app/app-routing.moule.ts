import { NgModule } from '@angular/core';
import { HtmlComponent } from './html/html.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { BootstrpComponent } from './bootstrp/bootstrp.component';
import { UserTestComponent } from './Test/user-test/user-test.component';
import { PersonTestComponent } from './Test/person-test/perso-test.component';
import { RouterModule, Routes } from '@angular/router';
import { BindingComponent } from './binding/binding.component';
import { HomeComponent } from './home/home.component';

import { ParentComponent } from './sharing-data/parent/parent.component';
import { AboutComponent } from './templete/about/about.component';
import { ServicesComponent } from './templete/services/services.component';
import { PortfolioComponent } from './templete/portfolio/portfolio.component';
import { TeamComponent } from './templete/teams/team.component';
import { ContactComponent } from './templete/contact/contact.component';
import { DepartmentAddComponent } from './templete/services/department-add/department-add.component';
import { PageModeEnum } from './constants/enums';
import { SectionComponent } from './section/section.component';
import { SectionManagementComponent } from './section/section-management/section-management.component';
import { SectionAddComponent } from './section/section-add/section-add.component';
import { AuthGuard } from './guards/auth.guard';

const routers: Routes =
  [
    { path: '', redirectTo: '/course/courses', pathMatch: 'full' }, // Default route
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'html', component: HtmlComponent },
    { path: 'bootstrap', component: BootstrpComponent },
    { path: 'navbar', component: NavBarComponent },
    { path: 'person', component: PersonTestComponent },
    { path: 'user-test', component: UserTestComponent },
    { path: 'bind', component: BindingComponent },

    {
      path: 'user',
      loadChildren: () => import('./user/user.module').then(m => m.UserModule)
    },



    { path: 'sharing-data', component: ParentComponent },
    { path: 'about', component: AboutComponent },
    { path: 'services', component: ServicesComponent, canActivate: [AuthGuard] },
    { path: 'portfolio', component: PortfolioComponent },
    { path: 'team', component: TeamComponent },
    { path: 'about', component: AboutComponent },
    { path: 'contact', component: ContactComponent },
    { path: 'department-add', component: DepartmentAddComponent, data: { pageMode: PageModeEnum.Add } },
    { path: 'department-edit/:id', component: DepartmentAddComponent, data: { pageMode: PageModeEnum.Update } },
    { path: 'department-view/:id', component: DepartmentAddComponent, data: { pageMode: PageModeEnum.View } },
    { path: 'section-add', component: SectionAddComponent },
    { path: 'section/:courseId', component: SectionComponent },
    {
      path: 'course',
      loadChildren: () => import('./templete/course/course.module').then(m => m.CourseModule)
    },
    { path: 'sections', component: SectionComponent },
    { path: 'section-management', component: SectionManagementComponent },
  

  ];


@NgModule({
  imports: [RouterModule.forRoot(routers)],
  exports: [RouterModule]
})

export class AppRoutingMoodule { }
