using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Tamagotchi.Business.Business.Interfaces;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Business
{
    public class BaseBusiness<T, TData, TDal> : IBaseBusiness<T> where T : BaseModel where TData : IBaseEntity where TDal : IBaseDAL<TData>
    {
        protected readonly TDal BaseDal;
        protected readonly IMapper Mapper;


        protected BaseBusiness(TDal baseDal, IMapper mapper)
        {
            BaseDal = baseDal;
            Mapper = mapper;
        }

        public virtual async Task<T> Create(T model)
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

        public virtual async Task<T> Update(T model)
        {
            var entity = Mapper.Map<TData>(model);
            return Mapper.Map<T>(BaseDal.Update(entity));
        }
    }
}
