using System.Linq;
using Tamagotchi.Common.DataModels;
using Tamagotchi.DataAccess.Context;

namespace Tamagotchi.DataAccess.DALs.Interfaces
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
