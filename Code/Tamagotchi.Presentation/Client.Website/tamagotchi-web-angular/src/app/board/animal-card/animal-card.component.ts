import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-animal-card',
  templateUrl: './animal-card.component.html',
  styleUrls: ['./animal-card.component.css']
})
export class AnimalCardComponent implements OnInit {

  animalName: string;
  numberDownloads: number;
  creatorName: string;

  constructor() { }

  ngOnInit() {
    this.animalName = "Fox";
    this.numberDownloads = Math.round((Math.random() * 100));
    this.creatorName = "Alejandro Cruz Jimenez"
  }

}
