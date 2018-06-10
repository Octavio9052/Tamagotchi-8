﻿using System.Runtime.Serialization;
using System.ServiceModel;
using Tamagotchi.Common.Messages;
using Tamagotchi.Common.Models;

namespace Tamagotchi.SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISOAPService
    {

        [OperationContract]
        MessageResponse<UserModel> CreateUser(MessageRequest<UserModel> value);
        [OperationContract]
        MessageResponse<UserModel> Login(MessageRequest<UserModel> value);
        [OperationContract]
        MessageResponse<UserModel> UpdateUser(MessageRequest<UserModel> value);
        [OperationContract]
        MessageResponse<AnimalModel> CreateAnimal(MessageRequest<AnimalModel> value);
        [OperationContract]
        MessageResponse<AnimalModel> UpdateAnimal(MessageRequest<AnimalModel> value);
        [OperationContract]
        MessageResponse<AnimalModel> DeleteAnimal(MessageRequest<AnimalModel> value);
        [OperationContract]
        MessageResponse<AnimalModel> GetAnimal(int id);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
}