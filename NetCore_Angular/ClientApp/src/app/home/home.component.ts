import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public properties: Property[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<Property[]>(baseUrl + 'property/getProperties').subscribe(result => {
      this.properties = result;
    }, error => console.error(error));
  }

  save(property) {
    this.http.post<number>(this.baseUrl + 'property/saveProperty', property)
      .subscribe(data => {
        alert("saved with id: " + data);
      });    
  }
}

interface Property {
  address: string;
  listPrice: number;
  monthlyRent: number;
  grossYield: string;
  yearBuilt: number;
}
