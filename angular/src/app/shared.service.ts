import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl="http://localhost:5000/api";
  constructor(private http:HttpClient) { }

  getFeedback():Observable<any[]> {
    return this.http.get<any>(this.APIUrl+'/feedback');
  }

  addMessage(val:any){
    return this.http.post(this.APIUrl+'/feedback',val);
  }

  updateMessage(val:any){
    return this.http.put(this.APIUrl+'/feedback',val);
  }
}
