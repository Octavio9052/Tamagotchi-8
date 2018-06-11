import { Injectable } from '@angular/core';

@Injectable()
export class AnimalService {

    private animals: any[] = [];

    constructor() { }

    public pullAnimals(): void {
        var responseAnimals;

        /*

        CALL TO REST SERVICE

         */
        
        this.animals = responseAnimals;
    }

    public getAnimals(){
        return this.animals;
    }

    public getAnimalCards() {
        return this.getAnimals();
    }

    public getAnimalDataForGraph() {
        var animalsToGraph: any [] = [];

        
        for(var i = 0; i < this.animals.length; i++) {
            animalsToGraph[i] = { 
              name: this.animals[i].name, 
              value: this.animals[i].numberDownloads}
          }
          return animalsToGraph;
    }
}