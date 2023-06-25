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
