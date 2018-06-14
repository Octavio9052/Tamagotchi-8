export interface AnimalModel {
    name: string;
    description: string;
    numberDownloads: number;
    isReady: Boolean;
    isActive: Boolean;
    idleUri: string;
    playUri: string;
    eatUri: string;
    sleepUri: string;
    PacketUri: string;
    UserId: string;
    animalId: string;
    dateCreated: string;
    lastModified: string;
}

//TODO: Datatypes?
//In table details: creator or owner, message of this pet or just the last animal.