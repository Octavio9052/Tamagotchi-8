using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;
using AutoMapper;

namespace Tamagotchi.Business.Interfaces
{
    public class BaseMongoBusiness<T, Y> : IBaseMongoBusiness<T, Y> where T : BaseMnModel where Y : BaseDocument
    {
        protected readonly IBaseMongoDAL<Y> _baseMongoDAL;
        protected readonly IMapper _mapper;

        public BaseMongoBusiness(IBaseMongoDAL<Y> baseMongoDAL, IMapper mapper)
        {
            this._baseMongoDAL = baseMongoDAL;
            this._mapper = mapper;
        }

        public virtual T Create(T model)
        {
            var document = this._mapper.Map<Y>(model);
            return this._mapper.Map<T>(this._baseMongoDAL.Create(document));
        }

        public virtual void Delete(T model)
        {
            var document = this._mapper.Map<Y>(model);
            this._baseMongoDAL.Delete(document.Id, document.ToString());
        }

        public virtual T Get(string id)
        {
            return this._mapper.Map<T>(this._baseMongoDAL.Get(id, this._baseMongoDAL.ToString()));
        }

        public virtual ICollection<T> GetAll()
        {
            return this._mapper.Map<ICollection<T>>(this._baseMongoDAL.GetAll(_baseMongoDAL.ToString()));
        }

        public virtual T Update(T model)
        {
            var document = this._mapper.Map<Y>(model);
            return this._mapper.Map<T>(this._baseMongoDAL.Update(document));
        }
    }
}
