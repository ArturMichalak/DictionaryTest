using System.Collections.Generic;
using ZTPProject.Model.Collection;
using ZTPProject.Model.Observer.Interfaces;
using ZTPProject.View;

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
            var x = IDs.CreateIterator();
            while(x.HasNext())
            {
                if (x.Next().Value)
                {
                    response.Add(x.CurrentItem().Key);
                    var tmp = x.CurrentItem().Key;
                    IDs.Remove(x.CurrentItem());
                    IDs.Add(new KeyValuePair<int, bool>(tmp, false));
                }
            }
            return response;
        }

        public List<int> GetAll()
        {
            var response = new List<int>();
            var x = IDs.CreateIterator();
            while (x.HasNext())
            {
                response.Add(x.Next().Key);
            }
            return response;
        }
        #endregion
        #region Checking changes
        public void DoOnAction(KeyValuePair<string, object> data)
        {
            
            if (data.Key != "Achievement") return;
            switch ((int)data.Value)
            {
                case 5:
                    IDs.Add(new KeyValuePair<int, bool>(1,true));
                    break;
                case 10:
                    IDs.Add(new KeyValuePair<int, bool>(2, true));
                    break;
                case 15:
                    IDs.Add(new KeyValuePair<int, bool>(3, true));
                    break;
                case 20:
                    IDs.Add(new KeyValuePair<int, bool>(4, true));
                    break;
                case 25:
                    IDs.Add(new KeyValuePair<int, bool>(5, true));
                    break;
                case 30:
                    IDs.Add(new KeyValuePair<int, bool>(6, true));
                    break;
                case 35:
                    IDs.Add(new KeyValuePair<int, bool>(7, true));
                    break;
                default:
                    break;
            }

            var x = GetNew();
            if (x.Count > 0) 
                BasicObjects.Dialog("Osiągnięcie nr " + x[0] + " zostało zdobyte", 3);
        }
        #endregion
    }
}