using System.Collections.Generic;
using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business
{
    public class BaseBusiness<T, Y> : IBaseBusiness<T, Y> where T : BaseModel where Y : BaseEntity
    {
        protected readonly IBaseDAL<Y> _baseDAL;
        protected readonly IMapper _mapper;


        public BaseBusiness(IBaseDAL<Y> baseDAL, IMapper mapper)
        {
            _baseDAL = baseDAL;
            _mapper = mapper;
        }

        public virtual T Create(T model)
        {
            var entity = _mapper.Map<Y>(model);
            return _mapper.Map<T>(_baseDAL.Create(entity));
        }

        public virtual void Delete(T model)
        {
            _baseDAL.Delete(model.Id);
        }

        public virtual T Get(T model)
        {
            var entity = _baseDAL.Get(model.Id);
            return _mapper.Map<T>(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            var entities = _baseDAL.GetAll();
            return _mapper.Map<ICollection<T>>(entities);
        }

        public virtual T Update(T model)
        {
            var entity = _mapper.Map<Y>(model);
            return _mapper.Map<T>(_baseDAL.Update(entity));
        }
    }
}
