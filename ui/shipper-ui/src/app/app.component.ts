import { Component, OnInit } from '@angular/core';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'shipper-ui';
  shippers: any[] = [];
  shipments: any[] = [];
  randomQuote: any = {};
  quotes: any = {};
  toggleShipmentAndQuote = false;
  constructor(private service: AppService) {
  }

  ngOnInit(): void {
    this.getShippers();
  }

  getRandomQuote() {
    this.service.getRandomQuote().subscribe(x => {
      this.randomQuote = x;
    });
  }

  getQuotes() {
    this.service.getQuotesByAuthor('albert-einstein').subscribe(x => {
      this.quotes = x;
      this.toggleShipmentAndQuote = true;
    })
  }

  getShippers() {
    this.service.getShippers().subscribe(x => {
      this.shippers = x;
    })
  }

  getShipperDetails(shipperId: number) {
    this.service.getShipmentsByShipper(shipperId).subscribe(x => this.shipments = x);
    this.toggleShipmentAndQuote = false;
  }
}
