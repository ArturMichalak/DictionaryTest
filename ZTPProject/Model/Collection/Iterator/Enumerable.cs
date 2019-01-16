using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZTPBlok.ModelBL.Collection.Interfaces;
using ZTPBlok.ModelBL.Collection.Iterator.Interface;

namespace ZTPBlok.ModelBL.Collection.Iterator
{
    public class Enumerable<T> : IIterator<T>
    {
        private readonly Repository<T> repository;
        private int index = -1;
        public Enumerable(Repository<T> repository)
        {
            this.repository = repository;
        }
        public T First() => repository[0];
        public T CurrentItem() => repository[index];
        public bool HasNext() => index + 1 < repository.Count;
        public T Next() => 
            HasNext() ? 
            repository[++index] : 
            throw new InvalidOperationException();
    }
}