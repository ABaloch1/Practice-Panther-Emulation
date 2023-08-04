using Project_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_library.Services
{
    public class BillService
    {
        private static BillService? instance;

        private List<Bill> billList;
        
        public List<Bill> getbillList
        {
            get { return billList; }
        }

        public static BillService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new BillService();
                }
                return instance;
            }
        }

        private BillService()
        {
            billList = new List<Bill>()
            {
                //new Bill() {}
            };
        }

        public Bill AddorUpdate(Bill bill)
        {
            billList.Add(bill);
            return bill;
        }

        //delete?
        //last id?
    }
}
