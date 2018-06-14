import { Injectable } from '@angular/core';

import { animalsMock } from '../mocks/animalsMock';
import { AnimalModel } from '../models/AnimalModel';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AnimalService {

    private animals: any[] = [];
    private allAnimals: AnimalModel[] = [];

    private apiAnimals = "http://http://rest9052.azurewebsites.net/api/animal";

    public test: Observable<AnimalModel[]>;

    constructor(private http: HttpClient) {
    }

    public pullAnimals(): void {
        var responseAnimals;

        responseAnimals = animalsMock;
        /*

        CALL TO REST SERVICE

         */
        this.http
            .get(this.apiAnimals).subscribe((data) => {
                this.map(data);
            })



        this.animals = responseAnimals;
    }

    map(data){
        let i = 0;
        data.forEach(element => {
            this.test[i] = element;
            i++
            console.log(element);
        });
    }

    public getAnimals() {
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
        var animalsToGraph: any[] = [];


        for (var i = 0; i < this.animals.length; i++) {
            animalsToGraph[i] = {
                name: this.animals[i].name,
                value: this.animals[i].numberDownloads
            }
        }
        return animalsToGraph;
    }
}