import { Injectable } from '@angular/core';

import { animalDetailsMock } from '../mocks/animalDetailsMock';

import { AnimalModel } from '../models/AnimalModel';
import { AnimalDetails } from '../models/AnimalDetails'

@Injectable()
export class AnimalDetailsService {

    // TODO: string id
    public getLastTenLogsFromAnimal(id: string) {
        // Call to SOAP service

        // response here

        /*
        var singleAnimal: AnimalModel = {
            log: logFromAnimalReceivedFromSOAP 
        }
        */

        var singleAnimal: AnimalModel;


        // TODO: Change log model to contain the same structure?
        var tableData: AnimalDetails[] = [
            { username: 'Montreal', nickname: 'Morris', date: '2018/06/05', time: '14:05', message: "" },
            { username: 'Seudonimo', nickname: 'Nacho', date: '2018/06/05', time: '16:05', message: 'The dog was playing' },
            { username: 'Anivdelarev', nickname: 'Queso', date: '2018/06/05', time: '18:15', message: 'The fox was eating' },
            { username: 'Santiago', nickname: 'Salmon', date: '2018/06/05', time: '14:05', message: 'The cat was playing' },
            { username: 'Elias', nickname: 'Cat', date: '2018/06/05', time: '18:45', message: 'The fox was eating' },
            { username: 'Antonio', nickname: 'Bolo', date: '2018/06/05', time: '18:42', message: 'The cat was playing' },
            { username: 'Ulises', nickname: 'Lola', date: '2018/06/05', time: '18:12', message: 'The fox was eating' },
            { username: 'Andrea', nickname: 'Lilo', date: '2018/06/05', time: '18:42', message: 'The fox was eating' },
            { username: 'Alex', nickname: 'Stich', date: '2018/06/05', time: '18:35', message: 'The cat was playing' },
            { username: 'Luis', nickname: 'Gustavo', date: '2018/06/05', time: '11:05', message: 'The fox was eating' }
        ]
    }



    // TODO: DELETE AFTER IMPLEMENTING SOAP SERVICE
    public getElementData() {
        return animalDetailsMock;
    }
}
