using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantLite.QT
{
    public class QTMaster
    {
        public int RecNo { get; set; }
        public string OrderNo { get; set; }
        public string TableNo { get; set; }
        public int CustomerId { get; set; }
        public string QTType { get; set; }
        public string CName { get; set; }
        public string CAddress { get; set; }
        public string CMobile { get; set; }
        public string DName { get; set; }
        public string DMobile { get; set; }
        public double BillAmount { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double TotalAmount { get; set; }
        public double CashReceipt { get; set; }
        public double Balance { get; set; }
        public DateTime TDate { get; set; }
        public List<Detail> Details { get; set; }
    }
    public class Detail
    {
        public int RecNo { get; set; }
        public int Sno { get; set; }
        public int ItemId { get; set; }
        public double Qty { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
    }
}
