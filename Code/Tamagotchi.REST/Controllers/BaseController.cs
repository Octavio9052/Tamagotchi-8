using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Tamagotchi.Business.Business.Interfaces;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Messages;
using Tamagotchi.Common.Models;

namespace Tamagotchi.REST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController<TModel, TBusiness> : ApiController where TBusiness : IBaseBusiness<TModel> where TModel : BaseModel
    {
        protected readonly TBusiness Business;
        protected readonly ISessionBusiness SessionBusiness;

        public BaseController(TBusiness business, ISessionBusiness sessionBusiness)
        {
            Business = business;
            SessionBusiness = sessionBusiness;
        }

        // GET: api/Pet
        public IHttpActionResult Get()
        {
            var response = new MessageResponse<List<TModel>> {Body = Business.GetAll().ToList()};

            return Ok(response);
        }

        // GET: api/Pet/5
        public IHttpActionResult Get(string id)
        {
            var messageResponse = new MessageResponse<TModel> {Body = Business.Get(id)};

            return messageResponse.Body != default(TModel) ? (IHttpActionResult) Ok(messageResponse) : NotFound();
        }

        // POST: api/Pet
        public async Task<IHttpActionResult> Post([FromBody] MessageRequest<TModel> request)
        {
            MessageResponse<TModel> response;
            
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (SessionBusiness.ValidSession(request.UserToken) == null)
                return Unauthorized();

            try
            {
                var result = Business.Create(request.Body);

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

            if (SessionBusiness.ValidSession(request.UserToken) == null)
                return Unauthorized();

            try
            {
                var result = Business.Update(request.Body);

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
            if (SessionBusiness.ValidSession(request.UserToken) == null)
                return Unauthorized();

            Business.Delete(request.Body);

            return Ok();
        }
    }
}