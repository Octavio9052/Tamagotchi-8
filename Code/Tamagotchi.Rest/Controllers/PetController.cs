using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Exceptions;
using Tamagotchi.Common.Messages;
using Tamagotchi.Common.Models;

namespace Tamagotchi.REST.Controllers
{
    public class PetController : ApiController
    {
        private readonly IPetBusiness _petBusiness;
        private readonly ISessionBusiness _sessionBusiness;

        public PetController(IPetBusiness petBusiness, ISessionBusiness sessionBusiness)
        {
            _petBusiness = petBusiness;
            _sessionBusiness = sessionBusiness;
        }


        // GET: api/Pet
        public IEnumerable<string> Get()
        {
            return new[] {"value1", "value2"};
        }

        // GET: api/Pet/5
        public IHttpActionResult Get(string id)
        {
            var result = NotFound();

            var messageResponse = new MessageResponse<PetModel>();

            try
            {
                var pet = _petBusiness.Get(id);

                if (pet.Owner.Id != pet.Owner.Session.UserId) throw new ForbiddenExceptions();

                messageResponse.Body = pet;
            }
            catch (Exception e)
            {
                messageResponse.Errors = new List<string> {e.Message};
            }

            return result;
        }

        // POST: api/Pet
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Pet/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Pet/5
        public void Delete(int id)
        {
        }
    }
}