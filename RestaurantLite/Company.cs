using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLite
{
    public class Company
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Strn { get; set; }

        public decimal Tax { get; set; }
        public static Company _Company;
        public int CashCustomer { get; set; }
        public int DeliveryCustomer { get; set; }
    }
}
