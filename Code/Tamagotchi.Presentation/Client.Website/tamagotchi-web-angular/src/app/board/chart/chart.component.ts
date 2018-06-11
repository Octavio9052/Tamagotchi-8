import { Component, OnInit } from '@angular/core';
import { animals, single } from './data';
import { ChartModel } from '../../shared/models/ChartModel';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {
  single: any[] = [
    {
      name: animals[0].name,
      value: animals[0].numberDownloads
    },
    {
      name: animals[1].name,
      value: animals[1].numberDownloads
    },
    {
      name: animals[2].name,
      value: animals[2].numberDownloads
    },
    {
      name: animals[3].name,
      value: animals[3].numberDownloads
    },
  ];
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
  }
}