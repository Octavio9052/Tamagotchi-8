using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class UserDAL : BaseDAL<User>, IUserDAL
    {
        protected UserDAL(TamagotchiContext context) : base(context)
        {
        }
    }
}
