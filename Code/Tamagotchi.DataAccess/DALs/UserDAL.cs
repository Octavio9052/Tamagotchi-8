using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class UserDAL : BaseDAL<User>, IUserDAL
    {
        public UserDAL(TamagotchiContext context) : base(context)
        {
        }
    }
}
