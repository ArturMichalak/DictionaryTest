﻿using System;
using System.Collections.Generic;
using ZTPBlok.ModelBL.Collection;
using ZTPBlok.ModelBL.Collection.Iterator;
using ZTPBlok.ModelBL.Collection.Interfaces;
using ZTPBlok.ModelBL.Collection.Iterator.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ZTPProject.Tests.ModelBL
{
    [TestClass]
    public class IteratorTest
    {
        [TestMethod]
        public void CollectionTests()
        {
            var repository = new Repository<KeyValuePair<char, int>>();
            for (int i = 0; i < 10; i++)
            {
                repository.Add(new KeyValuePair<char, int>((char)('a' + i), i));
            }
            repository.Remove(repository[3]);
            var x = repository.CreateIterator();
            while (x.HasNext())
            {
                if (x.Next().Value == 0)
                    Assert.AreEqual('a', x.CurrentItem().Key);
                else
                    Assert.AreNotEqual('a', x.CurrentItem().Key);
            }
            Assert.AreEqual('a', x.First().Key);
            Assert.ThrowsException<InvalidOperationException>(action: () => x.Next());
        }
    }
}
