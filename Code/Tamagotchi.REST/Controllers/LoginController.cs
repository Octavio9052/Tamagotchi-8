using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;

namespace Tamagotchi.Rest.Controllers
{
    public class LoginController : ApiController
    {
        private readonly ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            this._loginBusiness = loginBusiness;
        }

        // GET: api/Animal
        public IEnumerable<LoginModel> Get()
        {
            return _loginBusiness.GetAll();
        }

        // GET: api/Animal/5
        public LoginModel Get(int id)
        {
            return _loginBusiness.Get(null);
        }

        // POST: api/Animal
        public LoginModel Post([FromBody]LoginModel value)
        {
            return _loginBusiness.Create(value);
        }

        // PUT: api/Animal/5
        public LoginModel Put(int id, [FromBody]LoginModel value)
        {
            return _loginBusiness.Update(value);
        }

        // DELETE: api/Animal/5
        public void Delete(int id)
        {
            _loginBusiness.Delete(null);
        }
    }
}
