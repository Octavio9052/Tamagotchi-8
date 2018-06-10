using Tamagotchi.DataAccess.DataModels;

namespace Tamagotchi.DataAccess.DALs.Interfaces
{
    public interface ILoginDAL : IBaseDAL<Login>
    {
        Login Login(string username, string password);
    }
}
