import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  ngOnInit(): void {
    this.getWeatherForecasts();
  }
  public forecasts: WeatherForecast[];

  constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string, private _snackBar: MatSnackBar) {
    
  }

  public displayedColumns = ['dateFormatted', 'temperatureC', 'temperatureF', 'summary'];

  getWeatherForecasts() {
    this._http.get<WeatherForecast[]>(this._baseUrl + 'api/SampleData').subscribe(result => {
      this.forecasts = result;
    }, error => {
      this._snackBar.open(error, null, {
        duration: 3000
      })
    })
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
