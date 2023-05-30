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
            try
            {
                return await _billService.AddBillAsync(billRequestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("InvoiceNumber")]
        public async Task<ActionResult<BillResponseDto>> GetBillByInvoiceNumber(int invoiceNumber)
        {
            try
            {
                return await _billService.GetBillByInvoiceNumberAsync(invoiceNumber);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<BillResponseDto>>> GetAllBills()
        {
            try
            {
                return await _billService.GetAllBillsAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateBill(int invoiceNumber, BillRequestDto billRequestDto)
        {
            try
            {
                return await _billService.UpdateBillAsync(invoiceNumber, billRequestDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("Id")]
        public async Task<ActionResult<int>> DeleteBill(int invoiceNumber)
        {
            try
            {
                return await _billService.DeleteBillAsync(invoiceNumber);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
