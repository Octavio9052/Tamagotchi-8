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
    public class UserController : ApiController
    {

        private readonly IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        // GET: api/User
        public IEnumerable<UserModel> Get()
        {
            return _userBusiness.GetAll();
        }

        // GET: api/User/5
        public UserModel Get(int id)
        {
            return _userBusiness.Get(null);
        }

        // POST: api/User
        public UserModel Post([FromBody]UserModel value)
        {
            return _userBusiness.Create(value);
        }

        // PUT: api/User/5
        public UserModel Put(int id, [FromBody]UserModel value)
        {
            return _userBusiness.Update(value);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            _userBusiness.Delete(null);
        }
    }
}
