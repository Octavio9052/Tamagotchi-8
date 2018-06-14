import { Component, OnInit } from '@angular/core';
import { AnimalService } from '../shared/services/AnimalService';
import { AnimalModel } from '../shared/models/AnimalModel';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  animalsData;
  animalsData2: Observable<AnimalModel[]>;
  data;

  constructor(private readonly animalService: AnimalService) { }

  ngOnInit() {
    this.animalsData = this.animalService.getAnimalCards();
    this.animalsData2 = this.animalService.getTest();

    this.animalsData2.forEach(element => {
      console.log(element)
    });
  }

}
