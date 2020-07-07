using FoodOrderApp.Model;
using FoodOrderApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FoodOrderApp.Validation
{
    class LoginValidation
    {
        FoodCustomerModel fcm = new FoodCustomerModel();
        public void Login(string username, string password, MainWindow main)
        {
            List<FoodCustomer> customersList = fcm.GetAllFoodCustomers();
            if (username == "Employee" && password == "Employee")
            {
                AdminView av = new AdminView();
                main.Close();
                av.Show();
            }
            else if (customersList.Contains((from c in customersList where c.JMBG == username select c).FirstOrDefault()) && password == "Guest")
            {
                MessageBox.Show("User menu");
            }
        }
        
    }
}
