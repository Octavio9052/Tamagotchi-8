import { Component, OnInit } from '@angular/core';
import { animals, single } from './data';
import { ChartModel } from '../../shared/models/ChartModel';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {
  chartData: ChartModel[];
  single: any[] = single;
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

  constructor() {
    Object.assign(this, {  })
  }

  onSelect(event) {
    console.log(event);
  }

  ngOnInit() {
    for(var i = 0; i < animals.length; i++){
      this.chartData[i] = {
        name: animals[i].name,
        value: animals[i].numberDownloads
      }
    }
    this.single = this.chartData;
  }
}