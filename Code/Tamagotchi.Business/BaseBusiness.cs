using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Entities;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business
{
    public class BaseBusiness<T, Y> : IBaseBusiness<T, Y> where T : BaseModel where Y : BaseEntity
    {
        protected readonly IBaseDAL<Y> _baseDAL;

        public BaseBusiness(IBaseDAL<Y> baseDAL)
        {
            this._baseDAL = baseDAL;
        }

        public virtual T Create(T model)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(T model)
        {
            throw new NotImplementedException();
        }

        public virtual T Get(T model)
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
