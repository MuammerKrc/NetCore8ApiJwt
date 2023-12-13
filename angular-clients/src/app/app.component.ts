import { Component } from '@angular/core';
import { AuthorizeService, WeatherForecastService } from 'src/generated_endpoints/index';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-clients';
  constructor(){}

}
