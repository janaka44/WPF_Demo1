
using System;
using MvvmDemo.Models;
using System.Diagnostics;
using System.Windows.Input;
using MvvmDemo.Commands;
using MvvmDemo.ViewModels;
using MvvmDemo.Views;

namespace MvvmDemo.ViewModels
{
    internal class CustomerViewModel
    {
        private Customer customer;
        private CustomerInfoViewModel childViewModel;

        public CustomerViewModel()
        {
            customer = new Customer("Janaka");
            //childViewModel = new CustomerInfoViewModel();
            childViewModel = new CustomerInfoViewModel() { Info = "Instantiated in CustomerViewModel() constructor" };
            UpdateCommand = new CustomerUpdateCommand(this);
        }
        
        //public bool CanUpdate {
        //    get {
        //        if (Customer == null)
        //            return false;
        //        else
        //            return !String.IsNullOrWhiteSpace(Customer.Name);
        //    }         
        //}

        public Customer Customer
        {
            get { return customer;  }
            set {
                customer = value;
            }
        }

        public void SaveChanges()
        {
            //Debug.Assert(false, String.Format("{0} was updated", Customer.Name));
            CustomerInfoView view = new CustomerInfoView();
            view.DataContext = childViewModel;

            //childViewModel.Info = Customer.Name + " was updated in the database.";
            view.ShowDialog();
        }

        public ICommand UpdateCommand
        {
            get;
            private set;
        }
    }
}
