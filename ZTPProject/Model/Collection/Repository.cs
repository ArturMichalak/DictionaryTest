﻿using System;
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

        public int Count => items.Count;

        public IIterator<T> CreateIterator()
        {
            return new Enumerable<T>(this);
        }
        public T this[int index] => items[index];
        public void Add(T o)
        {
            items.Add(o);
        }
        public void Remove(T o)
        {
            items.Remove(o);
        }
    }
}