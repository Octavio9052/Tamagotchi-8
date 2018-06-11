import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatStepperModule } from "@angular/material/stepper";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";
import { BrowserModule } from "@angular/platform-browser";
import { NgxChartsModule } from "@swimlane/ngx-charts";
import { MatTableModule } from "@angular/material/table";
import { MatDialogModule } from "@angular/material/dialog";

import { DashboardComponent } from "./dashboard.component";
import { AnimalCardComponent } from "./animal-card/animal-card.component";
import { DocumentationComponent } from "./documentation/documentation.component";
import { ChartComponent } from "./chart/chart.component";
import { DetailsComponent } from "./details/details.component";

import { AnimalDetailsService } from "../shared/services/AnimalDetailsService";
import { AnimalService } from "../shared/services/AnimalService";
import { DoctosComponent } from './documentation/doctos/doctos.component';
import { DocdevComponent } from './documentation/docdev/docdev.component';

@NgModule({
  imports: [
    CommonModule,
    MatStepperModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    BrowserModule,
    NgxChartsModule,
    MatTableModule,
    MatDialogModule
  ],
  declarations: [
    DashboardComponent,
    AnimalCardComponent,
    DocumentationComponent,
    ChartComponent,
    DetailsComponent,
    DoctosComponent,
    DocdevComponent
  ],
  exports: [],
  providers: [
    AnimalDetailsService, 
    AnimalService
  ],
  entryComponents: [DetailsComponent]
})
export class BoardModule {}
