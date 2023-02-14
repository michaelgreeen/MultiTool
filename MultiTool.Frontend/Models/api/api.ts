export * from './config.service';
import { ConfigService } from './config.service';
export * from './login.service';
import { LoginService } from './login.service';
export * from './weather.service';
import { WeatherService } from './weather.service';
export const APIS = [ConfigService, LoginService, WeatherService];
