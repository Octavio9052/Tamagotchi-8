import { Injectable } from '@angular/core';

import { animalsMock } from '../mocks/animalsMock';

@Injectable()
export class AnimalService {

    private animals: any[] = [];

    constructor() { 
    }

    public pullAnimals(): void {
        var responseAnimals;

        responseAnimals = animalsMock;
        /*

        CALL TO REST SERVICE

         */
        
        this.animals = responseAnimals;
    }

    public getAnimals(){
        this.pullAnimals();


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