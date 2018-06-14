import { Component, OnInit } from '@angular/core';
import { AnimalService } from '../shared/services/AnimalService';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  animalsData;
  animalsData2;

  constructor(private readonly animalService: AnimalService) { }

  ngOnInit() {
    this.animalsData = this.animalService.getAnimalCards();
    this.animalsData2 = this.animalService.getTest();
  }

}
