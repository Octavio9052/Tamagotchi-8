import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatStepperModule } from '@angular/material/stepper';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

import { DashboardComponent } from './dashboard/dashboard.component';
import { AnimalCardComponent } from './animal-card/animal-card.component';
import { DocumentationComponent } from './documentation/documentation.component';


@NgModule({
  imports: [
    CommonModule,
    MatStepperModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule
  ],
  declarations: [
    DashboardComponent,
    AnimalCardComponent,
    DocumentationComponent
  ],
  exports: []
})
export class BoardModule { }
