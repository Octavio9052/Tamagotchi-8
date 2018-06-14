using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Tamagotchi.Business.Business;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Messages;
using Tamagotchi.Common.Models;

namespace Tamagotchi.REST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : BaseController<UserModel, IUserBusiness>
    {
        private readonly ILoginBusiness _loginBusiness;

        public UserController(IUserBusiness business, ISessionBusiness sessionBusiness, ILoginBusiness loginBusiness) :
            base(business,
                sessionBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [Route("api/User/Create")]
        [HttpPost]
        public IHttpActionResult Create(LoginMessageRequest request)
        {
            var response = new LoginMessageResponse();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                response.User = Business.Create(request.Login, request.Name, null);
                response.UserToken = _loginBusiness.Login(request.Login);
            }
            catch (Exception ex)
            {
                response.Error = $"An Error has ocurred: {ex.Message}";
            }

            return response.Error != string.Empty
                ? (IHttpActionResult) Created($"api/pet/{response.User.Id}", response)
                : InternalServerError(new Exception(response.Error));
        }
    }
}