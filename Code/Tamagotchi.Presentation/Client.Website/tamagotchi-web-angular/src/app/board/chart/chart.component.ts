import { Component, OnInit } from '@angular/core';
import { AnimalService } from '../../shared/services/AnimalService';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {
  single: any[];
  view: any[];

  // options
  showXAxis = true;
  showYAxis = true;
  gradient = false;
  showLegend = true;
  showXAxisLabel = true;
  xAxisLabel = 'Animals';
  showYAxisLabel = true;
  yAxisLabel = 'Downloads';

  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
  };

  constructor(private readonly animalService: AnimalService) {
    Object.assign(this, {  })
  }

  onSelect(event) {
    console.log(event);
  }

  ngOnInit() {
    this.single = this.animalService.getAnimalDataForGraph();
  }
}