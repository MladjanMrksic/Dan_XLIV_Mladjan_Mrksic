using FoodOrderApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderApp.ViewModel
{
    class CustomerViewModel : ViewModelBase
    {
        CustomerView view;

        public CustomerViewModel(CustomerView newView)
        {
            view = newView;
        }
    }
}
