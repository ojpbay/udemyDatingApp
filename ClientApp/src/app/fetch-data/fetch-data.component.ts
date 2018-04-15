import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  ngOnInit(): void {
    this.getWeatherForecasts();
  }
  public forecasts: WeatherForecast[];

  constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {
    
  }

  public displayedColumns = ['dateFormatted', 'temperatureC', 'temperatureF', 'summary'];

  getWeatherForecasts() {
    this._http.get<WeatherForecast[]>(this._baseUrl + 'api/SampleData').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
