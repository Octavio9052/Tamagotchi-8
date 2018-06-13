using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.DataAccess.DataModels;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.DataAccess.Context;

namespace Tamagotchi.DALTesting.Tests
{
    [TestClass]
    public class LoginDALTests
    {
        [TestMethod]
        public void Create()
        {
            //            var context = new TamagotchiContext();
            //            var loginDal = new LoginDAL(context);
            //            var user = new User {Name = "Octavio", Id = Guid.NewGuid()};
            //            var login = new Login()
            //            {
            //                Id = Guid.NewGuid(),
            //                Email = "armenta_octavio@hotmail.com",
            //                Password = "tamalesatun123",
            //                User = user
            //            };
            //            login.User = user;
            //            loginDal.Create(login);
            //            loginDal.Save();
            var context = new TamagotchiContext();
            var userdal = new UserDAL(context);
            var user = new User
            {
                Name = "octavio armenta",
                PhotoUri = "http://google.com"
            };
            var numberofusers = userdal.GetAll().Count;
            var userr = userdal.Create(user);
            userdal.Save();
            var loginDal = new LoginDAL(context);
            var login = new Login()
            {
                Email = "armenta_octavio@hotmail.com",
                Password = "tamalesatun123",
                UserId = userr.Id
            };
            loginDal.Create(login);
            loginDal.Save();

            var number = userdal.GetAll().Count;

            Assert.AreEqual(numberofusers + 1, userdal.GetAll().Count);
        }


        /* {
    [Required]
    [StringLength(150)]
    [Index("Index_Email", IsUnique = true)]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }

    [Required]
    public string UserId { get; set; }
    public virtual User User { get; set; }*/


        [TestMethod]
        public void ReadSingle()
        {

        }

        [TestMethod]
        public void ReadAll()
        {

        }

        [TestMethod]
        public void Update()
        {

        }

        [TestMethod]
        public void Delete()
        {

        }
    }
}
