import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgxMaskModule, IConfig } from 'ngx-mask';  //импорт маски для телефона
import { SharedService } from './shared.service';
import { HttpClientModule } from '@angular/common/http';
import { MessageComponent } from './message/message.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { AddMessageComponent } from './message/add-message/add-message.component';


const maskConfigFunction: () => Partial<IConfig> = () => { //для маски
  return {
    validation: false,
  };
};

@NgModule({
  declarations: [
    AppComponent,
    MessageComponent,
    FeedbackComponent,
    AddMessageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(maskConfigFunction), //модуль маски
    HttpClientModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }





