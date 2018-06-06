using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.Common.DataModels;

namespace Tamagotchi.DALTesting
{
    [TestClass]
    public class PetDALTests
    {
        [TestMethod]
        public void Create()
        {
            var petDal = new PetDAL();

            var amount = petDal.GetAll("Pet").Count;

            for (int i = 0; i < 4; i++) { 
                var newPet = new Pet()
                {
                    Nickname = "Gansito",
                    OwnerId = 7,
                    AnimalId = 343,
                    Gender = Common.Enums.Gender.Male,
                    Logs = { },
                    CurrentGamePoints = { }
                };
                petDal.Create(newPet);
            }

            var newUniquePet = new Pet()
            {
                Nickname = "Gansito n" + (amount + 5),
                OwnerId = 7,
                AnimalId = amount+5,
                Gender = Common.Enums.Gender.Female,
                Logs = { },
                CurrentGamePoints = { }
            };
            petDal.Create(newUniquePet);

            Assert.AreEqual(amount + 5, petDal.GetAll("Pet").Count);
        }

        [TestMethod]
        public void Read()
        {
            var petDal = new PetDAL();
            var all = petDal.GetAll("Pet");

            Assert.IsNotNull(all);
        }

        [TestMethod]
        public void Update()
        {
            var petDal = new PetDAL();

            var list = petDal.GetByUser(7);

            var updatePet = new Pet();

            foreach(var item in list)
            {
                updatePet = item;
            }

            updatePet.Nickname = "Pacnhito";
            updatePet.OwnerId = 300;

            petDal.Update(updatePet);

            Assert.IsTrue(updatePet.OwnerId == 300);
        }

        [TestMethod]
        public void Delete()
        {
            var petDal = new PetDAL();
            var amount = petDal.GetAll("Pet").Count;
            // petDal.Delete(0, "Pet");

            Assert.Equals(amount + 1, petDal.GetAll("Pet").Count);
        }
    }
}
