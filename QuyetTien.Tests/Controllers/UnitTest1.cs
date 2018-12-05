using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuyetTien.Controllers;
using System.Web.Mvc;
using QuyetTien.Models;
using System.Collections.Generic;

namespace QuyetTien.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new CreateController();
            var result = controller.Index() as ViewResult;
            var db = new CS4PEEntities();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<BangSanPham>));
            Assert.AreEqual(db.BangSanPhams.Count(), ((List<BangSanPham>)result.Model).Count);
        }
    }
}
