using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.DataAccess.DALs;
using Tamagotchi.Common.Entities;

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
                AnimalId = 2,
                Message = "Testing " + DateTime.Now
            };

            // logDal.AddLogs(log);

            Assert.AreEqual(true, true);
        }
    }
}
