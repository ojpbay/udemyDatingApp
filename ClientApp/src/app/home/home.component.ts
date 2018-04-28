import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  registerMode = false;
  public forecasts: WeatherForecast[];

  constructor(private _http: HttpClient, private _snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.getWeatherForecasts();
   }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  getWeatherForecasts() {
    this._http.get<WeatherForecast[]>('http://localhost:2903/api/SampleData').subscribe(result => {
      this.forecasts = result;
    }, error => {
      this._snackBar.open(error, null, {
        duration: 3000
      });
    });
  }
}
  interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
