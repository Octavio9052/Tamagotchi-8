import { Component, OnInit } from '@angular/core';
import { AnimalService } from '../shared/services/AnimalService';
import { AnimalModel } from '../shared/models/AnimalModel';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  animalsData: Observable<AnimalModel[]>;
  data;

  constructor(private readonly animalService: AnimalService) { }

  ngOnInit() {
    this.animalsData = this.animalService.getAnimalCards().pipe(map(res => res.Body));
    this.animalsData.subscribe(data => console.log(data));
  }

}
