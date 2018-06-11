using System.Collections.Generic;
using AutoMapper;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class BaseBusiness<T, TData> : IBaseBusiness<T> where T : BaseModel where TData : IBaseEntity
    {
        protected readonly IBaseDAL<TData> BaseDal;
        protected readonly IMapper Mapper;


        protected BaseBusiness(IBaseDAL<TData> baseDAL, IMapper mapper)
        {
            BaseDal = baseDAL;
            Mapper = mapper;
        }

        public virtual T Create(T model)
        {
            var entity = Mapper.Map<TData>(model);
            return Mapper.Map<T>(BaseDal.Create(entity));
        }

        public virtual void Delete(string id)
        {
            BaseDal.Delete(id);
        }

        public virtual T Get(string id)
        {
            var entity = BaseDal.Get(id);
            return Mapper.Map<T>(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            var entities = BaseDal.GetAll();
            return Mapper.Map<ICollection<T>>(entities);
        }

        public virtual T Update(T model)
        {
            var entity = Mapper.Map<TData>(model);
            return Mapper.Map<T>(BaseDal.Update(entity));
        }
    }
}
