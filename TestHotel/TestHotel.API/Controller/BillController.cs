using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestHotel.DataAccess.Repository.IRepositories;
using TestHotel.DataAccess.Model;
using System.Security.Cryptography.X509Certificates;

namespace TestHotel.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillRepository _billRepository;

        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        [HttpPost]
        public async Task<int> CreateBillAsync(Bill bill)
        {
            return await _billRepository.AddBillAsync(bill);
        }

        [HttpGet("invoiceNumber")]
        public async Task<Bill> GetBillByInvoiceNumberAsync(int invoiceNumber)
        {
            return await _billRepository.GetBillByInvoiceNumberAsync(invoiceNumber);
        }

        [HttpGet]
        public async Task<List<Bill>> GetAllBillsAsync()
        {
            return await _billRepository.GetAllBillsAsync();
        }

        [HttpPut]
        public async Task<int> UpdateBillAsync(Bill bill)
        {
            return await _billRepository.UpdateBillAsync(bill);
        }

        [HttpDelete]
        public async Task<int> DeleteBillAsync(Bill bill)
        {
            return await _billRepository.DeleteBillAsync(bill);
        }
    }
}
