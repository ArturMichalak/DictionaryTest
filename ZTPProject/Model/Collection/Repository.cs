using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZTPProject.Model.Collection.Interfaces;
using ZTPProject.Model.Collection.Iterator;
using ZTPProject.Model.Collection.Iterator.Interface;

namespace ZTPProject.Model.Collection
{
    public class Repository<T> : IRepository<T>
    {
        private readonly List<T> items = new List<T>();
        #region Access Methods
        public T this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }
        public int Count => items.Count;
        public void Add(T o) => items.Add(o);
        public void Remove(T o) => items.Remove(o);
        public void Modify(T o, T n) => items[items.IndexOf(o)] = n;
        #endregion
        public IIterator<T> CreateIterator => new Enumerable<T>(this);
    }
}