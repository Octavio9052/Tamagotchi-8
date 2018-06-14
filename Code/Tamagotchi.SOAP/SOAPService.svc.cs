using System;
using System.Threading.Tasks;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Messages;
using Tamagotchi.Common.Models;
using Tamagotchi.SOAP.Helpers.DataValidations;

namespace Tamagotchi.SOAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SOAPService : ISOAPService
    {
        private readonly IAnimalBusiness _animalBusiness;
        private readonly ILoginBusiness _loginBusiness;
        private readonly ISessionBusiness _sessionBusiness;
        private readonly IUserBusiness _userBusiness;

        public SOAPService(IAnimalBusiness animalBusiness, ISessionBusiness sessionBusiness, IUserBusiness userBusiness,
            ILoginBusiness loginBusiness)
        {
            _animalBusiness = animalBusiness;
            _sessionBusiness = sessionBusiness;
            _userBusiness = userBusiness;
            _loginBusiness = loginBusiness;
        }

        public async Task<MessageResponse<AnimalModel>> CreateAnimal(MessageRequest<AnimalModel> value)
        {
            var messageResponse = new MessageResponse<AnimalModel>();
            try
            {
                if (IsEntityValid(value.Body, out var error) && ValidateSession(value.UserToken, out error))
                    messageResponse.Body = await _animalBusiness.Create(value.Body);
                else
                    messageResponse.Error = error;
            }
            catch (Exception)
            {
                messageResponse.Error = "An Error has ocurred.";
            }

            return messageResponse;
        }

        public MessageResponse<AnimalModel> DeleteAnimal(MessageRequest<AnimalModel> value)
        {
            var messageResponse = new MessageResponse<AnimalModel>();
            try
            {
                if (IsEntityValid(value.Body, out var error) && ValidateSession(value.UserToken, out error))
                    _animalBusiness.Delete(value.Body.Id);
                else
                    messageResponse.Error = error;
            }
            catch (Exception)
            {
                messageResponse.Error = "An Error has ocurred.";
            }

            return messageResponse;
        }

        public MessageResponse<AnimalModel> GetAnimal(string id)
        {
            var messageResponse = new MessageResponse<AnimalModel>
            {
                Body = _animalBusiness.Get(id)
            };
            return messageResponse;
        }

        public LoginMessageResponse Login(LoginMessageRequest value)
        {
            var messageResponse = new LoginMessageResponse();
            try
            {
                if (IsEntityValid(value.Login, out var error))
                {
                    messageResponse.UserToken = _loginBusiness.Login(value.Login);
                    if (messageResponse.UserToken != default(Guid))
                        messageResponse.User = _sessionBusiness.ValidSession(messageResponse.UserToken);
                    else
                        messageResponse.Error = "Invalid Credentials.";
                }
                else
                {
                    messageResponse.Error = error;
                }
            }
            catch (Exception)
            {
                messageResponse.Error = "An Error has ocurred.";
            }

            return messageResponse;
        }

        public async Task<MessageResponse<AnimalModel>> UpdateAnimal(MessageRequest<AnimalModel> value)
        {
            var messageResponse = new MessageResponse<AnimalModel>();
            try
            {
                if (IsEntityValid(value.Body, out var error) && ValidateSession(value.UserToken, out error))
                    messageResponse.Body = await _animalBusiness.Update(value.Body);
                else
                    messageResponse.Error = error;
            }
            catch (Exception)
            {
                messageResponse.Error = "An Error has ocurred.";
            }

            return messageResponse;
        }

        public async Task<MessageResponse<UserModel>> UpdateUser(MessageRequest<UserModel> value)
        {
            var messageResponse = new MessageResponse<UserModel>();
            try
            {
                if (IsEntityValid(value.Body, out var error) && ValidateSession(value.UserToken, out error))
                    messageResponse.Body = await _userBusiness.Update(value.Body);
                else
                    messageResponse.Error = error;
            }
            catch (Exception)
            {
                messageResponse.Error = "An Error has ocurred.";
            }

            return messageResponse;
        }

        public LoginMessageResponse CreateUser(LoginMessageRequest value)
        {
            var messageResponse = new LoginMessageResponse();
            try
            {
                if (IsEntityValid(value.Login, out var error))
                {
                    messageResponse.User = _userBusiness.Create(value.Login, value.Name, null);
                    messageResponse.UserToken = _loginBusiness.Login(value.Login);
                }
                else
                {
                    messageResponse.Error = error;
                }
            }
            catch (Exception)
            {
                messageResponse.Error = "An Error has ocurred.";
            }

            return messageResponse;
        }

        private bool IsEntityValid<T>(T entity, out string error) where T : BaseModel
        {
            var validationResult = DataAnnotation.ValidateEntity(entity);
            error = null;
            if (validationResult.HasError) error = "Error in data validations.";
            return !validationResult.HasError;
        }

        private bool ValidateSession(Guid userToken, out string error)
        {
            var validationResult = _sessionBusiness.ValidSession(userToken);
            error = null;

            if (validationResult == null) return false;

            error = "Session has expired";
            return true;
        }
    }
}