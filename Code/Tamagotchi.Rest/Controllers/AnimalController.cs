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
    public class AnimalController : ApiController
    {

        private readonly IAnimalBusiness _animalBusiness;

        public AnimalController(IAnimalBusiness animalBusiness)
        {
            _animalBusiness = animalBusiness;
        }

        // GET: api/Animal
        public IEnumerable<AnimalModel> Get()
        {
            return _animalBusiness.GetAll();
        }

        // GET: api/Animal/5
        public AnimalModel Get(int id)
        {
            return _animalBusiness.Get(null);
        }

        // POST: api/Animal
        public AnimalModel Post([FromBody]AnimalModel value)
        {
            return _animalBusiness.Create(value);
        }

        // PUT: api/Animal/5
        public AnimalModel Put(int id, [FromBody]AnimalModel value)
        {
            return _animalBusiness.Update(value);
        }

        // DELETE: api/Animal/5
        public void Delete(int id)
        {
            _animalBusiness.Delete(null);
        }
    }
}
