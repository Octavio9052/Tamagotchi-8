using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.DataModels;
using Tamagotchi.Common.Models;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.Business.Interfaces
{
    public class BaseMongoBusiness<T, Y> : IBaseMongoBusiness<T, Y> where T : BaseModel where Y : BaseDocument
    {
        protected readonly IBaseMongoDAL<Y> _baseMongoDAL;

        public BaseMongoBusiness(IBaseMongoDAL<Y> baseMongoDAL)
        {
            this._baseMongoDAL = baseMongoDAL;
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
