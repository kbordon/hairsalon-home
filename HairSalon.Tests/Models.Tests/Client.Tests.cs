using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.Models.Tests
{
  [TestClass]
  public class ClientTests : IDisposable
  {

    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
    }

    public ClientTests()
    {
        DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=kimberly_bordon_test;";
    }


  }
}
