using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    public abstract class BaseNotify : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(object notifier, string propName)
        {
            this.PropertyChanged?.Invoke(notifier, new PropertyChangedEventArgs(propName));
        }
    }
}
