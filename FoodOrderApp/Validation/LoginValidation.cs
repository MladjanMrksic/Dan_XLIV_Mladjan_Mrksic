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
                FoodCustomer fc;
                using (FoodOrderAppBaseEntities context = new FoodOrderAppBaseEntities())
                {
                    fc = (from c in context.FoodCustomers where c.JMBG == username select c).FirstOrDefault();
                }
                CustomerView cv = new CustomerView(fc);
                main.Close();
                cv.Show();
            }
            else if (!customersList.Contains((from c in customersList where c.JMBG == username select c).FirstOrDefault()) && password == "Guest")
            {
                FoodCustomer fc = new FoodCustomer();
                fc.JMBG = username;
                fcm.AddFoodCustomer(fc);
                CustomerView cv = new CustomerView(fc);
                main.Close();
                cv.Show();
            }
            else
            {
                MessageBox.Show("Username or Password was incorrect ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
    }
}
