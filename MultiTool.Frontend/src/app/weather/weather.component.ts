import { Component, OnInit } from '@angular/core';
import { WeatherService } from 'Models';
@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})
export class WeatherComponent implements OnInit {

  city: string | any;
  weatherData: any;

  constructor(private weatherService: WeatherService) {}

  getWeather() {
    this.weatherService.weatherGetWeatherFromCityGet(this.city)
      .subscribe((data) => {
        this.weatherData = data;
      }, (error) => {
        console.error(error);
      });
  }
  ngOnInit(): void {
  }

}
