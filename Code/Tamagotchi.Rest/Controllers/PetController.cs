using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Exceptions;
using Tamagotchi.Common.Messages;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;

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
        public IHttpActionResult Get()
        {
            var response = new MessageResponse<List<PetModel>> {Body = _petBusiness.GetAll().ToList()};

            return Ok(response);
        }

        // GET: api/Pet/5
        public IHttpActionResult Get(string id)
        {
            var messageResponse = new MessageResponse<PetModel> {Body = _petBusiness.Get(id)};

            return messageResponse.Body != default(PetModel) ? (IHttpActionResult) Ok(messageResponse) : NotFound();
        }

        // POST: api/Pet
        public IHttpActionResult Post([FromBody] MessageRequest<PetModel> request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_sessionBusiness.ValidSession(request.UserToken) == null)
                return Unauthorized();

            var result = _petBusiness.Create(request.Body);

            var response = new MessageResponse<PetModel> {Body = result};

            return response.Error != string.Empty
                ? (IHttpActionResult) Created($"api/pet/{response.Body.Id}", response)
                : InternalServerError();
        }

        // PUT: api/Pet/5
        public IHttpActionResult Put(int id, [FromBody] MessageRequest<PetModel> request)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (_sessionBusiness.ValidSession(request.UserToken) == null)
                return Unauthorized();

            var result = _petBusiness.Update(request.Body);

            var response = new MessageResponse<PetModel> {Body = result};

            return response.Error != string.Empty
                ? (IHttpActionResult) Ok(response)
                : InternalServerError();
        }

        // DELETE: api/Pet/5
        public IHttpActionResult Delete(MessageRequest<string> request)
        {
            if (_sessionBusiness.ValidSession(request.UserToken) == null)
                return Unauthorized();

            _petBusiness.Delete(request.Body);

            return Ok();
        }
    }
}