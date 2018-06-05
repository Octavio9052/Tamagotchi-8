import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { CardComponent } from './card/card.component';
import { DetailsComponent } from './details/details.component';
import { NavdocsComponent } from './navdocs/navdocs.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [NavbarComponent, CardComponent, DetailsComponent, NavdocsComponent]
})
export class BoardModule { }
