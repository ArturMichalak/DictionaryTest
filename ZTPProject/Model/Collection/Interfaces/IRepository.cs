using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTPProject.Model.Collection.Iterator.Interface;

namespace ZTPProject.Model.Collection.Interfaces
{
    public interface IRepository<T>
    {
        IIterator<T> CreateIterator();
    }
}
