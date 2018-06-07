using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.Common.Enums;
using Tamagotchi.Common.Exceptions;
using Tamagotchi.Common.Messages;


namespace Tamagotchi.REST.Controllers
{
    public class PetController : ApiController
    {
        private readonly IPetBusiness _petBusiness;
        private readonly ISessionBusiness _sessionBusiness;

        public PetController(IPetBusiness petBusiness, ISessionBusiness sessionBusiness)
        {
            this._petBusiness = petBusiness;
            this._sessionBusiness = sessionBusiness;
        }


        // GET: api/Pet
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Pet/5
        public HttpResponseMessage Get(string id)
        {
            var messageResponse = new MessageResponse<PetModel>();
            var statusCode = HttpStatusCode.OK;

            try
            {
                var pet = this._petBusiness.Get(id);

                if (pet.Owner.Id != pet.Owner.Session.UserId) throw new ForbiddenExceptions();

                messageResponse.Body = new List<PetModel>
                {
                    pet
                };
            }
            catch (Exception e)
            {
                messageResponse.Errors = new List<string> { e.Message };
                if (e is ForbiddenExceptions || e is InvalidSessionExceptions) statusCode = HttpStatusCode.Forbidden;
                else if (e is BusinessLayerExceptions) statusCode = HttpStatusCode.BadRequest;
                else statusCode = HttpStatusCode.InternalServerError;
            }

            return Request.CreateResponse(statusCode, messageResponse, "application/json");
        }

        // POST: api/Pet
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pet/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pet/5
        public void Delete(int id)
        {
        }
    }
}
