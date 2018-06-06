using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.Common.DataModels;
using System.Collections.Generic;

namespace Tamagotchi.DALTesting
{
    [TestClass]
    public class UserDALTests
    {

        [TestMethod]
        public void Create()
        {
            var userDal = new UserDAL();
            var user = new User
            {
                Name = "Octavio Armenta",
                PhotoUri = "http://127.0.0.1/",
                Pets = new System.Collections.Generic.Dictionary<int, string>()
                {
                    { 1, "Queso" },
                    {2, "Nacho" }
                },
                Creations = new System.Collections.Generic.Dictionary<int, string>()
                {
                    { 1, "Perro" },
                    {2, "Gato" }
                }
            };
            var numberOfUsers = userDal.GetAll().Count;
            var userR = userDal.Create(user);

            var number = userDal.GetAll().Count;

            Assert.AreEqual(numberOfUsers + 1, userDal.GetAll().Count);
        }


        [TestMethod]
        public void ReadSingle()
        {
            var userDAL = new UserDAL();

            var single = userDAL.Get(17);

            Assert.IsNotNull(single);
        }

        [TestMethod]
        public void ReadAll()
        {
            var userDAL = new UserDAL();

            var all = userDAL.GetAll();

            Assert.IsNotNull(all);
        }

        [TestMethod]
        public void Update()
        {
            var userDAL = new UserDAL();
            var toUpdate = userDAL.Get(17);
            var oldUser = new User()
            {
                Id = toUpdate.Id,
                Animal = toUpdate.Animal,
                DateCreated = toUpdate.DateCreated,
                LastModified = toUpdate.LastModified,
                Login = toUpdate.Login,
                LoginId = toUpdate.LoginId,
                Session = toUpdate.Session,
                Name = toUpdate.Name,
                PhotoUri = toUpdate.PhotoUri,
                Pets = toUpdate.Pets,
                Creations = toUpdate.Creations
            };

            toUpdate.LastModified = DateTime.Now;

            Assert.AreNotEqual(oldUser, toUpdate);
        }

        [TestMethod]
        public void Delete()
        {
            var userDAL = new UserDAL();
            var amount = userDAL.GetAll().Count;
            var allusr = userDAL.GetAll();

            List<User> list = new List<User>();

            foreach(var usr in allusr)
            {
                list.Add(usr);
            }

            if(list.Capacity > 3)
            {
                userDAL.Delete(list[2].Id);
                Assert.AreEqual(amount - 1, userDAL.GetAll().Count);
            }
            else
            {
                Assert.Inconclusive();
            }
        }
    }
}
