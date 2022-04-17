import { Component, OnInit, Input } from '@angular/core';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-message',
  templateUrl: './add-message.component.html',
  styleUrls: ['./add-message.component.css']
})
export class AddMessageComponent implements OnInit {

  title = 'TestTask';
  fullNameControl: FormGroup;

  constructor(private service:SharedService) { }

  @Input() mes:any;
  MessageId:string;
  NameUser:string;
  EmailUser:string;
  Phone:string;
  Theme:string;
  MessageText:string;


  ngOnInit(): void {
    this.fullNameControl = new FormGroup({
      firstName: new FormControl('', [Validators.required, Validators.minLength(3), Validators.maxLength(12)]),
      email: new FormControl('', [Validators.required, 
        Validators.email, 
        Validators.pattern("^((([0-9A-Za-z]{1}[-0-9A-z\.]{0,30}[0-9A-Za-z]?)|([0-9А-Яа-я]{1}[-0-9А-я\.]{0,30}[0-9А-Яа-я]?))@([-A-Za-z]{1,}\.){1,}[-A-Za-z]{2,})$")]), 
        //Некоторые люди, сталкиваясь с проблемой, думают: «О, я воспользуюсь регулярными выражениями».
        //Теперь у них две проблемы.
      phone: new FormControl('', [Validators.required, Validators.minLength(10)]),
      theme: new FormControl('', [Validators.required]),
      sms: new FormControl('', [Validators.required, Validators.minLength(5)]),
      captcha: new FormControl('', [Validators.required])
    });
    this.MessageId=this.mes.MessageId;
    this.NameUser=this.mes.NameUser;
    this.EmailUser=this.mes.EmailUser;
    this.Phone=this.mes.Phone;
    this.Theme=this.mes.Theme;
    this.MessageText=this.mes.MessageText;
  }

  addMessage() {
    var val = {MessageId:this.MessageId,
              NameUser:this.NameUser,
              EmailUser:this.EmailUser,
              Phone:this.Phone,
              Theme:this.Theme,
              MessageText:this.MessageText}
    
  }
  nameUser() {
    console.warn(this.fullNameControl.value);
  }

  get firstName (){
    return this.fullNameControl.get('firstName');
  }

  get email (){
    return this.fullNameControl.get('email');
  }

  get phone (){
    return this.fullNameControl.get('phone');
  }

  get theme (){
    return this.fullNameControl.get('theme');
  }

  get sms (){
    return this.fullNameControl.get('sms');
  }

  onSubmit(): void {
    console.log(this.fullNameControl.value);
  }
}
