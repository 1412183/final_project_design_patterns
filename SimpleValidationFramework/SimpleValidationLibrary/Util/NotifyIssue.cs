using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Util
{
    public class NotifyIssue
    {
        private List<IObserver> listObservers = null;

        public void Attach(IObserver observer)
        {
            if (listObservers == null)
            {
                listObservers = new List<IObserver>();
            }
            listObservers.Add(observer);
        }

        protected void Notify()
        {
            if (this.listObservers == null) return;

            foreach (IObserver obj in listObservers)
            {
                obj.Update(obj);
            }
        }
    }
}
