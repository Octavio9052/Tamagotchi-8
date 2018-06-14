using System;
using System.Web.Http;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Messages;

namespace Tamagotchi.REST.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginBusiness _loginBusiness;
        private readonly ISessionBusiness _sessionBusiness;

        public LoginController(ILoginBusiness loginBusiness, ISessionBusiness sessionBusiness)
        {
            _loginBusiness = loginBusiness;
            _sessionBusiness = sessionBusiness;
        }

        public IHttpActionResult Post(LoginMessageRequest request)
        {
            var messageResponse = new LoginMessageResponse();

            try
            {
                messageResponse.UserToken = _loginBusiness.Login(request.Login);

                if (messageResponse.UserToken != default(Guid))
                    messageResponse.User = _sessionBusiness.ValidSession(messageResponse.UserToken);
                else
                    return Unauthorized();
            }
            catch (Exception)
            {
                return InternalServerError(new Exception("An error has occured"));
            }

            return Ok(messageResponse);
        }
    }
}