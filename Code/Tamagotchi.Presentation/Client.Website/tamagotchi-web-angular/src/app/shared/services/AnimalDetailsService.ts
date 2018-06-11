import { Injectable } from '@angular/core';

import { animalDetailsMock } from '../mocks/animalDetailsMock';

@Injectable()
export class AnimalDetailsService {

    // TODO: DELETE AFTER IMPLEMENTING SOAP SERVICE
    public getElementData() {
        return animalDetailsMock;
    }
}
