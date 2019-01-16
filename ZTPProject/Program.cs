using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZTPBlok.ModelBL.Observer.SessionObservers;
using ZTPBlok.ModelBL.Observer.TestObservers;
using ZTPProject.View;

[assembly: InternalsVisibleTo("ZTPProject.Test")]
namespace ZTPProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Achievements achievements = new Achievements();
            Session session = Session.GetSession();
            session.Register(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 10));
            BasicObjects.Dialog("Osiągnięcie nr " + achievements.GetNew()[0] + " zostało zdobyte",3);
        }
    }
}
