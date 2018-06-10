import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { DetailsComponent } from '../details/details.component';

@Component({
  selector: 'app-animal-card',
  templateUrl: './animal-card.component.html',
  styleUrls: ['./animal-card.component.css']
})
export class AnimalCardComponent implements OnInit {

  animalName: string;
  numberDownloads: number;
  creatorName: string;

  constructor(public dialog: MatDialog) { }

  ngOnInit() {
    this.animalName = "Fox";
    this.numberDownloads = Math.round((Math.random() * 100));
    this.creatorName = "Alejandro Cruz Jimenez"
  }

  openDialog() {
    let dialogRef = this.dialog.open(DetailsComponent, {
      width: '50%'
    });
  }
}