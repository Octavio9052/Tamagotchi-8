using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Tamagotchi.Business.Business.Interfaces;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Messages;
using Tamagotchi.Common.Models;

namespace Tamagotchi.REST.Controllers
{
    public class BaseController<TModel, TBusiness> : ApiController where TBusiness : IBaseBusiness<TModel> where TModel : BaseModel
    {
        private readonly TBusiness _business;
        private readonly ISessionBusiness _sessionBusiness;

        public BaseController(TBusiness business, ISessionBusiness sessionBusiness)
        {
            _business = business;
            _sessionBusiness = sessionBusiness;
        }

        // GET: api/Pet
        public IHttpActionResult Get()
        {
            var response = new MessageResponse<List<TModel>> {Body = _business.GetAll().ToList()};

            return Ok(response);
        }

        // GET: api/Pet/5
        public IHttpActionResult Get(string id)
        {
            var messageResponse = new MessageResponse<TModel> {Body = _business.Get(id)};

            return messageResponse.Body != default(TModel) ? (IHttpActionResult) Ok(messageResponse) : NotFound();
        }

        // POST: api/Pet
        public async Task<IHttpActionResult> Post([FromBody] MessageRequest<TModel> request)
        {
            MessageResponse<TModel> response;
            
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (_sessionBusiness.ValidSession(request.UserToken) == null)
                return Unauthorized();

            try
            {
                var result = _business.Create(request.Body);

                response = new MessageResponse<TModel> {Body = await result};
            }
            catch (Exception)
            {
                response = new MessageResponse<TModel> {Error = "An error has ocurred"};
            }

            return response.Error != string.Empty
                ? (IHttpActionResult) Created($"api/pet/{response.Body.Id}", response)
                : InternalServerError(new Exception(response.Error));
        }

        // PUT: api/Pet/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] MessageRequest<TModel> request)
        {
            MessageResponse<TModel> response;

            if (!ModelState.IsValid) return BadRequest();

            if (_sessionBusiness.ValidSession(request.UserToken) == null)
                return Unauthorized();

            try
            {
                var result = _business.Update(request.Body);

                response = new MessageResponse<TModel> {Body = await result};
            }
            catch (Exception)
            {
                response = new MessageResponse<TModel> {Error = "An error has ocurred"};
            }

            return response.Error != string.Empty
                ? (IHttpActionResult) Ok(response)
                : InternalServerError();
        }

        // DELETE: api/Pet/5
        public IHttpActionResult Delete(MessageRequest<string> request)
        {
            if (_sessionBusiness.ValidSession(request.UserToken) == null)
                return Unauthorized();

            _business.Delete(request.Body);

            return Ok();
        }
    }
}