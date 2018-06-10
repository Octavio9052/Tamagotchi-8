import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatStepperModule } from '@angular/material/stepper';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { BrowserModule } from '@angular/platform-browser';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { MatTableModule } from '@angular/material/table';


import { DashboardComponent } from './dashboard/dashboard.component';
import { AnimalCardComponent } from './animal-card/animal-card.component';
import { DocumentationComponent } from './documentation/documentation.component';
import { ChartComponent } from './chart/chart.component';
import { DetailsComponent } from './details/details.component';


@NgModule({
  imports: [
    CommonModule,
    MatStepperModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    BrowserModule,
    NgxChartsModule,
    MatTableModule
  ],
  declarations: [
    DashboardComponent,
    AnimalCardComponent,
    DocumentationComponent,
    ChartComponent,
    DetailsComponent
  ],
  exports: []
})
export class BoardModule { }
