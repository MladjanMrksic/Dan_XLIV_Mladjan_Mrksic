using FoodOrderApp.Command;
using FoodOrderApp.Model;
using FoodOrderApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FoodOrderApp.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;

        public MainWindowViewModel(MainWindow login)
        {
            main = login;
        }

        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string password;
        public string Password
        {

            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(param => SubmitExecute(), param => CanSubmitExecute());
                }
                return submit;
            }
        }
        private void SubmitExecute()
        {
            if (userName == "Employee" && password == "Employee")
            {
                AdminView av = new AdminView();
                main.Close();
                av.Show();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private bool CanSubmitExecute()
        {
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
