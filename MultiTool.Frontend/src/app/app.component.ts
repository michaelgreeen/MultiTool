import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  
  city: string | undefined;
  response: string | undefined;
  title = 'MultiTool.Frontend';

  constructor(private http: HttpClient) { }

  sendRequest() {
    console.log(this.city);
    this.http.get('http://localhost:5117/Weather/GetWeatherFrom/'+this.city)
      .subscribe(response => {
        console.log('Request sent successfully');
        this.response = JSON.stringify(response);
      }, error => {
        console.error('Error sending request:', error);
      });
  }
}
