using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmDemo.ViewModels
{
    class CustomerInfoViewModel : INotifyPropertyChanged
    {
        private string info;

        public String Info {
            get { return info;  }
            set {
                info = value;
                OnPropertyChanged("Info");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
