using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    internal interface IBillService
    {
        Task<int> AddBillAsync(Bill bill);

        Task<int> UpdateBillAsync(Bill bill);

        Task<int> DeleteBillAsync(Bill bill);

        Task<Bill> GetBillByIdAsync(int invoiceNumber);

        Task<List<Bill>> GetAllBillsAsync();
    }
}
