using ZTPBlok.ModelBL.Observer.Interfaces;
using ZTPBlok.ModelBL.Collection;
using ZTPBlok.ModelBL.Collection.Iterator;
using System.Collections.Generic;
using System;

namespace ZTPBlok.ModelBL.Observer.TestObservers
{
    public class Session : ISubject, IObserver
    {
        #region Basic
        int Score = 0;
        #endregion
        #region Subject propeties
        Repository<IObserver> repository = new Repository<IObserver>();
        #endregion
        #region Singleton propeties
        private static int instances = 5;
        public static int current = 0;
        private static readonly Session[] instance = new Session[instances];
        private static object padlock = new object();
        #endregion
        #region Singleton Methods
        private Session() {}
        public static Session GetSession()
        {
            current %= instances;
            if (instance[current] == null)
            {
                lock (padlock)
                {
                    if (instance[current] == null)
                    {
                        instance[current] = new Session();
                    }
                }
            }
            return instance[current];  
        }
        #endregion
        #region Observer Methods
        public void DoOnAction(KeyValuePair<string, Object> results)
        {
            if (results.Value is int)
            {
                switch (results.Key)
                {
                    case "Session":
                        Score += (int)results.Value;
                        Notify(new KeyValuePair<string, object>("Achievement", Score));
                        break;
                    case "Profile":
                        current = (int)results.Value;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion
        #region Subject Methods
        public void Notify(KeyValuePair<string, Object> results)
        {
            var x = repository.CreateIterator();
            while(x.HasNext())
            {
                x.Next().DoOnAction(results);
            }
        }

        public void Register(IObserver o)
        {
            repository.Add(o);
        }

        public void Unregister(IObserver o)
        {
            repository.Remove(o);
        }
        #endregion
    }
}