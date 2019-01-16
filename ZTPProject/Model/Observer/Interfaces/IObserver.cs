using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTPProject.Model.Observer.Interfaces
{
    public interface IObserver
    {
        void DoOnAction(KeyValuePair<string, Object> data);
    }
}
