import { Component, OnInit, Input } from '@angular/core';
import { MatDialog } from '@angular/material';
import { DetailsComponent } from '../details/details.component';
import { AnimalModel } from '../../shared/models/AnimalModel';

@Component({
  selector: 'app-animal-card',
  templateUrl: './animal-card.component.html',
  styleUrls: ['./animal-card.component.css']
})
export class AnimalCardComponent implements OnInit {

  animalName: string;
  numberDownloads: number;
  creatorName: string;
  idleUri: string;

  animalCards: any[];
  @Input() animalCard: AnimalModel;

  constructor(public dialog: MatDialog) { }

  ngOnInit() {
    this.animalName = this.animalCard.name;
    this.numberDownloads = this.animalCard.numberDownloads;
    this.creatorName = this.animalCard.creator;
    this.idleUri = this.animalCard.idleUri;
  }

  openDialog() {
    let dialogRef = this.dialog.open(DetailsComponent, {
      width: '50%'
    });
  }
}