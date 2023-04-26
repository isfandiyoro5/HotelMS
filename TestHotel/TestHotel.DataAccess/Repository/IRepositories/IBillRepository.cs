using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.DataAccess.Repository.IRepositories
{
    public interface IBillRepository
    {
        Task<int> AddBillAsync(Bill bill);

        Task<Bill> GetBillByInvoiceNumberAsync(int invoiceNumber);

        Task<List<Bill>> GetAllBillsAsync();

        Task<int> UpdateBillAsync(Bill bill);

        Task<int> DeleteBillAsync(Bill bill);
    }
}
