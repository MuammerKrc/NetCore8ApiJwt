export * from './account.service';
import { AccountService } from './account.service';
export * from './authorize.service';
import { AuthorizeService } from './authorize.service';
export * from './product.service';
import { ProductService } from './product.service';
export * from './weatherForecast.service';
import { WeatherForecastService } from './weatherForecast.service';
export const APIS = [AccountService, AuthorizeService, ProductService, WeatherForecastService];
