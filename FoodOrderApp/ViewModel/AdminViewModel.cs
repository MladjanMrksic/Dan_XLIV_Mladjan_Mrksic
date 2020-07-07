﻿using FoodOrderApp.Command;
using FoodOrderApp.Model;
using FoodOrderApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FoodOrderApp.ViewModel
{
    class AdminViewModel : ViewModelBase
    {
        AdminView view;
        FoodOrderModel fom = new FoodOrderModel();

        public AdminViewModel(AdminView av)
        {
            view = av;
            foodOrders = fom.GetAllFoodOrders();
        }

        private List<FoodOrder> foodOrders;
        public List<FoodOrder> FoodOrders
        {
            get
            {
                return foodOrders;
            }
            set
            {
                foodOrders = value;
                OnPropertyChanged("FoodOrders");
            }
        }

        private FoodOrder fOrder;
        public FoodOrder FOrder
        {
            get
            {
                return fOrder;
            }
            set
            {
                fOrder = value;
                OnPropertyChanged("FOrder");
            }
        }

        private ICommand deleteFoodOrder;
        public ICommand DeleteFoodOrder
        {
            get
            {
                if (deleteFoodOrder == null)
                {
                    deleteFoodOrder = new RelayCommand(param => DeleteEmployeeExecute(), param => CanDeleteEmployeeExecute());
                }
                return deleteFoodOrder;
            }
        }
        private void DeleteEmployeeExecute()
        {
            fom.AddFoodOrder(FOrder);
        }
        private bool CanDeleteEmployeeExecute()
        {
            if (FOrder == null)
            {
                return false;
            }
            else if(FOrder.StatusOfOrder.ToUpper() == "READY" || FOrder.StatusOfOrder.ToUpper() == "REJECTED")
            {
                return true;
            }
            return false;
        }


        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand(param => LogoutExecute(), param => CanLogoutExecute());
                }
                return logout;
            }
        }
        private void LogoutExecute()
        {
            MainWindow logout = new MainWindow();
            view.Close();
            logout.Show();
        }
        private bool CanLogoutExecute()
        {
            return true;
        }
    }
}