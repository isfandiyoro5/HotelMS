using TestHotel.Service.DTO.RequestDto;
using TestHotel.Service.DTO.ResponseDto;

namespace TestHotel.Service.Service.IServices
{
    public interface IBillService
    {
        Task<int> AddBillAsync(BillRequestDto billRequestDto);

        Task<int> UpdateBillAsync(int invoiceNumber, BillRequestDto billRequestDto);

        Task<int> DeleteBillAsync(int invoiceNumber);

        Task<BillResponseDto> GetBillByInvoiceNumberAsync(int invoiceNumber);

        Task<List<BillResponseDto>> GetAllBillsAsync();
    }
}
