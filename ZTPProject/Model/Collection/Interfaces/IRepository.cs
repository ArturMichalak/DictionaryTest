using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTPBlok.ModelBL.Collection.Iterator.Interface;

namespace ZTPBlok.ModelBL.Collection.Interfaces
{
    public interface IRepository<T>
    {
        IIterator<T> CreateIterator();
    }
}
