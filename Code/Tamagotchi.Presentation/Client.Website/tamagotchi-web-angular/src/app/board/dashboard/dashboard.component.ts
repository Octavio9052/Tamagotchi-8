import { Component, OnInit } from '@angular/core';
import { animals } from '../chart/data';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  animalsData = animals;

  constructor() { }

  ngOnInit() {
  }

}
