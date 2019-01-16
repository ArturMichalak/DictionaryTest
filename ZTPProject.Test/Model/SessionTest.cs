using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZTPBlok.ModelBL.Observer.SessionObservers;
using ZTPBlok.ModelBL.Observer.TestObservers;

namespace ZTPBlok.Tests.ModelBL
{
    [TestClass]
    public class SessionTest
    {
        [TestMethod]
        public void SessionTests()
        {
            Achievements achievements = new Achievements();
            Session session = Session.GetSession();
            session.DoOnAction(new KeyValuePair<string, object>("Profile", 1));
            session = Session.GetSession();
            session.Register(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 5));
            Assert.AreEqual(1,achievements.GetNew()[0]);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 5));
            Assert.AreEqual(2, achievements.GetNew()[0]);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 5));
            Assert.AreEqual(3, achievements.GetAll()[2]);
            session.DoOnAction(new KeyValuePair<string, object>("Error", 5));
            session.Unregister(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 5));
            Assert.AreEqual(3, achievements.GetNew()[0]);
            achievements.DoOnAction(new KeyValuePair<string, object>("Error", 5));
            session.Register(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 5));
            Assert.AreEqual(5, achievements.GetNew()[0]);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 10));
            Assert.AreEqual(7, achievements.GetNew()[0]);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 10));
            session.DoOnAction(new KeyValuePair<string, object>("Profile", 0));
            session = Session.GetSession();
            session.Register(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 20));
            Assert.AreEqual(4, achievements.GetNew()[0]);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 10));
            Assert.AreEqual(6, achievements.GetNew()[0]);
        }
    }
}
