using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHotel.DataAccess.Model;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Repository.Repositories;
using TestHotel.Service.Service.IServices;

namespace TestHotel.Service.Service.Services
{
    internal class BillService: IBillService
    {
        private readonly IBillRepository _billRepository;

        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public async Task<int> AddBillAsync(Bill bill)
        {
            return await _billRepository.AddBillAsync(bill);
        }

        public async Task<int> UpdateBillAsync(int invoiceNumber)
        {
            var billResult = await GetBillByIdAsync(invoiceNumber);
            if (billResult is not null)
            {
                return await _billRepository.UpdateBillAsync(billResult);
            }
            else
            {
                throw new Exception("Update uchun Bill mavjud emas");
            }
        }

        public async Task<int> DeleteBillAsync(int invoiceNumber)
        {
            var billResult = await GetBillByIdAsync(invoiceNumber);
            if(billResult is not null)
            {
                return await _billRepository.DeleteBillAsync(billResult);
            }
            else
            {
                throw new Exception("Delete uchun bunday Bill mavjud emas");
            }
        }

        public async Task<List<Bill>> GetAllBillsAsync()
        {
            return await _billRepository.GetAllBillsAsync();
        }

        public async Task<Bill> GetBillByIdAsync(int invoiceNumber)
        {
            return await _billRepository.GetBillByInvoiceNumberAsync(invoiceNumber);
        }
    }
}
