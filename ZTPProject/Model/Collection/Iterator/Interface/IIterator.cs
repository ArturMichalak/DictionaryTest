using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTPProject.Model.Collection.Interfaces;

namespace ZTPProject.Model.Collection.Iterator.Interface
{
    public interface IIterator<T>
    {
        T First { get; }
        T Next { get; }
        T Item { get; }
        bool HasNext { get; }
    }
}
