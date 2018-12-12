using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuyetTien.Controllers;
using System.Web.Mvc;
using QuyetTien.Models;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Moq;
using System.IO;


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

        [TestMethod]
        public void TestCreate()
        {
            var controller = new CreateController();
            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewData["Loai_id"]);
            Assert.IsInstanceOfType(result.ViewData["Loai_id"], typeof(SelectList));
        }

        [TestMethod]
        public void TestDetails()
        {
            var controller = new CreateController();
            var context = new Mock<HttpContextBase>();
            context.Setup(c => c.Server.MapPath("~/App_Data")).Returns("~/App_Data");
            controller.ControllerContext = new ControllerContext(context.Object, new RouteData(), controller);

            var result = controller.Details("1") as FilePathResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("images", result.ContentType);
            var path = Path.Combine("~/App_Data", "1");
            Assert.AreEqual(path, result.FileName);
        }
    }
}
