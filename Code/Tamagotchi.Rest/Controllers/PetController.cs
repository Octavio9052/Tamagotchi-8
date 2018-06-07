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
    public class PetController : ApiController
    {
        private readonly IPetBusiness _petBusiness;

        public PetController(IPetBusiness petBusiness)
        {
            _petBusiness = petBusiness;
        }
        // GET: api/Pet
        public IEnumerable<PetModel> Get()
        {
            return _petBusiness.GetAll();
        }

        // GET: api/Pet/5
        public PetModel Get(string id)
        {
            return _petBusiness.Get(id);
        }

        // POST: api/Pet
        public PetModel Post([FromBody]PetModel value)
        {
            return _petBusiness.Create(value);
        }

        // PUT: api/Pet/5
        public PetModel Put(string id, [FromBody]PetModel value)
        {
            return _petBusiness.Update(value);
        }

        // DELETE: api/Pet/5
        public void Delete(string id)
        {
            _petBusiness.Delete(null);
        }
    }
}
