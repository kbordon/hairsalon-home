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

    [TestMethod]
    public void Equals_ReturnsTrueForSameName_Stylist()
    {
      Stylist firstStylist = new Stylist("Deva Jones", "123-456-7890");
      Stylist secondStylist = new Stylist("Deva Jones", "123-456-7890");

      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void Save_SavesStylistToDatabase_StylistList()
    {
      Stylist testStylist = new Stylist("Deva Jones", "123-456-7890");
      testStylist.Save();

      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      CollectionAssert.AreEqual(testList, result);
    }

    // [TestMethod]
    // public void GetAll_GetsAllStylistsInDatabase_List()
    // {
    //   Stylist testStylist = new Stylist("Davey Jones", "509-555-2342");
    //
    //   Assert.AreEqual(0, testStylist);
    // }
    // This test fulfills spec 2.

  }
}
