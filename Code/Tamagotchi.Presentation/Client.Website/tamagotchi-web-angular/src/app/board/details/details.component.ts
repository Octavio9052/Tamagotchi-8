import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material';
import { AnimalDetails } from '../../shared/models/AnimalDetails';
import { AnimalDetailsService } from '../../shared/services/AnimalDetailsService';


@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  lastTenAnimalDetails: AnimalDetails[] = [];

  displayedColumns = ['username', 'nickname', 'date', 'time', 'message'];
  dataSource = new MatTableDataSource(this.animalDetailsService.getElementData());

  constructor(private readonly animalDetailsService: AnimalDetailsService) { }

  ngOnInit() {
    // dataSource = new MatTableDataSource(animalDetailsService.());
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

}