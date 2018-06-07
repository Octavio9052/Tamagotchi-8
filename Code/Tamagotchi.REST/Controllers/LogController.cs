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
    public class LogController : ApiController
    {
        private readonly ILogBusiness _logBusiness;

        public LogController(ILogBusiness logBusiness)
        {
            this._logBusiness = logBusiness;
        }

        // GET: api/Animal
        public IEnumerable<LogModel> Get()
        {
            return _logBusiness.GetAll();
        }

        // GET: api/Animal/5
        public LogModel Get(int id)
        {
            return _logBusiness.Get(null);
        }

        // POST: api/Animal
        public LogModel Post([FromBody]LogModel value)
        {
            return _logBusiness.Create(value);
        }

        // PUT: api/Animal/5
        public LogModel Put(int id, [FromBody]LogModel value)
        {
            return _logBusiness.Update(value);
        }

        // DELETE: api/Animal/5
        public void Delete(int id)
        {
            _logBusiness.Delete(null);
        }
    }
}
