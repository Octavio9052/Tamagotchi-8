using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;

namespace Tamagotchi.REST.Controllers
{
    public class UserController : BaseController<UserModel, IUserBusiness>
    {
        public UserController(IUserBusiness business, ISessionBusiness sessionBusiness) : base(business,
            sessionBusiness)
        {
        }
    }
}