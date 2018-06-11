//using System;
//using System.Collections.Generic;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Tamagotchi.Common.DataModels;
//using Tamagotchi.Common.Enums;
//using Tamagotchi.DataAccess.DALs;
//
//namespace Tamagotchi.DataAccessMongoTests
//{
//    [TestClass]
//    public class PetDALTests
//    {
//        [TestMethod]
//        public void Create()
//        {
//            var petDal = new PetDAL();
//            var amount = petDal.GetAll("Pet").Count;
//
//            var test = new Dictionary<string, double>();
//
//            test.Add("Estres", 104.00);
//            test.Add("Magia", 14.00);
//            test.Add("Educacion", 124.00);
//            test.Add("Tolerancia", 64.00);
//            test.Add("Paciencia", 34.00);
//            test.Add("Tristeza", 24.00);
//            test.Add("Hambre", 14.00);
//            test.Add("Experiencia", 54.00);
//
//
//            var newPet = new Pet
//            {
//                Nickname = "Gansito",
//                OwnerId = 1,
//                AnimalId = amount,
//                Gender = Gender.Male,
//                CurrentGamePoints = test
//            };
//            petDal.Create(newPet);
//
//            Assert.AreEqual(amount + 1, petDal.GetAll("Pet").Count);
//        }
//
//        [TestMethod]
//        public void ReadSingle()
//        {
//            var petDal = new PetDAL();
//            var single = petDal.Get("5b1798478956300a507e83e9", "Pet");
//
//            Assert.AreEqual("5b1798478956300a507e83e9", single.Id);
//        }
//
//        [TestMethod]
//        public void ReadAll()
//        {
//            var petDal = new PetDAL();
//            var all = petDal.GetAll("Pet");
//
//            Assert.IsNotNull(all);
//        }
//        
//        public void Update()
//        {
//            var petDal = new PetDAL();
//            var toUpdate = petDal.Get("5b1798478956300a507e83e9", "Pet");
//            var preUpdate = new Pet
//            {
//                Id = toUpdate.Id,
//                DateCreated = toUpdate.DateCreated,
//                LastModified = toUpdate.LastModified,
//                Nickname = toUpdate.Nickname,
//                Gender = toUpdate.Gender,
//                AnimalId = toUpdate.AnimalId,
//                CurrentGamePoints = toUpdate.CurrentGamePoints,
//                Logs = toUpdate.Logs,
//                OwnerId = toUpdate.OwnerId
//            };
//
//
//            toUpdate.Nickname = "Arturito" + DateTime.Now;
//            petDal.Update(toUpdate);
//
//
//            Assert.AreNotEqual(preUpdate, toUpdate);
//        }
//        
//        public void Delete()
//        {
//            var petDal = new PetDAL();
//            var amount = petDal.GetAll("Pet").Count;
//            var all = petDal.GetAll("Pet");
//            var list = new List<Pet>();
//
//            foreach(var pet in all)
//            {
//                if (!pet.Id.Equals("5b1798478956300a507e83e9")) list.Add(pet);
//            }
//
//
//            Console.WriteLine(amount);
//
//            if(list.Capacity > 3)
//            {
//                petDal.Delete(list[2].Id, "Pet");
//                var newAmount = petDal.GetAll("Pet").Count;
//                Assert.AreEqual(amount - 1, newAmount);
//            }
//            else
//            {
//                Assert.Inconclusive();
//            }
//
//        }
//    }
//}
