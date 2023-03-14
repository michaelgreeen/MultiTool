import { Component, OnInit } from '@angular/core';
import { WeatherDto, WeatherService } from 'Models';
import { Observable } from 'rxjs';
export const KELVIN_CONST = 273;
export const DECIMAL_PLACES = 2;
@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss']
})

export class WeatherComponent implements OnInit {

  city: string | any;
  weatherData: WeatherDto | undefined;

  constructor(private weatherService: WeatherService) { }
  ngOnInit(): void {
  }

  getWeather(): void {
    this.weatherService.weatherGetWeatherFromCityGet(this.city)
      .subscribe((data) => {
        this.weatherData = this.preprocessWeatherData(data);
      }, (error) => {
        console.error(error);
      });
  }

  clearWeather():void{
    this.weatherData = undefined;
  }

  preprocessWeatherData(data: WeatherDto): WeatherDto | undefined {
    if (data.main?.feels_like !== undefined)  { data.main.feels_like = parseFloat((data.main.feels_like - KELVIN_CONST).toFixed(DECIMAL_PLACES))};
    if (data.main?.temp !== undefined) { data.main.temp = parseFloat((data.main.temp - KELVIN_CONST).toFixed(DECIMAL_PLACES))};
    if (data.main?.temp_min !== undefined) { data.main.temp_min = parseFloat((data.main.temp_min - KELVIN_CONST).toFixed(DECIMAL_PLACES))};
    if (data.main?.temp_max !== undefined) { data.main.temp_max = parseFloat((data.main.temp_max - KELVIN_CONST).toFixed(DECIMAL_PLACES))};
    return data;
  }


}
