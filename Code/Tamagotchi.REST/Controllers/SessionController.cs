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
    public class SessionController : ApiController
    {
        private readonly ISessionBusiness _sessionBusiness;

        public SessionController(ISessionBusiness sessionBusiness)
        {
            this._sessionBusiness = sessionBusiness;
        }

        // GET: api/User
        public IEnumerable<SessionModel> Get()
        {
            return _sessionBusiness.GetAll();
        }

        // GET: api/User/5
        public SessionModel Get(int id)
        {
            return _sessionBusiness.Get(null);
        }

        // POST: api/User
        public SessionModel Post([FromBody]SessionModel value)
        {
            return _sessionBusiness.Create(value);
        }

        // PUT: api/User/5
        public SessionModel Put(int id, [FromBody]SessionModel value)
        {
            return _sessionBusiness.Update(value);
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            _sessionBusiness.Delete(null);
        }
    }
}
