using System;
using System.ComponentModel;

namespace MvvmDemo.Models
{
    public class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        private string name;

        public Customer(String customerName)
        {
            Name = customerName;
        }
        
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        #region IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    if (String.IsNullOrWhiteSpace(Name))                  
                        Error = "Name cannot be empty or null";
                    else
                        Error = null;
                }
                return Error;
            }
        }

        public string Error
        {
            get;
            private set;
        } 
        #endregion


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            // above single line replaces all these lines below (suggested by editor)
            /*
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
             * */
        } 
        #endregion


    }

    
}
