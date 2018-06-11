import { AnimalModel } from "../../shared/models/AnimalModel";

export const animalsMock: AnimalModel[] = [
  {
    name: "Fox",
    creator: "Octavio",
    date: "2018/06/10",
    log: "The" + name + "is playing",
    time: "10:02",
    numberDownloads: 42,
    idleUri: "https://i.imgur.com/NNfje00.gif"
  },
  {
    name: "Dog",
    creator: "Jonathan",
    date: "2018/06/08",
    log: "The" + name + "is playing",
    time: "12:30",
    numberDownloads: 31,
    idleUri: "https://i.imgur.com/sumGNLN.gif"
  },
  {
    name: "Turtle",
    creator: "Alejandro",
    date: "2018/06/07",
    log: "The" + name + "is playing",
    time: "10:35",
    numberDownloads: 12,
    idleUri: "https://i.imgur.com/chU36ua.gif"
  },
  {
    name: "Cat",
    creator: "Andrea",
    date: "2018/06/05",
    log: "The" + name + "is playing",
    time: "11:04",
    numberDownloads: 35,
    idleUri: "https://i.imgur.com/vRQWS9E.gif"
  }
];

export var single = [
    {
      "name": "Fox",
      "value": 8940000
    },
    {
      "name": "Bear",
      "value": 5000000
    }
  ];