using System.Collections.Generic;
using ZTPProject.Model.Collection;
using ZTPProject.Model.Observer.Interfaces;
using ZTPProject.View;
using AV = System.Collections.Generic.KeyValuePair<int, bool>;

namespace ZTPProject.Model.Observer.SessionObservers
{
    public class Achievements : IObserver
    {
        #region Basic
        private Repository<KeyValuePair<int, bool>> IDs;
        public Achievements()
        {
            IDs = new Repository<KeyValuePair<int, bool>>();
        }
        #endregion
        #region Geting models
        public List<int> GetNew()
        {
            var response = new List<int>();
            var x = IDs.CreateIterator;
            while(x.HasNext)
            {
                if (x.Next.Value)
                {
                    response.Add(x.Item.Key);
                    IDs.Modify(x.Item,  new AV(x.Item.Key, false));
                }
            }
            return response;
        }

        public List<int> GetAll()
        {
            var response = new List<int>();
            var x = IDs.CreateIterator;
            while (x.HasNext)
            {
                response.Add(x.Next.Key);
            }
            return response;
        }
        #endregion
        #region Checking changes
        public void DoOnAction(KeyValuePair<string, object> data)
        {
            if (data.Key != "Achievement") return;
            if (data.Value is int)
            {
                int value = (int)data.Value;
                switch (value)
                {
                    case var expression when value >= 35:
                        IDs.Add(new AV(7, true));
                        break;
                    case var expression when value >= 30:
                        IDs.Add(new AV(6, true));
                        break;
                    case var expression when value >= 25:
                        IDs.Add(new AV(5, true));
                        break;
                    case var expression when value >= 20:
                        IDs.Add(new AV(4, true));
                        break;
                    case var expression when value >= 15:
                        IDs.Add(new AV(3, true));
                        break;
                    case var expression when value >= 10:
                        IDs.Add(new AV(2, true));
                        break;
                    case var expression when value >= 5:
                        IDs.Add(new AV(1, true));
                        break;
                    default:
                        break;
                }
            }

            var x = GetNew();
            if (x.Count > 0)
            {
                BasicObjects.Dialog("Osiągnięcie nr " +x[x.Count - 1] +" zostało zdobyte", 3);
            }
        }
        #endregion
    }
}