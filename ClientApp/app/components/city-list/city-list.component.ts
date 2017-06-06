import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';


@Component({
    selector: 'city-list',
    templateUrl: './city-list.component.html'
})
export class CityListComponent {
    public currentCityName = 'Chicago';
    public newCityName = '';

    public cities: string[];
    private url: string;

    constructor(private http: Http, @Inject('ORIGIN_URL') originUrl: string) {
        this.url = originUrl;
        //this.cities = new Array();
    }

    public showCities(http: Http) {
        this.http.get(this.url + '/api/SampleData/GetCities').subscribe(result => {
            this.cities = result.json() as string[];
        });
    }

    // Adds a city to the local city list
    public addCity() {

        this.cities.push(this.newCityName);
        this.newCityName = '';
    }

}
