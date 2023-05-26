using Microsoft.AspNetCore.Mvc;
using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;
using TestHotel.Service.Service.IServices;

namespace TestHotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddBill(BillRequestDto billRequestDto)
        {
            return await _billService.AddBillAsync(billRequestDto);
        }

        [HttpGet("InvoiceNumber")]
        public async Task<ActionResult<BillResponseDto>> GetBillByInvoiceNumber(int invoiceNumber)
        {
            return await _billService.GetBillByInvoiceNumberAsync(invoiceNumber);
        }

        [HttpGet]
        public async Task<ActionResult<List<BillResponseDto>>> GetAllBills()
        {
            return await _billService.GetAllBillsAsync();
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateBill(int invoiceNumber, BillRequestDto billRequestDto)
        {
            return await _billService.UpdateBillAsync(invoiceNumber, billRequestDto);
        }

        [HttpDelete]
        public async Task<ActionResult<int>> DeleteBill(int invoiceNumber)
        {
            return await _billService.DeleteBillAsync(invoiceNumber);
        }
    }
}
