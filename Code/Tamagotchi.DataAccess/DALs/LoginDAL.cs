using System.Linq;
using Tamagotchi.DataAccess.Context;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs.Interfaces;

namespace Tamagotchi.DataAccess.DALs
{
    public class LoginDAL : BaseDAL<Login>, ILoginDAL
    {
        public Login Login(string username, string password)
        {
            var login = Set.FirstOrDefault(x => (x.Email == username) && (x.Password == password));

            return login;
        }

        protected LoginDAL(TamagotchiContext context) : base(context)
        {
        }
    }
}
