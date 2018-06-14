export interface AnimalModel {
    Name: string;
    Description: string;
    TimesDownloaded: number;
    IsReady: Boolean;
    IsActive: Boolean;
    IdleUri: string;
    PlayUri: string;
    EatUri: string;
    SleepUri: string;
    PacketUri: string;
    UserId: string;
    AnimalId: string;
    DateCreated: string;
    LastModified: string;
}

//TODO: Datatypes?
//In table details: creator or owner, message of this pet or just the last animal.