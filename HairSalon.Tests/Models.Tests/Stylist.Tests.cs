using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class StylistTests : IDisposable
  {

    public void Dispose()
    {
      // add delete to models.
    }

    public StylistTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kimberly_bordon_test;";
    }

    [TestMethod]
    public void GetAll_StylistsEmptyAtFirst_0()
    {
      int result = Stylist.GetAll().Count;

      Assert.AreEqual(0, result);
    }
  }
}
