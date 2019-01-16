using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZTPProject.Model.Collection.Interfaces;
using ZTPProject.Model.Collection.Iterator.Interface;

namespace ZTPProject.Model.Collection.Iterator
{
    public class Enumerable<T> : IIterator<T>
    {
        private int index = -1;
        private readonly Repository<T> repository;
        #region Iterator Operations
        public Enumerable(Repository<T> repository) =>
            this.repository = repository;
        public bool HasNext =>
            index + 1 < repository.Count;
        public T First =>
            repository[0];
        public T Item =>
            index < 0 ?
            throw new InvalidOperationException() :
            repository[index];
        public T Next =>
            HasNext ?
            repository[++index] :
            throw new InvalidOperationException();
        #endregion
    }
}