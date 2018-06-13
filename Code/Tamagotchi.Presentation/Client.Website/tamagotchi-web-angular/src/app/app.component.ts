import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  grade = 0; // Out of 100

  title = 'Tamagotchi';
  tba;
  isSuccessful = false;
  hideGrade;

  ngOnInit() {
    this.setup()
    this.setupGrade(this.grade)
  }

  setup() {
    (this.grade === 0) ? this.hideGrade = true : this.hideGrade = false;
  }

  setupGrade(grade) {
    this.isSuccessful = this.evaluate(this.grade)
    this.tba = (this.isSuccessful === true) ? 'success' : 'failure';
    this.grade = grade / 2;
  }

  evaluate(grading: Number): boolean {
    return (grading > 69) ? true : false;
  }
}
