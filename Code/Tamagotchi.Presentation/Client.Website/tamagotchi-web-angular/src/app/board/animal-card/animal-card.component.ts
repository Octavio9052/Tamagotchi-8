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
    this.animalName = this.animalCard.Name;
    this.numberDownloads = this.animalCard.TimesDownloaded;
    this.creatorName = this.animalCard.UserId;
    this.idleUri = this.animalCard.IdleUri;
  }

  openDialog() {
    let dialogRef = this.dialog.open(DetailsComponent, {
      width: '50%'
    });
  }
}