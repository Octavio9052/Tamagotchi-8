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

namespace Tamagotchi.Business
{
    public class BaseBusiness<T, Y> : IBaseBusiness<T, Y> where T : BaseModel where Y : BaseEntity
    {
        protected readonly IBaseDAL<Y> _baseDAL;
        protected readonly IMapper _mapper;


        public BaseBusiness(IBaseDAL<Y> baseDAL, IMapper mapper)
        {
            this._baseDAL = baseDAL;
            this._mapper = mapper;
        }

        public virtual T Create(T model)
        {
            var entity = this._mapper.Map<Y>(model);
            return _mapper.Map<T>(this._baseDAL.Create(entity));
        }

        public virtual void Delete(T model)
        {
            this._baseDAL.Delete(model.Id);
        }

        public virtual T Get(T model)
        {
            var entity = this._baseDAL.Get(model.Id);
            return this._mapper.Map<T>(entity);
        }

        public virtual ICollection<T> GetAll()
        {
            var entities = this._baseDAL.GetAll();
            return this._mapper.Map<ICollection<T>>(entities);
        }

        public virtual T Update(T model)
        {
            var entity = this._mapper.Map<Y>(model);
            return this._mapper.Map<T>(this._baseDAL.Update(entity));
        }
    }
}
