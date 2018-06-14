import { Injectable } from '@angular/core';

import { animalsMock } from '../mocks/animalsMock';
import { AnimalModel } from '../models/AnimalModel';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AnimalService {

    private animals: any[] = [];
    private allAnimals: AnimalModel[] = [];

    private apiAnimals = "http://localhost:65200/api/animal";

    public test;

    constructor(private http: HttpClient) { 
    }

    public pullAnimals(): void {
        var responseAnimals;

        responseAnimals = animalsMock;
        /*

        CALL TO REST SERVICE

         */
        this.test = this.http.get(this.apiAnimals);


        
        this.animals = responseAnimals;
    }

    public getAnimals(){
        this.pullAnimals();


        return this.animals;
    }

    public getTest() {
        this.pullAnimals();
        return this.test;
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