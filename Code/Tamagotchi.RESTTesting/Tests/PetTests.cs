using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tamagotchi.Rest.Controllers;
using Tamagotchi.Business.Interfaces;
using Tamagotchi.Common.Models;

namespace Tamagotchi.RESTTesting
{
    [TestClass]
    public class PetTests
    {
        [TestMethod]
        public void GetSingle()
        {
            var petController = new PetController();
        }
    }
}
