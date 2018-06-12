using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleValidationLibrary.Util
{
    public interface IObserver
    {
        void Update(IObserver subject);
        //void Update(NotifyIssue notifyIssue);
    }
}
