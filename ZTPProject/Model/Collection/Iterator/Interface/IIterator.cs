using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTPBlok.ModelBL.Collection.Interfaces;

namespace ZTPBlok.ModelBL.Collection.Iterator.Interface
{
    public interface IIterator<T>
    {
        T First();
        T Next();
        T CurrentItem();
        bool HasNext();
    }
}
