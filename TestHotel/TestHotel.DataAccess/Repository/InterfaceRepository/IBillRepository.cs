using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.InterfaceRepository
{
    public interface IBillRepository
    {
        public Bill AddBill(Bill bill);

        public Bill GetBillByInvoiceNumber(int invoiceNumber);

        public List<Bill> GetAllBills();

        public int UpdateBill(Bill bill);

        public int DeleteBill(Bill bill);
    }
}
