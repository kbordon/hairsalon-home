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
      Stylist.ClearAll();
    }

    public StylistTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=kimberly_bordon_test;";
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
    //Fulfills spec for adding and viewing stylist functionality.

    [TestMethod]
    public void Find_FindsStylistInDatabase_Stylist()
    {
      Stylist testStylist = new Stylist("Felipe Hernandez", "971-455-6703");
      testStylist.Save();

      Stylist foundStylist = Stylist.Find(testStylist.Id);

      Assert.AreEqual(testStylist, foundStylist);
    }
    //Fulfills spec to view specifc stylist.

    [TestMethod]
    public void Update_UpdatesStylistNameandPhoneNumberInstanceAndInDataBase_String()
    {
        Stylist testStylist = new Stylist("Deva Jones", "123-456-7890");
        testStylist.Save();

        testStylist.Update("Delaney Jensen", "111-222-3333");
        Stylist databaseStylist = Stylist.Find(testStylist.Id);

        Assert.AreEqual("Delaney Jensen", testStylist.Name);
        Assert.AreEqual("111-222-3333", testStylist.Phone);
        Assert.AreEqual(testStylist, databaseStylist);
    }
    //Fulfills spec to update a specific stylist's info.

    [TestMethod]
    public void Delete_DeletesStylistInDatabase_Stylist()
    {
        Stylist testStylist = new Stylist("Deva Jones", "123-456-7890");
        testStylist.Save();
        Stylist testStylist2 = new Stylist("Felipe Hernandez", "971-455-6703");
        testStylist2.Save();

        testStylist.Delete();

        List<Stylist> result = Stylist.GetAll();

        Assert.AreEqual(testStylist2, result[0]);
    }

  }
}
