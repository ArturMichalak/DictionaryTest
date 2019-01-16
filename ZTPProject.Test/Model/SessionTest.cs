using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZTPProject.Model.Observer.SessionObservers;
using ZTPProject.Model.Observer.TestObservers;
using ZTPProject.View;

namespace ZTPProject.Tests.Model
{
    [TestClass]
    public class SessionTest
    {
        [TestMethod]
        public void SessionTests()
        {
            Achievements achievements = new Achievements();
            Session session = Session.GetSession();
            session.DoOnAction(new KeyValuePair<string, object>("Profile", 3));
            session = Session.GetSession();
            session.Register(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 3));
            session.DoOnAction(new KeyValuePair<string, object>("Session", 2));
            session.DoOnAction(new KeyValuePair<string, object>("Session", 5));
            session.DoOnAction(new KeyValuePair<string, object>("Session", 5));
            Assert.AreEqual(3, achievements.GetAll()[2]);
            session.DoOnAction(new KeyValuePair<string, object>("Error", 5));
            session.Unregister(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 5));
            achievements.DoOnAction(new KeyValuePair<string, object>("Error", 5));
            session.Register(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 5));
            session.DoOnAction(new KeyValuePair<string, object>("Session", 10));
            session.DoOnAction(new KeyValuePair<string, object>("Session", 10));
            session.DoOnAction(new KeyValuePair<string, object>("Profile", 4));
            session = Session.GetSession();
            session.Register(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 20));
            session.DoOnAction(new KeyValuePair<string, object>("Session", 10));
            BasicObjects.Dialog("a", 2);
            Assert.ThrowsException<ArgumentException>(() => BasicObjects.Dialog("a", 0));
        }
    }
}
