using TestHotel.DataAccess.Model;

namespace TestHotel.Service.Service.IServices
{
    public interface IBillService
    {
        Task<int> AddBillAsync(Bill bill);

        Task<int> UpdateBillAsync(int invoiceNumber);

        Task<int> DeleteBillAsync(int invoiceNumber);

        Task<Bill> GetBillByIdAsync(int invoiceNumber);

        Task<List<Bill>> GetAllBillsAsync();
    }
}
