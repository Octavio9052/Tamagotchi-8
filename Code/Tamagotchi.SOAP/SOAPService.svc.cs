using System;
using System.CodeDom;
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
                var userId = ValidateSession(value.UserToken, out var error);

                if (!IsEntityValid(value.Body, out error) && string.IsNullOrEmpty(userId))
                    throw new Exception(error);

                value.Body.User.Id = userId;

                messageResponse.Body = await _animalBusiness.Create(value.Body);
            }
            catch (Exception e)
            {
                messageResponse.Error = "An Error has ocurred." + e;
            }

            return messageResponse;
        }

        public MessageResponse<AnimalModel> DeleteAnimal(MessageRequest<AnimalModel> value)
        {
            var messageResponse = new MessageResponse<AnimalModel>();
            try
            {
                var userId = ValidateSession(value.UserToken, out var error);

                if (!IsEntityValid(value.Body, out error) && string.IsNullOrEmpty(userId))
                    throw new Exception(error);

                _animalBusiness.Delete(value.Body.Id);
            }
            catch (Exception e)
            {
                messageResponse.Error = "An Error has ocurred." + e;
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
            catch (Exception e)
            {
                messageResponse.Error = "An Error has ocurred. " + e;
            }

            return messageResponse;
        }

        public async Task<MessageResponse<AnimalModel>> UpdateAnimal(MessageRequest<AnimalModel> value)
        {
            var messageResponse = new MessageResponse<AnimalModel>();
            try
            {
                var userId = ValidateSession(value.UserToken, out var error);

                if (!IsEntityValid(value.Body, out error) && string.IsNullOrEmpty(userId))
                    throw new Exception(error);
                messageResponse.Body = await _animalBusiness.Update(value.Body);
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
                var userId = ValidateSession(value.UserToken, out var error);

                if (!IsEntityValid(value.Body, out error) && string.IsNullOrEmpty(userId))
                    throw new Exception(error);

                messageResponse.Body = await _userBusiness.Update(value.Body);
            }
            catch (Exception e)
            {
                messageResponse.Error = "An Error has ocurred." + e;
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

        private static bool IsEntityValid<T>(T entity, out string error) where T : BaseModel
        {
            var validationResult = DataAnnotation.ValidateEntity(entity);
            error = null;
            if (validationResult.HasError) error = "Error in data validations.";
            return !validationResult.HasError;
        }

        private string ValidateSession(Guid userToken, out string error)
        {
            var validationResult = _sessionBusiness.ValidSession(userToken);
            error = null;

            if (validationResult != null) return validationResult.Id;
            
            error = "Session has expired";
            
            return string.Empty;
        }
    }
}