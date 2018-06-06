using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.Common.DataModels;
using System.Collections.Generic;

namespace Tamagotchi.DataAccessMongoTests
{
    [TestClass]
    public class LogDALTests
    {

        [TestMethod]
        public void Create()
        {
            var logDal = new LogDAL();

            var log = new Log
            {
                DateCreated = DateTime.Now,
                LastModified = DateTime.Now,
                Message = "Testing " + DateTime.Now,
                AnimalId = 2,
                UserId = 1
            };

            var amountLogs = logDal.GetAll("Log").Count;
            logDal.AddLogs(log);

            Assert.AreEqual(amountLogs + 1, logDal.GetAll("Log").Count);
        }

        [TestMethod]
        public void ReadSingle()
        {
            var logDAL = new LogDAL();

            var singleLog = logDAL.Get("5b17b3d589563041189598fd", "Log");

            Assert.IsNotNull(singleLog);
        }

        [TestMethod]
        public void ReadAll()
        {
            var logDAL = new LogDAL();

            var allLogs = logDAL.GetAll("Log");

            Assert.IsNotNull(allLogs);
        }

        [TestMethod]
        public void Update()
        {
            var logDAL = new LogDAL();
            var toUpdate = logDAL.Get("5b17b2b789563004ac2baa50", "Log");
            var notUpdate = new Log()
            {
                Id = toUpdate.Id,
                DateCreated = toUpdate.DateCreated,
                LastModified = toUpdate.LastModified,
                AnimalId = toUpdate.AnimalId,
                Message = toUpdate.Message,
                UserId = toUpdate.UserId
            };

            toUpdate.LastModified = DateTime.Now;
            logDAL.Update(toUpdate);

            Assert.AreNotEqual(notUpdate, toUpdate);
        }

        [TestMethod]
        public void Delete()
        {
            var logDAL = new LogDAL();
            var amount = logDAL.GetAll("Log").Count;
            var allLogs = logDAL.GetAll("Log");
            List<Log> list = new List<Log>();

            foreach(var item in allLogs)
            {
                list.Add(item);
            }


            if(list.Capacity > 3)
            {
                logDAL.Delete(list[2].Id, "Log");

                Assert.AreEqual(amount - 1, logDAL.GetAll("Log").Count);
            }
            else
            {
                Assert.Inconclusive();
            }
        }
    }
}
