import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';


@Component({
  selector: 'app-feedback',
  templateUrl: './feedback.component.html',
  styleUrls: ['./feedback.component.css']
})
export class FeedbackComponent implements OnInit {

  constructor(private service:SharedService) { }

  FeedbackList:any=[];

  ngOnInit(): void {
    this.refreshFeedbackList();
    
  }
  refreshFeedbackList() {
    
    this.service.getFeedback().subscribe(data=>{
      this.FeedbackList.data;
    })
  }

  

}

