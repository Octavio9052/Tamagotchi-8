using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.Common.DataModels;
using System.Collections.Generic;

namespace Tamagotchi.DataAccessMongoTests
{
    [TestClass]
    public class PetDALTests
    {
        [TestMethod]
        public void Create()
        {
            var petDal = new PetDAL();
            var amount = petDal.GetAll("Pet").Count;
            
            var newPet = new Pet()
            {
                Nickname = "Gansito",
                OwnerId = 1,
                AnimalId = amount,
                Gender = Common.Enums.Gender.Male,
                Logs = { },
                CurrentGamePoints = { }
            };
            petDal.Create(newPet);

            Assert.AreEqual(amount + 1, petDal.GetAll("Pet").Count);
        }

        [TestMethod]
        public void ReadSingle()
        {
            var petDal = new PetDAL();
            var single = petDal.Get("5b1798478956300a507e83e9", "Pet");

            Assert.AreEqual("5b1798478956300a507e83e9", single.Id);
        }

        [TestMethod]
        public void ReadAll()
        {
            var petDal = new PetDAL();
            var all = petDal.GetAll("Pet");

            Assert.IsNotNull(all);
        }

        [TestMethod]
        public void Update()
        {
            var petDal = new PetDAL();
            var toUpdate = petDal.Get("5b1798478956300a507e83e9", "Pet");
            var preUpdate = new Pet()
            {
                Id = toUpdate.Id,
                DateCreated = toUpdate.DateCreated,
                LastModified = toUpdate.LastModified,
                Nickname = toUpdate.Nickname,
                Gender = toUpdate.Gender,
                AnimalId = toUpdate.AnimalId,
                CurrentGamePoints = toUpdate.CurrentGamePoints,
                Logs = toUpdate.Logs,
                OwnerId = toUpdate.OwnerId
            };


            toUpdate.Nickname = "Arturito" + DateTime.Now.ToString();
            petDal.Update(toUpdate);


            Assert.AreNotEqual(preUpdate, toUpdate);
        }

        [TestMethod]
        public void Delete()
        {
            var petDal = new PetDAL();
            var amount = petDal.GetAll("Pet").Count;
            var all = petDal.GetAll("Pet");
            List<Pet> list = new List<Pet>();

            foreach(var pet in all)
            {
                if (!pet.Id.Equals("5b1798478956300a507e83e9")) list.Add(pet);
            }


            Console.WriteLine(amount);

            if(list.Capacity > 3)
            {
                petDal.Delete(list[2].Id, "Pet");
                var newAmount = petDal.GetAll("Pet").Count;
                Assert.AreEqual(amount - 1, newAmount);
            }
            else
            {
                Assert.Inconclusive();
            }

        }
    }
}
