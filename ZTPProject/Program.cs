using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZTPProject.Model.Observer.SessionObservers;
using ZTPProject.Model.Observer.TestObservers;
using ZTPProject.View;

[assembly: InternalsVisibleTo("ZTPProject.Test")]
namespace ZTPProject
{
    class Program
    {
        public static void App()
        {
            for (int i = 0; i < 2 * Console.WindowHeight; i++)
            {
                Console.WriteLine("a");
            }
            Achievements achievements = new Achievements();
            Session session = Session.GetSession();
            session.Register(achievements);
            session.DoOnAction(new KeyValuePair<string, object>("Session", 10));
        }
        static void Main(string[] args)
        {
            App();
        }
    }
}
