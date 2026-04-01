import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HtmlComponent } from './html/html.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { BootstrpComponent } from './bootstrp/bootstrp.component';
import { UserTestComponent } from './Test/user-test/user-test.component';

import { HtmlTestComponent } from './html/html-test/html-test.component';
import { StudentTestComponent } from './Test/student-test/student-test.component';
import { PersonTestComponent } from './Test/person-test/perso-test.component';
import { BindingComponent } from './binding/binding.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { ParentComponent } from './sharing-data/parent/parent.component';
import { ChildComponent } from './sharing-data/child/child.component';
import { HeaderComponent } from './templete/header/header.component';
import { HeroComponent } from './templete/hero/hero.component';
import { ClientsComponent } from './templete/clients/clients.component';
import { AboutComponent } from './templete/about/about.component';
import { WhyUsComponent } from './templete/why-us/why-us.component';
import { SkillsComponent } from './templete/skills/skills.component';
import { ServicesComponent } from './templete/services/services.component';
import { CtaComponent } from './templete/cta/cta.component';
import { PortfolioComponent } from './templete/portfolio/portfolio.component';
import { TeamComponent } from './templete/teams/team.component';
import { PricingComponent } from './templete/pricing/pricing.component';
import { FaqComponent } from './templete/faq/faq.component';
import { ContactComponent } from './templete/contact/contact.component';
import { FooterComponent } from './templete/footer/footer.component';
import { DepartmentAddComponent } from './templete/services/department-add/department-add.component';
import { SectionComponent } from './section/section.component';
import { SectionManagementComponent } from './section/section-management/section-management.component';
import { AppRoutingMoodule } from './app-routing.moule';
import { SectionAddComponent } from './section/section-add/section-add.component';
import { TokenInterceptor } from './interceptors/token.interceptor';






@NgModule({
  declarations: [
    AppComponent,
    HtmlComponent,
    NavBarComponent,
    BootstrpComponent,
    UserTestComponent,
    StudentTestComponent,
    HtmlTestComponent,
    PersonTestComponent,
    BindingComponent,

    HomeComponent,

    ParentComponent,
    ChildComponent,
    HeaderComponent,
    HeroComponent,
    ClientsComponent,
    AboutComponent,
    WhyUsComponent,
    SkillsComponent,
    ServicesComponent,
    CtaComponent,
    PortfolioComponent,
    TeamComponent,
    PricingComponent,
    FaqComponent,
    ContactComponent,
    FooterComponent,
    DepartmentAddComponent,

    SectionComponent,
    SectionManagementComponent,
    SectionAddComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingMoodule
    
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi:true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
