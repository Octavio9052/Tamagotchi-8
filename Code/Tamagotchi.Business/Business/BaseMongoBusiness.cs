using System.Collections.Generic;
using AutoMapper;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Interfaces
{
    public class BaseMongoBusiness<T, Y> : IBaseMongoBusiness<T, Y> where T : BaseMnModel where Y : BaseDocument
    {
        protected readonly IBaseMongoDAL<Y> _baseMongoDAL;
        protected readonly IMapper _mapper;

        public BaseMongoBusiness(IBaseMongoDAL<Y> baseMongoDAL, IMapper mapper)
        {
            _baseMongoDAL = baseMongoDAL;
            _mapper = mapper;
        }

        public virtual T Create(T model)
        {
            var document = _mapper.Map<Y>(model);
            return _mapper.Map<T>(_baseMongoDAL.Create(document));
        }

        public virtual void Delete(T model)
        {
            var document = _mapper.Map<Y>(model);
            _baseMongoDAL.Delete(document.Id, document.ToString());
        }

        public virtual T Get(string id)
        {
            return _mapper.Map<T>(_baseMongoDAL.Get(id, _baseMongoDAL.ToString()));
        }

        public virtual ICollection<T> GetAll()
        {
            return _mapper.Map<ICollection<T>>(_baseMongoDAL.GetAll(_baseMongoDAL.ToString()));
        }

        public virtual T Update(T model)
        {
            var document = _mapper.Map<Y>(model);
            return _mapper.Map<T>(_baseMongoDAL.Update(document));
        }
    }
}
