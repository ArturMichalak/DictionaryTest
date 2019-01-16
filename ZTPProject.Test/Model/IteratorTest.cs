using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZTPProject.Model.Collection;

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
            repository[3] = new KeyValuePair<char, int>('c', 1);
            var x = repository.CreateIterator;
            Assert.ThrowsException<InvalidOperationException>(() => x.Item);
            while (x.HasNext)
            {
                if (x.Next.Value == 0)
                    Assert.AreEqual('a', x.Item.Key);
                else
                    Assert.AreNotEqual('a', x.Item.Key);
            }
            Assert.AreEqual('a', x.First.Key);
            Assert.ThrowsException<InvalidOperationException>(action: () => x.Next);
        }
    }
}
