using System;
using System.Collections.Generic;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Messages;
using Tamagotchi.Common.Models;

namespace Tamagotchi.SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SOAPService : ISOAPService
    {
        private readonly IAnimalBusiness _animalBusiness;
        private readonly ISessionBusiness _sessionBusiness;
        private readonly IUserBusiness _userBusiness;

        public SOAPService(IAnimalBusiness animalBusiness, ISessionBusiness sessionBusiness, IUserBusiness userBusiness)
        {
            this._animalBusiness = animalBusiness;
            this._sessionBusiness = sessionBusiness;
            this._userBusiness = userBusiness;

        }

        public MessageResponse<AnimalModel> CreateAnimal(MessageRequest<AnimalModel> value)
        {
            var messageResponse = new MessageResponse<AnimalModel>();
            //AUTENTICATION
            //AUTHORIZATION
            //ADD VALIDATIONS
            messageResponse.Body = new List<AnimalModel>
            {
                this._animalBusiness.Create(value.Body)
            };
            return messageResponse;
        }

        public MessageResponse<UserModel> CreateUser(MessageRequest<UserModel> value)
        {
            var messageResponse = new MessageResponse<UserModel>();
            //AUTENTICATION
            //AUTHORIZATION
            //ADD VALIDATIONS
            messageResponse.Body = new List<UserModel>
            {
                this._userBusiness.Create(value.Body)
            };
            return messageResponse;
        }

        public MessageResponse<AnimalModel> DeleteAnimal(MessageRequest<AnimalModel> value)
        {
            var messageResponse = new MessageResponse<AnimalModel>();
            //AUTENTICATION
            //AUTHORIZATION
            //ADD VALIDATIONS
            this._animalBusiness.Delete(value.Body);
            return messageResponse;
        }

        public MessageResponse<AnimalModel> GetAnimal(int id)
        {
            var messageResponse = new MessageResponse<AnimalModel>();
            //AUTENTICATION
            //AUTHORIZATION
            //ADD VALIDATIONS
            messageResponse.Body = new List<AnimalModel>
            {
                this._animalBusiness.Get(new AnimalModel{Id = id })
            };
            return messageResponse; 
        }

        public MessageResponse<UserModel> Login(MessageRequest<UserModel> value)
        {
            var messageResponse = new MessageResponse<UserModel>();
            //AUTENTICATION
            //AUTHORIZATION
            //ADD VALIDATIONS
            //ADD LOGIN;
            return messageResponse;
        }

        public MessageResponse<AnimalModel> UpdateAnimal(MessageRequest<AnimalModel> value)
        {
            var messageResponse = new MessageResponse<AnimalModel>();
            //AUTENTICATION
            //AUTHORIZATION
            //ADD VALIDATIONS
            messageResponse.Body = new List<AnimalModel>
            {
                this._animalBusiness.Update(value.Body)
            };
            return messageResponse;
        }

        public MessageResponse<UserModel> UpdateUser(MessageRequest<UserModel> value)
        {
            var messageResponse = new MessageResponse<UserModel>();
            //AUTENTICATION
            //AUTHORIZATION
            //ADD VALIDATIONS
            messageResponse.Body = new List<UserModel>
            {
                this._userBusiness.Update(value.Body)
            };
            return messageResponse;
        }
    }
}
