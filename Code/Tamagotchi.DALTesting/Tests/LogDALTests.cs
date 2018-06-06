using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.Common.DataModels;

namespace Tamagotchi.DALTesting
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

            Assert.AreEqual(amountLogs + 1 , logDal.GetAll("Log").Count);
        }
    }
}
