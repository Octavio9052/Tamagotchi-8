import { Component, OnInit } from '@angular/core';
import {MatTableDataSource} from '@angular/material';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  displayedColumns = ['username', 'nickname', 'date', 'time', 'message'];
  dataSource = new MatTableDataSource(ELEMENT_DATA);

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // MatTableDataSource defaults to lowercase matches
    this.dataSource.filter = filterValue;
  }

}
// TODO: Datetime?
export interface RecordLog {
  username: string;
  nickname: string;
  date: string;
  time: string;
  message: string;
}

const ELEMENT_DATA: RecordLog[] = [
  {username: 'Montreal', nickname: 'Morris', date: '2018/06/05', time: '14:05', message: 'The cat was playing'},
  {username: 'Seudonimo', nickname: 'Nacho', date: '2018/06/05', time: '16:05', message: 'The dog was playing'},
  {username: 'Anivdelarev', nickname: 'Queso', date: '2018/06/05', time: '18:15', message: 'The fox was eating'},
  {username: 'Santiago', nickname: 'Salmon', date: '2018/06/05', time: '14:05', message: 'The cat was playing'},
  {username: 'Elias', nickname: 'Cat', date: '2018/06/05', time: '18:45', message: 'The fox was eating'},
  {username: 'Antonio', nickname: 'Bolo', date: '2018/06/05', time: '18:42', message: 'The cat was playing'},
  {username: 'Ulises', nickname: 'Lola', date: '2018/06/05', time: '18:12', message: 'The fox was eating'},
  {username: 'Andrea', nickname: 'Lilo', date: '2018/06/05', time: '18:42', message: 'The fox was eating'},
  {username: 'Alex', nickname: 'Stich', date: '2018/06/05', time: '18:35', message: 'The cat was playing'},
  {username: 'Luis', nickname: 'Gustavo', date: '2018/06/05', time: '11:05', message: 'The fox was eating'},
];