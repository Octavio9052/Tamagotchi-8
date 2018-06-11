using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface IBaseRelationalDAL<T> :IBaseDAL<T> where T : BaseRelationalEntity
    {
        void Save();
    }
}