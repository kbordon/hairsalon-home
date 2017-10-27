using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Tests
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
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=kimberly_bordon_test;";
    }

    [TestMethod]
    public void Method_Description_ExpectedValue()
    {
      Assert.AreEqual(var1, method(input));
    }
  }
}
