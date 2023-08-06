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
                new Bill() {Id= 1, ProjectId = 1, EmployeeId = 1}
            };
        }

        public void AddorUpdate(Bill bill)
        {
            if(bill.Id == 0)
            {
                bill.Id = LastId + 1;
            }
            billList.Add(bill);
        }

        public Bill? Get(int Id)
        {
            return getbillList.FirstOrDefault(p => p.Id == Id);
        }


        public void Delete(int id)
        {
            var remove = Get(id);
            if (remove != null)
            {
                getbillList.Remove(remove);
            }
        }

        private int LastId
        {
            get
            {
                return getbillList.Any() ? getbillList.Select(x => x.Id).Max() : 0;
            }
        }
    }
}
