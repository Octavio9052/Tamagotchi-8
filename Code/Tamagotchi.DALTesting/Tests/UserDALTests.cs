using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.Common.Entities;

namespace Tamagotchi.DALTesting
{
    [TestClass]
    public class UserTest
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

    }
}
